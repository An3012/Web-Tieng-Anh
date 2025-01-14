using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class HtNhomQuyen
    {
        public HtNhomQuyen()
        {
            HtNguoiDung = new HashSet<HtNguoiDung>();
        }

        public string Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<HtNguoiDung> HtNguoiDung { get; set; }
    }
}
