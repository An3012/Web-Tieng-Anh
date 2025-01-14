using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class Quan_ly_lo_trinh_hocController : Controller
    {
        private readonly WEB_TIENG_ANHContext context;

        public Quan_ly_lo_trinh_hocController()
        {
            context = new WEB_TIENG_ANHContext();
        }

        // GET: Admin/Quan_ly_lo_trinh_hoc
        public ActionResult Index()
        {
            var listsp = context?.LoTrinhHoc?.ToList() ?? new List<LoTrinhHoc>();

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
            var listKhoaHoc = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listKhoaHoc = listKhoaHoc;
            ViewBag.listsp = listsp;
            return View();
        }

        // GET: Admin/Quan_ly_lo_trinh_hoc/them_moi
        public ActionResult them_moi()
        {
            var listKhoaHoc = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listKhoaHoc = listKhoaHoc;
            return View();
        }
        // POST: Admin/Quan_ly_lo_trinh_hoc/them_moi
        [HttpPost]
        public ActionResult xl_them_moi(string val_TenLoTrinh, string val_mota, string val_IdKhoaHoc)
        {
            try
            {
                var LoTrinhHocnew = new LoTrinhHoc
                {
                    Id = Guid.NewGuid().ToString(),
                    NoiDung = val_mota,
                    TenLoTrinh = val_TenLoTrinh,
                    IdKhoaHoc = val_IdKhoaHoc,
                };

                context?.LoTrinhHoc.Add(LoTrinhHocnew);
                context?.SaveChanges();

                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm khóa học đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
            }
        }
        // GET: Admin/Quan_ly_lo_trinh_hoc/cap_nhat
        public ActionResult cap_nhat(string id)
        {

            var LoTrinhHoc = context.LoTrinhHoc.AsEnumerable().FirstOrDefault(x => x.Id == id);
            if (LoTrinhHoc == null)
            {
                TempDataHelper.SetTempData(this, "Không tìm thấy lộ trình học!", "error");
                return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
            }
            var listKhoaHoc = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listKhoaHoc = listKhoaHoc;
            ViewBag.Quan_ly_lo_trinh_hoc = LoTrinhHoc;
            return View();
        }
        // POST: Admin/Quan_ly_lo_trinh_hoc/cap_nhat
        [HttpPost]
        public ActionResult xl_cap_nhat(string id, string val_TenLoTrinh, string val_mota, string val_IdKhoaHoc)
        {
            try
            {
                var LoTrinhHoc = context.LoTrinhHoc.FirstOrDefault(x => x.Id == id);
                if (LoTrinhHoc == null)
                {
                    TempDataHelper.SetTempData(this, "Lộ trình học không tồn tại!", "error");
                    return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
                }
                LoTrinhHoc.TenLoTrinh = val_TenLoTrinh;
                LoTrinhHoc.NoiDung = val_mota;
                LoTrinhHoc.IdKhoaHoc = val_IdKhoaHoc;
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Cập nhật thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình cập nhật! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
        }

        public ActionResult xoa(string id)
        {
            try
            {
                var LoTrinhHoc = context.LoTrinhHoc.FirstOrDefault(x => x.Id == id);
                context.LoTrinhHoc.Remove(LoTrinhHoc);
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Xóa thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình xóa! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "Quan_ly_lo_trinh_hoc");
        }
    }
}