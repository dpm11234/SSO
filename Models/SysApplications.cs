using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysApplications
    {
        public SysApplications()
        {
            SysAppfunctions = new HashSet<SysAppfunctions>();
            SysApproles = new HashSet<SysApproles>();
        }

        public string Moduleid { get; set; }
        public string Modulecode { get; set; }
        public string Modulename { get; set; }
        public string Customerid { get; set; }
        public string Currentversion { get; set; }
        public decimal? Isactive { get; set; }
        public decimal? Isdelete { get; set; }
        public DateTime? Createddate { get; set; }
        public string ParentModule { get; set; }
        public string FileVersion { get; set; }

        public virtual SysCustomer Customer { get; set; }
        public virtual ICollection<SysAppfunctions> SysAppfunctions { get; set; }
        public virtual ICollection<SysApproles> SysApproles { get; set; }
    }
}
