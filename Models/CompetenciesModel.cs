using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orbit.Models
{
    public class CompetenciesModel
    {
        public int ID { get; set; }
        public int Perfromance { get; set; }
        public string PerfromanceType { get; set; }
        public string CompetenciesName { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Cby { get; set; } 
        public string Uby { get; set; }
    }
}