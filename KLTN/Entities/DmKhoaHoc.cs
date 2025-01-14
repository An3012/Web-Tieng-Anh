using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class DmKhoaHoc
    {
        public DmKhoaHoc()
        {
            LoTrinhHoc = new HashSet<LoTrinhHoc>();
        }

        public string Id { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiCapNhat { get; set; }
        public string ImgLink { get; set; }
        public int? Gia { get; set; }
        public int? GiamGia { get; set; }
        public string MaQuyen { get; set; }
        public string IdPhanMuc { get; set; }
        public int? TinhTrang { get; set; }
        public string TenGiaoVien { get; set; }
        public int? Del { get; set; }

        public virtual ICollection<LoTrinhHoc> LoTrinhHoc { get; set; }
    }
}
