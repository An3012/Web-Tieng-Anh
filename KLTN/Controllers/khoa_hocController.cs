using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLTN.Entities;


namespace User.Controllers
{
    public class khoa_hocController : Controller
    {
        // GET: khoa_hoc
        private readonly WEB_TIENG_ANHContext context;
        public khoa_hocController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            var list = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listsp = list;
            return View();
        }
        public ActionResult online()
        {
            return View();
        }
        public ActionResult Ngu_phap()
        {
            return View();
        }
        public ActionResult Tu_vung()
        {
            return View();
        }
        public ActionResult Ngu_phap_1()
        {
            return View();
        }
        public ActionResult Ngu_phap_2()
        {
            return View();
        }
        public ActionResult Ngu_phap_3()
        {
            return View();
        }
        public ActionResult Tu_vung1()
        {
            return View();
        }
        public ActionResult Tu_vung2()
        {
            return View();
        }
        public ActionResult lien_he_mua_khoa_hoc()
        {
            return View();
        }


    }
}