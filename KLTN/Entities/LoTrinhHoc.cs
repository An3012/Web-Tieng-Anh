using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class LoTrinhHoc
    {
        public string Id { get; set; }
        public string TenLoTrinh { get; set; }
        public string IdKhoaHoc { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string NoiDung { get; set; }

        public virtual DmKhoaHoc IdKhoaHocNavigation { get; set; }
    }
}
