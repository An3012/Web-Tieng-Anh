using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User.Controllers
{
    public class ky_nangController : Controller
    {
        // GET: ky_nang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult speaking()
        {
            return View();
        }
        public ActionResult writing()
        {
            return View();
        }
        public ActionResult reading()
        {
            return View();
        }
        public ActionResult listening()
        {
            return View();
        }
    }
}