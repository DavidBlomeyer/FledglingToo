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
    public class ProjectController : Controller
    {
        // GET: Project-Index
        public ActionResult Index()
        {
            ProjectService service = CreateProjectService();
            var model = service.GetProjects();
            return View(model);
        }



        // GET : Project-Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateProjectService();

            if (service.CreateProject(model))
                {
                    TempData["SaveResult"] = "Your project was created";
                    return RedirectToAction("Index");
                };

            ModelState.AddModelError("", "Project could not be created.");

            return View(model);

        }

        // GET : Project-Details
        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        // GET : Project-Edit
        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectID = detail.ProjectID,
                    ProjectName = detail.ProjectName,
                    ProjectAuthor = detail.ProjectAuthor,
                    ProjectThesis = detail.ProjectThesis
                };
            return View(model);
        }

        // POST : Project-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
                {
                    TempData["SaveResult"] = "Your project was updated.";
                    return RedirectToAction("Index");
                }

            ModelState.AddModelError("", "Your project could not be updated.");

            return View();
        }

        // GET : Project-Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        // POST : Project-Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProject(int id)
        {
            var service = CreateProjectService();

            service.DeleteProject(id);

            TempData["SaveResult"] = "Your project was deleted.";

            return RedirectToAction("Index");
        }


        // Helper Method
        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}