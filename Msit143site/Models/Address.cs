﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Msit143site.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string SiteId { get; set; }
        public string Road { get; set; }
    }
}