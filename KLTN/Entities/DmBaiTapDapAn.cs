﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class DmBaiTapDapAn
    {
        public string Id { get; set; }
        public string IdBaiTap { get; set; }
        public string NoiDung { get; set; }
        public int? KetQua { get; set; }

        public virtual DmBaiTap IdBaiTapNavigation { get; set; }
    }
}
