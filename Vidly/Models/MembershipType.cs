﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpfree { get; set; }
        public byte Duration { get; set; }
        public byte DiscountRate { get; set; }
    }
}