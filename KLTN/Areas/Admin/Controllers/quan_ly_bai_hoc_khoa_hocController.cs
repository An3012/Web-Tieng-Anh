using KLTN.Entities;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Areas.Admin.Controllers
{
    public class quan_ly_bai_hoc_khoa_hocController : Controller
    {
        // GET: Admin/quan_ly_bai_hoc_khoa_hoc
        private readonly WEB_TIENG_ANHContext context;
        private string config_UrlSave = "/Uploads/File/" + TempDataHelper.GetFolderByDate();
        public quan_ly_bai_hoc_khoa_hocController()
        {
            context = new WEB_TIENG_ANHContext();
        }
        public ActionResult Index()
        {
            var list = context?.DmBaiHoc?.ToList() ?? new List<DmBaiHoc>();

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
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 2)
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            ViewBag.listKhoaHoc = context?.DmKhoaHoc?.ToList() ?? new List<DmKhoaHoc>();
            ViewBag.listLoTrinh = context?.LoTrinhHoc?.ToList() ?? new List<LoTrinhHoc>();
            return View();
        }
        public ActionResult them_moi()
        {
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 2)
                                                     .ToList()
                                                     ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            ViewBag.listLoTrinh = context?.LoTrinhHoc?.ToList() ?? new List<LoTrinhHoc>();
            return View();
        }
        // POST: Admin/quan_ly_bai_hoc_khoa_hoc/them_moi
        [HttpPost]
        public ActionResult them_moi(HttpPostedFileBase fileImage,
                             HttpPostedFileBase fileDinhKem,
                             string val_TenKhoaHoc,
                             string val_PhanLoaiBaiHoc,
                             string val_NoiDung,
                             string val_IdLoTrinhHoc)
        {
            try
            {
                string fileLink = null;
                string filePath = null;
                if (fileDinhKem != null && !string.IsNullOrEmpty(fileDinhKem.FileName))
                {
                    string fileExtension = Path.GetExtension(fileDinhKem.FileName).ToLower();
                    var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" }; // Dữ liệu file hợp lệ
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        TempDataHelper.SetTempData(this, "File đính kèm không hợp lệ. Chỉ cho phép các file PDF, DOCX, XLSX.", "error");
                        return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
                    }
                    var folderName = config_UrlSave;
                    var serverFolderPath = Server.MapPath(folderName);
                    if (!Directory.Exists(serverFolderPath))
                    {
                        Directory.CreateDirectory(serverFolderPath);
                    }

                    string fileNameWithoutAccent = TempDataHelper.ChuyenTiengVietKhongDau(fileDinhKem.FileName.Split('.')[0]).Replace(" ", "");
                    string dt = DateTime.Now.ToString("ddMMyyhhmmss");
                    var fileName = $"{fileNameWithoutAccent}_{dt}{fileExtension}";
                    filePath = Path.Combine(serverFolderPath, fileName);
                    fileLink = Url.Content($"{folderName}/{fileName}");
                    fileDinhKem.SaveAs(filePath);
                }
                else
                {
                    TempDataHelper.SetTempData(this, "Không có file đính kèm.", "info");
                }

                var imgPath = string.Empty;
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    var imgFileName = Guid.NewGuid() + Path.GetExtension(fileImage.FileName);
                    var imgSavePath = Server.MapPath("~/Update/" + imgFileName);
                    fileImage.SaveAs(imgSavePath);
                    imgPath = $"/Update/{imgFileName}";
                }
                var khoahocnew = new DmBaiHoc
                {
                    Id = Guid.NewGuid().ToString(),
                    TenBaiHoc = val_TenKhoaHoc?.Trim(),
                    IdPhanMuc = val_PhanLoaiBaiHoc?.Trim(),
                    NoiDung = val_NoiDung?.Trim(),
                    IdLoTrinhHoc = val_IdLoTrinhHoc?.Trim(),
                    FileLink = fileLink,
                    FilePath = filePath,
                    ImgLink = imgPath
                };
                context.DmBaiHoc.Add(khoahocnew);
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm bài học đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
        }


        // GET: Admin/quan_ly_bai_hoc_khoa_hoc/cap_nhat/{id}
        public ActionResult cap_nhat(string id)
        {
            var khoahoc = context?.DmBaiHoc?.FirstOrDefault(x => x.Id == id);
            if (khoahoc == null)
            {
                TempDataHelper.SetTempData(this, "Bài học không tồn tại.", "error");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
            var listLoaiKhoaHoc = context?.HtPhanMuc?.Where(x => x.LoaiPhanMuc == 2)
                                                     .ToList() ?? new List<HtPhanMuc>();
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            ViewBag.listLoTrinh = context?.LoTrinhHoc?.ToList() ?? new List<LoTrinhHoc>();
            ViewBag.Course = khoahoc;
            return View();
        }

        public ActionResult DownloadFile(string id)
        {
            try
            {
                var khoahoc = context?.DmBaiHoc?.FirstOrDefault(x => x.Id == id);

                if (khoahoc == null)
                {
                    TempDataHelper.SetTempData(this, "Bài học không tồn tại.", "error");
                    return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
                }

                string filePath = khoahoc.FilePath;
                if (!System.IO.File.Exists(filePath))
                {
                    TempDataHelper.SetTempData(this, "Không tìm thấy file.", "error");
                    return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
                }
                string fileName = Path.GetFileName(filePath);

                return File(filePath, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi khi tải file: {ex.Message}", "error");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
        }

        [HttpPost]
        public ActionResult XoaFile(string Id)
        {
            var course = context.DmBaiHoc.Find(Id); // Tìm bài học theo ID

            if (course != null && !string.IsNullOrEmpty(course.FileLink))
            {
                course.FileLink = null;
                course.FilePath = null;
                context.SaveChanges();
            }

            return Json(new { success = true });
        }

        // POST: Admin/quan_ly_bai_hoc_khoa_hoc/cap_nhat/{id}
        [HttpPost]
        public ActionResult cap_nhat(string id, HttpPostedFileBase fileImage,
                              HttpPostedFileBase fileDinhKem,
                              string val_TenKhoaHoc,
                              string val_PhanLoaiBaiHoc,
                              string val_NoiDung,
                              string val_IdLoTrinhHoc)
        {
            try
            {
                // Tìm kiếm bài học theo ID
                var khoahoc = context?.DmBaiHoc?.FirstOrDefault(x => x.Id == id);
                if (khoahoc == null)
                {
                    TempDataHelper.SetTempData(this, "Bài học không tồn tại.", "error");
                    return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
                }

                // Cập nhật các thông tin không liên quan đến file
                khoahoc.TenBaiHoc = val_TenKhoaHoc?.Trim();
                khoahoc.IdPhanMuc = val_PhanLoaiBaiHoc?.Trim();
                khoahoc.NoiDung = val_NoiDung?.Trim();
                khoahoc.IdLoTrinhHoc = val_IdLoTrinhHoc?.Trim();

                // Cập nhật file đính kèm nếu có
                if (fileDinhKem != null && fileDinhKem.ContentLength > 0)
                {
                    // Kiểm tra và xử lý file đính kèm
                    var folderName = config_UrlSave;
                    var serverFolderPath = Server.MapPath(folderName);
                    if (!Directory.Exists(serverFolderPath))
                    {
                        Directory.CreateDirectory(serverFolderPath);
                    }

                    // Mã hóa tên file và xử lý file đính kèm
                    var encryptedFileName = SecurityService.EncryptPassword(fileDinhKem.FileName);
                    var fileExtension = Path.GetExtension(fileDinhKem.FileName).ToLower();
                    var fileName = $"{encryptedFileName}{fileExtension}";
                    var filePath = Path.Combine(serverFolderPath, fileName);
                    var fileLink = Url.Content($"{folderName}{fileName}");
                    fileDinhKem.SaveAs(filePath);

                    // Cập nhật thông tin file trong bài học
                    khoahoc.FileLink = fileLink;
                    khoahoc.FilePath = filePath;
                }

                // Cập nhật hình ảnh nếu có
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    var imgFileName = Guid.NewGuid() + Path.GetExtension(fileImage.FileName);
                    var imgSavePath = Server.MapPath("~/Update/" + imgFileName);
                    fileImage.SaveAs(imgSavePath);
                    khoahoc.ImgLink = $"/Update/{imgFileName}";
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                // Thông báo thành công
                TempDataHelper.SetTempData(this, "Cập nhật thành công!", "success");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                TempDataHelper.SetTempData(this, $"Cập nhật bài học đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
        }

        public ActionResult xoa(string id)
        {
            try
            {
                var baihoc = context.DmBaiHoc.FirstOrDefault(x => x.Id == id);
                context.DmBaiHoc.Remove(baihoc);
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Xóa thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình xóa! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
        }

        public ActionResult chi_tiet(string id)
        {
            var baihoc = context.DmBaiHoc.AsEnumerable().FirstOrDefault(x => x.Id == id);
            if (baihoc == null)
            {
                TempDataHelper.SetTempData(this, "Không tìm thấy bài học!", "error");
                return RedirectToAction("Index", "quan_ly_bai_hoc_khoa_hoc");
            }
            ViewBag.baihoc = baihoc;
            var listLoaiKhoaHoc = context?.HtPhanMuc?.FirstOrDefault(x => x.Id == baihoc.IdPhanMuc)
                                                     .TenPhanMuc
                                                     ?? "Chưa phân loại";
            ViewBag.listLoaiKhoaHoc = listLoaiKhoaHoc;
            ViewBag.TenLoTrinh = "";
            ViewBag.TenKhoaHoc = "";
        var idLoTrinhHoc = context?.LoTrinhHoc?.FirstOrDefault(x => x.Id == baihoc.IdLoTrinhHoc);
            if(idLoTrinhHoc != null)
            {
                ViewBag.TenLoTrinh = idLoTrinhHoc.TenLoTrinh;
                ViewBag.TenKhoaHoc = context?.DmKhoaHoc?.FirstOrDefault(x => x.Id == idLoTrinhHoc.IdKhoaHoc)?.TenKhoaHoc;
            }    
            return View();
        }
    }
}