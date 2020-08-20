using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysCustomer
    {
        public SysCustomer()
        {
            SysApplications = new HashSet<SysApplications>();
            SysApproles = new HashSet<SysApproles>();
            SysAppusers = new HashSet<SysAppusers>();
            SysBranch = new HashSet<SysBranch>();
        }

        public string Customerid { get; set; }
        public string Customercode { get; set; }
        public string Customername { get; set; }
        public string Diachi { get; set; }
        public string Syt { get; set; }
        public string Dienthoai { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Provinceid { get; set; }
        public string Districtid { get; set; }
        public decimal? Createduser { get; set; }
        public DateTime? Createddate { get; set; }
        public decimal? Updateduser { get; set; }
        public DateTime? Updateddate { get; set; }

        public virtual ICollection<SysApplications> SysApplications { get; set; }
        public virtual ICollection<SysApproles> SysApproles { get; set; }
        public virtual ICollection<SysAppusers> SysAppusers { get; set; }
        public virtual ICollection<SysBranch> SysBranch { get; set; }
    }
}
