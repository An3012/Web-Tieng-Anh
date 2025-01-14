using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class Danh_muc_AdminController : Controller
    {
        // GET: Admin/Danh_muc_Admin
        private readonly WEB_TIENG_ANHContext context;

        public Danh_muc_AdminController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            var listsp = context?.HtNguoiDung.Where(x => context.HtNhomQuyen
                                                    .Where(nq => nq.Ten != "Người dùng")
                                                    .Select(nq => nq.Id)
                                                    .Contains(x.IdNhomQuyen))
                                                    .ToList() ?? new List<HtNguoiDung>();
            if (string.IsNullOrEmpty(TempData["ToastMessage"]?.ToString()))
            {
                if (listsp == null || !listsp.Any())
                {
                    TempDataHelper.SetTempData(this, "Danh sách không có dữ liệu!", "warning");
                }
                else
                {
                    TempDataHelper.SetTempData(this, "Tải dữ liệu thành công!", "info");
                }
            }

            ViewBag.listsp = listsp;
            ViewBag.listNhomQuyen = context?.HtNhomQuyen.ToList() ?? new List<HtNhomQuyen>();
            return View();
        }
        // GET: Admin/Danh_muc_Admin/them_moi
        public ActionResult them_moi()
        {
            ViewBag.listNhomQuyen = context?.HtNhomQuyen.Where(nq => nq.Ten != "Người dùng").ToList() ?? new List<HtNhomQuyen>();
            return View();
        }
        // POST: Admin/Danh_muc_Admin/them_moi
        [HttpPost]
        public ActionResult xl_them_moi(string val_TenDangNhap, string val_HoVaTen,string val_email, string pass, string IdNhomQuyen)
        {
            try
            {
                var HtNguoiDungew = new HtNguoiDung
                {
                    Id = Guid.NewGuid().ToString(),
                    TenDangNhap = val_TenDangNhap,
                    HoVaTen = val_HoVaTen,
                    Email = val_email,
                    MatKhau = MaHoaMatKhau.EncryptPassword(pass),
                    IdNhomQuyen = IdNhomQuyen,
                };

                context?.HtNguoiDung.Add(HtNguoiDungew);
                context?.SaveChanges();

                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "Danh_muc_Admin");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm mới đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "Danh_muc_Admin");
            }
        }
    }
}