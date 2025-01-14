using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class LoaiTinTuc
    {
        public LoaiTinTuc()
        {
            TinTuc = new HashSet<TinTuc>();
        }

        public string Id { get; set; }
        public string TieuDe { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<TinTuc> TinTuc { get; set; }
    }
}
