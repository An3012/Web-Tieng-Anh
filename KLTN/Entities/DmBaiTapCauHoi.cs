using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class DmBaiTapCauHoi
    {
        public string Id { get; set; }
        public string IdBaiTap { get; set; }
        public string NoiDung { get; set; }

        public virtual DmBaiTap IdBaiTapNavigation { get; set; }
    }
}
