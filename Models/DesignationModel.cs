using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orbit.Models
{
    public class DesignationModel
    {
        public int ID { get; set; }
        public int Branch { get; set; }
        public string BranchName { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Cby { get; set; }
        public string Uby { get; set; }

    }
}