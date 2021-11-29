using Fledgling.WebMVC.Models;
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
            var model = new ProjectListItem[0]; 
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}