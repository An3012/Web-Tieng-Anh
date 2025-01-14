using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class Danh_muc_nguoi_dungController : Controller
    {
        // GET: Admin/Danh_muc_nguoi_dung
        private readonly WEB_TIENG_ANHContext context;

        public Danh_muc_nguoi_dungController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            var idNhomQuyenNguoiDung = context?.HtNhomQuyen?.FirstOrDefault(x => x.Ten == "Người dùng").Id;
            var listsp = context?.HtNguoiDung?.Where(x => x.IdNhomQuyen == idNhomQuyenNguoiDung).ToList() ?? new List<HtNguoiDung>();

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
            ViewBag.listNhomQuyen = context?.HtNhomQuyen?.ToList() ?? new List<HtNhomQuyen>();
            return View();
        }
        
    }
}