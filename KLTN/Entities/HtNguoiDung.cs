using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class HtNguoiDung
    {
        public string Id { get; set; }
        public string TenDangNhap { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public int? Sdt { get; set; }
        public int? GioiTinh { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? TinhTrang { get; set; }
        public string IdNhomQuyen { get; set; }
        public string HoVaTen { get; set; }

        public virtual HtNhomQuyen IdNhomQuyenNavigation { get; set; }
    }
}
