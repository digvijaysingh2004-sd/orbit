﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orbit.Models
{
    public class ExpenseTypeModel
    {
        public int ID { get; set; }
        public string ExpenseType { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }
    }
}