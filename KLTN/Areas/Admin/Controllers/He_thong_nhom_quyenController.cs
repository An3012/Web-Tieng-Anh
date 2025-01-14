using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class He_thong_nhom_quyenController : Controller
    {
        // GET: Admin/He_thong_nhom_quyen
        private readonly WEB_TIENG_ANHContext context;

        public He_thong_nhom_quyenController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            var listsp = context?.HtNhomQuyen?.ToList() ?? new List<HtNhomQuyen>();

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
            ViewBag.listHtQuyen = context?.HtQuyen?.ToList() ?? new List<HtQuyen>();
            ViewBag.listHtQuyenNhomQuyen = context?.HtQuyenNhomQuyen?.ToList() ?? new List<HtQuyenNhomQuyen>();
            return View();
        }

        // GET: Admin/He_thong_nhom_quyen/them_moi
        public ActionResult them_moi()
        {
            return View();
        }
        // POST: Admin/He_thong_nhom_quyen/them_moi
        [HttpPost]
        public ActionResult xl_them_moi(string val_He_thong_nhom_quyen, string val_mo_ta)
        {
            try
            {
                var HtNhomQuyennew = new HtNhomQuyen
                {
                    Id = Guid.NewGuid().ToString(),
                    MoTa = val_mo_ta,
                    Ten = val_He_thong_nhom_quyen,
                };

                context?.HtNhomQuyen.Add(HtNhomQuyennew);
                context?.SaveChanges();

                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "He_thong_nhom_quyen");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm nhóm quyền đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "He_thong_nhom_quyen");
            }
        }
        //// GET: Admin/He_thong_nhom_quyen/cap_nhat
        //public ActionResult cap_nhat(string id)
        //{
        //    var HtNhomQuyen = context.HtNhomQuyen.AsEnumerable().FirstOrDefault(x => x.Id == id);
        //    if (HtNhomQuyen == null)
        //    {
        //        TempDataHelper.SetTempData(this, "Không tìm thấy loại khóa học!", "error");
        //        return RedirectToAction("Index", "He_thong_nhom_quyen");
        //    }
        //    ViewBag.He_thong_nhom_quyen = HtNhomQuyen;
        //    return View();
        //}
        //// POST: Admin/He_thong_nhom_quyen/cap_nhat
        //[HttpPost]
        //public ActionResult xl_cap_nhat(string id, string val_He_thong_nhom_quyen, string val_mo_ta)
        //{
        //    try
        //    {
        //        var HtNhomQuyen = context.HtNhomQuyen.FirstOrDefault(x => x.Id == id);
        //        if (HtNhomQuyen == null)
        //        {
        //            TempDataHelper.SetTempData(this, "Loại khóa học không tồn tại!", "error");
        //            return RedirectToAction("Index", "He_thong_nhom_quyen");
        //        }
        //        HtNhomQuyen.TenPhanMuc = val_He_thong_nhom_quyen;
        //        HtNhomQuyen.MoTa = val_mo_ta;
        //        context.SaveChanges();
        //        TempDataHelper.SetTempData(this, "Cập nhật thành công!", "success");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình cập nhật! - {ex.Message}", "error");
        //    }
        //    return RedirectToAction("Index", "He_thong_nhom_quyen");
        //}

        public ActionResult xoa(string id)
        {
            try
            {
                var HtNhomQuyen = context.HtNhomQuyen.FirstOrDefault(x => x.Id == id);
                context.HtNhomQuyen.Remove(HtNhomQuyen);
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Xóa thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình xóa! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "He_thong_nhom_quyen");
        }
    }
}