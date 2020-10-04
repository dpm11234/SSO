using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysAppusers
    {
        public SysAppusers()
        {
            SysApproles = new HashSet<SysApproles>();
            SysBranchUsers = new HashSet<SysBranchUsers>();
            SysUserandroles = new HashSet<SysUserandroles>();
        }

        public string Userid { get; set; }
        public decimal Id { get; set; }
        public string Customerid { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Passwd { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? Isactive { get; set; }
        public decimal? Isdelete { get; set; }
        public decimal? Islocked { get; set; }
        public DateTime? Lockeddate { get; set; }
        public decimal? Requirechangepassword { get; set; }
        public DateTime? Lastlogindate { get; set; }
        public string Createduser { get; set; }
        public DateTime? Createddate { get; set; }
        public string Lastupdateduser { get; set; }
        public DateTime? Lastupdateddate { get; set; }
        public string Deleteduser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public Int32 Groupid { get; set; }
        public string Defaultbranchid { get; set; }

        public virtual SysCustomer Customer { get; set; }
        public virtual SysBranch Defaultbranch { get; set; }
        public virtual SysGroupUser Group { get; set; }
        public virtual ICollection<SysApproles> SysApproles { get; set; }
        public virtual ICollection<SysBranchUsers> SysBranchUsers { get; set; }
        public virtual ICollection<SysUserandroles> SysUserandroles { get; set; }
    }
}
