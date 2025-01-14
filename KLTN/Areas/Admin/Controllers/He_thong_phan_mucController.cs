using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KLTN.Entities;
using KLTN.Models;
using Microsoft.EntityFrameworkCore;

namespace KLTN.Areas.Admin.Controllers
{
    public class He_thong_phan_mucController : Controller
    {
        private readonly WEB_TIENG_ANHContext context;

        public He_thong_phan_mucController()
        {
            context = new WEB_TIENG_ANHContext();
        }

        // GET: Admin/He_thong_phan_muc
        public ActionResult Index()
        {
            var listsp = context?.HtPhanMuc?.ToList() ?? new List<HtPhanMuc>();

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
            return View();
        }

        // GET: Admin/He_thong_phan_muc/them_moi
        public ActionResult them_moi()
        {
            return View();
        }
        // POST: Admin/He_thong_phan_muc/them_moi
        [HttpPost]
        public ActionResult xl_them_moi(string val_He_thong_phan_muc, string val_mo_ta, string val_PhanLoai)
        {
            try
            {
                var HtPhanMucnew = new HtPhanMuc
                {
                    Id = Guid.NewGuid().ToString(),
                    MoTa = val_mo_ta,
                    TenPhanMuc = val_He_thong_phan_muc,
                    LoaiPhanMuc = int.Parse(val_PhanLoai)
                };

                context?.HtPhanMuc.Add(HtPhanMucnew);
                context?.SaveChanges();

                TempDataHelper.SetTempData(this, "Thêm mới thành công!", "success");
                return RedirectToAction("Index", "He_thong_phan_muc");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Thêm khóa học đã xảy ra lỗi! - {ex.Message}", "error");
                return RedirectToAction("Index", "He_thong_phan_muc");
            }
        }
        // GET: Admin/He_thong_phan_muc/cap_nhat
        public ActionResult cap_nhat(string id)
        {
            var HtPhanMuc = context.HtPhanMuc.AsEnumerable().FirstOrDefault(x => x.Id == id);
            if (HtPhanMuc == null)
            {
                TempDataHelper.SetTempData(this, "Không tìm thấy loại khóa học!", "error");
                return RedirectToAction("Index", "He_thong_phan_muc");
            }
            ViewBag.He_thong_phan_muc = HtPhanMuc;
            return View();
        }
        // POST: Admin/He_thong_phan_muc/cap_nhat
        [HttpPost]
        public ActionResult xl_cap_nhat(string id, string val_He_thong_phan_muc, string val_mo_ta)
        {
            try
            {
                var HtPhanMuc = context.HtPhanMuc.FirstOrDefault(x => x.Id == id);
                if (HtPhanMuc == null)
                {
                    TempDataHelper.SetTempData(this, "Loại khóa học không tồn tại!", "error");
                    return RedirectToAction("Index", "He_thong_phan_muc");
                }
                HtPhanMuc.TenPhanMuc = val_He_thong_phan_muc;
                HtPhanMuc.MoTa = val_mo_ta;
                context.SaveChanges();
                TempDataHelper.SetTempData(this, "Cập nhật thành công!", "success");
            }
            catch (Exception ex)
            {
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình cập nhật! - {ex.Message}", "error");
            }
            return RedirectToAction("Index", "He_thong_phan_muc");
        }

        public async Task<ActionResult> XoaAsync(string id)
        {
            try
            {
                // Kiểm tra HtPhanMuc tồn tại
                var htPhanMuc = await context.HtPhanMuc.FirstOrDefaultAsync(x => x.Id == id);
                if (htPhanMuc == null)
                {
                    TempDataHelper.SetTempData(this, "Không tìm thấy phân mục!", "error");
                    return RedirectToAction("Index", "He_thong_phan_muc");
                }

                // Xóa dữ liệu liên quan dựa trên LoaiPhanMuc
                switch (htPhanMuc.LoaiPhanMuc)
                {
                    case 1:
                        var liskh = await context.DmKhoaHoc.Where(x => x.IdPhanMuc == htPhanMuc.Id).ToListAsync();
                        context.DmKhoaHoc.RemoveRange(liskh);
                        break;

                    case 2:
                        var listbh = await context.DmBaiHoc.Where(x => x.IdPhanMuc == htPhanMuc.Id).ToListAsync();
                        context.DmBaiHoc.RemoveRange(listbh);
                        break;

                    case 3:
                        var lisbt = await context.DmBaiTap.Where(x => x.IdPhanMuc == htPhanMuc.Id).ToListAsync();
                        context.DmBaiTap.RemoveRange(lisbt);
                        break;

                    default:
                        TempDataHelper.SetTempData(this, "Loại phân mục không hợp lệ!", "error");
                        return RedirectToAction("Index", "He_thong_phan_muc");
                }

                // Xóa phân mục chính
                context.HtPhanMuc.Remove(htPhanMuc);
                await context.SaveChangesAsync();

                TempDataHelper.SetTempData(this, "Xóa thành công!", "success");
            }
            catch (Exception ex)
            {
                // Ghi log chi tiết lỗi nếu cần
                TempDataHelper.SetTempData(this, $"Đã xảy ra lỗi trong quá trình xóa! - {ex.Message}", "error");
            }

            return RedirectToAction("Index", "He_thong_phan_muc");
        }
    }
}
