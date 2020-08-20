using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysAppfunctions
    {
        public SysAppfunctions()
        {
            SysRolewithfunctions = new HashSet<SysRolewithfunctions>();
        }

        public string Functionid { get; set; }
        public string Moduleid { get; set; }
        public string Customerid { get; set; }
        public string Functionname { get; set; }
        public string Description { get; set; }
        public string Functype { get; set; }
        public decimal? Itemlevel { get; set; }
        public string Parentid { get; set; }
        public decimal? Isactive { get; set; }
        public decimal? Isdelete { get; set; }
        public DateTime? Lastdatemodify { get; set; }
        public DateTime? Createddate { get; set; }

        public virtual SysApplications SysApplications { get; set; }
        public virtual ICollection<SysRolewithfunctions> SysRolewithfunctions { get; set; }
    }
}
