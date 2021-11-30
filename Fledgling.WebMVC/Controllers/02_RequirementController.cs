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
    public class RequirementController : Controller
    {
        // GET: Requirement-Index
        public ActionResult Index()
        {
            RequirementService service = CreateRequirementService();
            var model = service.GetRequirements();
            return View(model);
        }

        // GET : Requirement-Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requirement-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequirementCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRequirementService();

            if (service.CreateRequirement(model))
            {
                TempData["SaveResult"] = "Your requirement was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Requirement could not be created.");

            return View(model);
        }

        // GET : Requirement-Details
        public ActionResult Details(int id)
        {
            var svc = CreateRequirementService();
            var model = svc.GetRequirementById(id);

            return View(model);
        }

        // GET : Requirement-Edit
        public ActionResult Edit(int id)
        {
            var service = CreateRequirementService();
            var detail = service.GetRequirementById(id);
            var model =
                new RequirementEdit
                {
                    RequirementID = detail.RequirementID,
                    ProjectID = detail.ProjectID,
                    ReqOrigin = detail.ReqOrigin,
                    ReqDescription = detail.ReqDescription,
                    ReqLink = detail.ReqLink
                };
            return View(model);
        }

        // POST : Requirement-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequirementEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RequirementID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRequirementService();

            if (service.UpdateRequirement(model))
            {
                TempData["SaveResult"] = "Your requirement was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your requirement could not be updated.");

            return View();
        }

        // GET : Requirement-Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateRequirementService();
            var model = svc.GetRequirementById(id);

            return View(model);
        }

        // POST : Requirement-Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRequirement(int id)
        {
            var service = CreateRequirementService();

            service.DeleteRequirement(id);

            TempData["SaveResult"] = "Your requirement was deleted.";

            return RedirectToAction("Index");
        }

        // Helper Method
        private RequirementService CreateRequirementService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RequirementService(userId);
            return service;
        }
    }
}