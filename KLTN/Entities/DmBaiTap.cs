using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class DmBaiTap
    {
        public DmBaiTap()
        {
            DmBaiTapCauHoi = new HashSet<DmBaiTapCauHoi>();
            DmBaiTapDapAn = new HashSet<DmBaiTapDapAn>();
        }

        public string Id { get; set; }
        public string TenBaiTap { get; set; }
        public string IdBaiHoc { get; set; }
        public string IdPhanMuc { get; set; }

        public virtual DmBaiHoc IdPhanMucNavigation { get; set; }
        public virtual ICollection<DmBaiTapCauHoi> DmBaiTapCauHoi { get; set; }
        public virtual ICollection<DmBaiTapDapAn> DmBaiTapDapAn { get; set; }
    }
}
