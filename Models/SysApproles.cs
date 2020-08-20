using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysApproles
    {
        public SysApproles()
        {
            SysRolewithfunctions = new HashSet<SysRolewithfunctions>();
            SysUserandroles = new HashSet<SysUserandroles>();
        }

        public string Roleid { get; set; }
        public string Rolename { get; set; }
        public string Description { get; set; }
        public string Customerid { get; set; }
        public string Moduleid { get; set; }
        public decimal? Isactive { get; set; }
        public decimal? Isdelete { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createddate { get; set; }
        public string Updateduser { get; set; }
        public DateTime? Updateddate { get; set; }

        public virtual SysAppusers CreateuserNavigation { get; set; }
        public virtual SysCustomer Customer { get; set; }
        public virtual SysApplications SysApplications { get; set; }
        public virtual ICollection<SysRolewithfunctions> SysRolewithfunctions { get; set; }
        public virtual ICollection<SysUserandroles> SysUserandroles { get; set; }
    }
}
