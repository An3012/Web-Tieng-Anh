using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class DmBaiHoc
    {
        public DmBaiHoc()
        {
            DmBaiTap = new HashSet<DmBaiTap>();
        }

        public string Id { get; set; }
        public string IdLoTrinhHoc { get; set; }
        public string TenBaiHoc { get; set; }
        public string NoiDung { get; set; }
        public string ImgLink { get; set; }
        public string FileLink { get; set; }
        public string FilePath { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NguoiTao { get; set; }
        public string IdPhanMuc { get; set; }

        public virtual ICollection<DmBaiTap> DmBaiTap { get; set; }
    }
}
