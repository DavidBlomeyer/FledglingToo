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
        // GET: Idea
        public ActionResult Index()
        {
            return View();
        }
    }
}