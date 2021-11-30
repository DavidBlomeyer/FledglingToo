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
    public class AudienceController : Controller
    {
        // GET: Audience-Index
        public ActionResult Index()
        {
            AudienceService service = CreateAudienceService();
            var model = service.GetAudiences();
            return View(model);
        }

        // GET : Audience-Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audience-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AudienceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAudienceService();

            if (service.CreateAudience(model))
            {
                TempData["SaveResult"] = "Your audience was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Audience could not be created.");

            return View(model);
        }

        // GET : Audience-Details
        public ActionResult Details(int id)
        {
            var svc = CreateAudienceService();
            var model = svc.GetAudienceById(id);

            return View(model);
        }

        // GET : Audience-Edit
        public ActionResult Edit(int id)
        {
            var service = CreateAudienceService();
            var detail = service.GetAudienceById(id);
            var model =
                new AudienceEdit
                {
                    AudienceID = detail.AudienceID,
                    IdeaID = detail.IdeaID,
                    Who = detail.Who,
                    What = detail.What,
                    Why = detail.Why,
                    When = detail.When
                };
            return View(model);
        }

        // POST : Audiencea-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AudienceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AudienceID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAudienceService();

            if (service.UpdateAudience(model))
            {
                TempData["SaveResult"] = "Your audience was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your audience could not be updated.");

            return View();
        }

        // GET : Audience-Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateAudienceService();
            var model = svc.GetAudienceById(id);

            return View(model);
        }

        // POST : Audience-Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAudience(int id)
        {
            var service = CreateAudienceService();

            service.DeleteAudience(id);

            TempData["SaveResult"] = "Your audience was deleted.";

            return RedirectToAction("Index");
        }

        // Helper Method
        private AudienceService CreateAudienceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AudienceService(userId);
            return service;
        }
    }
}