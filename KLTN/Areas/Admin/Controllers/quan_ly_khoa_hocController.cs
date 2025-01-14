using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLTN.Entities;
using KLTN.Models;

namespace KLTN.Areas.Admin.Controllers
{
    public class quan_ly_khoa_hocController : Controller
    {
        private readonly WEB_TIENG_ANHContext context;

        public quan_ly_khoa_hocController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        // GET: Admin/quan_ly_khoa_hoc
        public ActionResult Index()
        {
            var list = context?.DmKhoaHoc?.Where(x =>x.Del != 1).AsEnumerable().ToList() ?? new List<DmKhoaHoc>();

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
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 1) 
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            return View();
        }

        public ActionResult them_moi()
        {
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 1)
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            return View();
        }
        // POST: Admin/quan_ly_khoa_hoc/xl_them_moi
        [HttpPost]
        public ActionResult them_moi(HttpPostedFileBase fileImage,
                                                        string val_TenKhoaHoc,
                                                        string val_PhanLoaiKhoaHoc,
                                                        string val_Mota,
                                                        string val_Gia,
                                                        string val_GiamGia,
                                                        string val_maquyen,
                                                        string val_TenGiaoVien,
                                                        string val_tinhtrang)
        {
            try
            {
                // Đường dẫn lưu file ảnh
                var urlfile = "/Update/";
                var urlServer = Server.MapPath(urlfile);
                // Tạo đối tượng khóa học mới
                DmKhoaHoc khoahocnew = new DmKhoaHoc()
                {
                    Id = Guid.NewGuid().ToString(),
                    TenKhoaHoc = val_TenKhoaHoc?.Trim(),
                    MoTa = val_Mota?.Trim(),
                    IdPhanMuc = val_PhanLoaiKhoaHoc?.Trim(),
                    Gia = string.IsNullOrWhiteSpace(val_Gia) ? 0 : int.Parse(val_Gia),
                    GiamGia = string.IsNullOrWhiteSpace(val_GiamGia) ? 0 : int.Parse(val_GiamGia),
                    MaQuyen = val_maquyen?.Trim(),
                    TenGiaoVien = val_TenGiaoVien?.Trim(),
                    TinhTrang = val_tinhtrang == "true" ? 1 : 0,
                };

                // Xử lý lưu file ảnh
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    // Tạo tên file và đường dẫn lưu trữ
                    var fileName = Path.GetFileName(fileImage.FileName);
                    var savePath = Path.Combine(urlfile, fileName);
                    var fullPath = Path.Combine(urlServer, fileName);

                    // Kiểm tra file đã tồn tại hay chưa
                    if (System.IO.File.Exists(fullPath))
                    {
                        // Nếu file đã tồn tại, ghi đè đường dẫn
                        khoahocnew.ImgLink = savePath;
                    }
                    else
                    {
                        // Lưu file ảnh mới vào server
                        fileImage.SaveAs(fullPath);
                        khoahocnew.ImgLink = savePath;
                    }
                }
                context.DmKhoaHoc.Add(khoahocnew);
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");

            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm khóa học đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");
            }
        }


        public ActionResult cap_nhat(string id)
        {
            var KhoaHoc = context.DmKhoaHoc.AsEnumerable().FirstOrDefault(x => x.Id == id && x.Del != 1);
            if (KhoaHoc == null)
            {
                TempDataHelper.SetTempData(this, "Không tìm thấy khóa học!", "error");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");
            }
            ViewBag.khoa_hoc = KhoaHoc;
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 1)
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            return View();
        }



        [HttpPost]
        public ActionResult cap_nhat(string id,
                                                HttpPostedFileBase fileImage,
                                                string val_TenKhoaHoc,
                                                string val_PhanLoaiKhoaHoc,
                                                string val_Mota,
                                                string val_Gia,
                                                string val_GiamGia,
                                                string val_maquyen,
                                                string val_TenGiaoVien,
                                                string val_tinhtrang)
        {
            try
            {
                var khoahoc = context.DmKhoaHoc.FirstOrDefault(kh => kh.Id == id);
                if (khoahoc == null)
                {
                    TempDataHelper.SetTempData(this, "Khóa học không tồn tại!", "error");
                    return RedirectToAction("Index", "quan_ly_khoa_hoc");
                }
                khoahoc.TenKhoaHoc = val_TenKhoaHoc?.Trim();
                khoahoc.MoTa = val_Mota?.Trim();
                khoahoc.IdPhanMuc = val_PhanLoaiKhoaHoc?.Trim();
                khoahoc.Gia = string.IsNullOrWhiteSpace(val_Gia) ? 0 : int.Parse(val_Gia);
                khoahoc.GiamGia = string.IsNullOrWhiteSpace(val_GiamGia) ? 0 : int.Parse(val_GiamGia);
                khoahoc.MaQuyen = val_maquyen?.Trim();
                khoahoc.TenGiaoVien = val_TenGiaoVien?.Trim();
                khoahoc.TinhTrang = val_tinhtrang == "true" ? 1 : 0;
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    var urlfile = "/Update/";
                    var urlServer = Server.MapPath(urlfile);
                    var fileName = Path.GetFileName(fileImage.FileName);
                    var savePath = Path.Combine(urlfile, fileName);
                    var fullPath = Path.Combine(urlServer, fileName);

                    if (System.IO.File.Exists(fullPath))
                    {
                        khoahoc.ImgLink = savePath;
                    }
                    else
                    {
                        fileImage.SaveAs(fullPath);
                        khoahoc.ImgLink = savePath;
                    }
                }
                context.SaveChanges();

                TempDataHelper.SetTempData(this, "Cập nhật thành công!", "success");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Cập nhật khóa học gặp lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");
            }
        }
        public ActionResult xoa(string id)
        {
            try
            {
                var khoaHoc = context.DmKhoaHoc.FirstOrDefault(x => x.Id == id);
                khoaHoc.Del = 1;
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Xóa thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình xóa! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "quan_ly_khoa_hoc");
        }

        public ActionResult chi_tiet(string id)
        {
            var KhoaHoc = context.DmKhoaHoc.AsEnumerable().FirstOrDefault(x => x.Id == id && x.Del != 1);
            if (KhoaHoc == null)
            {
                TempDataHelper.SetTempData(this, "Không tìm thấy khóa học!", "error");
                return RedirectToAction("Index", "quan_ly_khoa_hoc");
            }
            ViewBag.khoa_hoc = KhoaHoc;
            var listLoaiKhoaHoc = context?.HtPhanMuc?.FirstOrDefault(x => x.Id == KhoaHoc.IdPhanMuc)
                                                     .TenPhanMuc
                                                     ?? "Chưa phân loại";
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            return View();
        }
    }
}