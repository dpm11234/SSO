using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysGroupUser
    {
        public SysGroupUser()
        {
            SysAppusers = new HashSet<SysAppusers>();
        }

        public Int32 Groupid { get; set; }
        public string Groupname { get; set; }

        public virtual ICollection<SysAppusers> SysAppusers { get; set; }
    }
}
