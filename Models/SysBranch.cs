using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysBranch
    {
        public SysBranch()
        {
            SysAppusers = new HashSet<SysAppusers>();
            SysBranchUsers = new HashSet<SysBranchUsers>();
        }

        public string Branchid { get; set; }
        public string Branchname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Customerid { get; set; }
        public string Provinceid { get; set; }
        public string Districtid { get; set; }
        public decimal? Isactive { get; set; }
        public decimal? Isdelete { get; set; }
        public decimal? Createduser { get; set; }
        public DateTime? Createddate { get; set; }
        public decimal? Updateduser { get; set; }
        public DateTime? Updateddate { get; set; }
        public DateTime? Deleteddate { get; set; }

        public virtual SysCustomer Customer { get; set; }
        public virtual ICollection<SysAppusers> SysAppusers { get; set; }
        public virtual ICollection<SysBranchUsers> SysBranchUsers { get; set; }
    }
}
