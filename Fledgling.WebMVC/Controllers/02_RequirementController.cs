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
        // GET: Requirement
        public ActionResult Index()
        {
            return View();
        }
    }
}