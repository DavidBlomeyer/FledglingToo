using Fledgling.Models;
using Fledgling.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fledgling.WebMVC.Controllers
{
    [Authorize]
    public class IdeaController : Controller
    {
        // GET: Idea-Index
        public ActionResult Index()
        {
            IdeaService service = CreateIdeaService();
            var model = service.GetIdeas();
            return View(model);
        }

        // GET : Idea-Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idea-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdeaCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIdeaService();

            if (service.CreateIdea(model))
            {
                TempData["SaveResult"] = "Your idea was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Idea could not be created.");

            return View(model);
        }

        // GET : Idea-Details
        public ActionResult Details(int id)
        {
            var svc = CreateIdeaService();
            var model = svc.GetIdeaById(id);

            return View(model);
        }

        // GET : Idea-Edit
        public ActionResult Edit(int id)
        {
            var service = CreateIdeaService();
            var detail = service.GetIdeaById(id);
            var model =
                new IdeaEdit
                {
                    IdeaID = detail.IdeaID,
                    ProjectID = detail.ProjectID,
                    IdeaName = detail.IdeaName,
                    IdeaAuthor = detail.IdeaAuthor,
                    IdeaThesis = detail.IdeaThesis
                };
            return View(model);
        }

        // POST : Idea-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IdeaEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IdeaID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIdeaService();

            if (service.UpdateIdea(model))
            {
                TempData["SaveResult"] = "Your idea was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your idea could not be updated.");

            return View();
        }

        // GET : Idea-Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateIdeaService();
            var model = svc.GetIdeaById(id);

            return View(model);
        }

        // POST : Idea-Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIdea(int id)
        {
            var service = CreateIdeaService();

            service.DeleteIdea(id);

            TempData["SaveResult"] = "Your idea was deleted.";

            return RedirectToAction("Index");
        }

        // Helper Method
        private IdeaService CreateIdeaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IdeaService(userId);
            return service;
        }
    }
}