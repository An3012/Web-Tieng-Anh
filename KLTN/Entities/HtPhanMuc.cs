﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KLTN.Entities
{
    public partial class HtPhanMuc
    {
        public string Id { get; set; }
        public string TenPhanMuc { get; set; }
        public string MoTa { get; set; }
        public int? LoaiPhanMuc { get; set; }
    }
}
