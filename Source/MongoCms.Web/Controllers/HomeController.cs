using RealEstate.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoCms.Controllers
{
    public class HomeController : Controller
    {

        public MongoCmsContext _context = new MongoCmsContext();

        public ActionResult Info()
        {
            _context.Database.GetStats();
            return Json(_context.Database.Server.BuildInfo, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}