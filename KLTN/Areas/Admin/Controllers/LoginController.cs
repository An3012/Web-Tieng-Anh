using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private readonly WEB_TIENG_ANHContext context;
        public LoginController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                ViewBag.ErrorMessage = "Email và mật khẩu không được để trống.";
                return View();
            }

            var user = context.HtNguoiDung.FirstOrDefault(u => u.Email == email && u.MatKhau == MaHoaMatKhau.EncryptPassword(pass));
            if (user.Email != null)
            {
                Session["UserEmail"] = email;
                return RedirectToAction("Index", "Danh_muc_Admin");
            }
            else
            {
                // Thất bại: Thông báo lỗi
                ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng.";
                return View();
            }
        }
    }
}