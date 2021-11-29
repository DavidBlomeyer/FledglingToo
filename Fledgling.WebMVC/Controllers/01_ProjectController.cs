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

        // Helper Method
        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
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
    }
}