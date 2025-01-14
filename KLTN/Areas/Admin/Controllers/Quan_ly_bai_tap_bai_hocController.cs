using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class Quan_ly_bai_tap_bai_hocController : Controller
    {
        private readonly WEB_TIENG_ANHContext context;
        private string config_UrlSave = "/Uploads/File/" + TempDataHelper.GetFolderByDate();
        public Quan_ly_bai_tap_bai_hocController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        // GET: Admin/Quan_ly_bai_tap_bai_hoc
        public ActionResult Index()
        {
            var list = context?.DmBaiTap?.ToList() ?? new List<DmBaiTap>();

            if (string.IsNullOrEmpty(TempData["ToastMessage"]?.ToString()))
            {
                if (list == null || !list.Any())
                {
                    TempDataHelper.SetTempData(this, "Danh sách không có dữ liệu!", "warning");
                }
                else
                {
                    TempDataHelper.SetTempData(this, "Tải dữ liệu thành công!", "info");
                }
            }
            ViewBag.listsp = list;
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 3)
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            ViewBag.listKhoaHoc = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listLoTrinh = context?.LoTrinhHoc?.ToList() ?? new List<LoTrinhHoc>();
            return View();
        }
    }
}