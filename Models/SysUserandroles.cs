using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysUserandroles
    {
        public int Userid { get; set; }
        public string Roleid { get; set; }

        public virtual SysApproles Role { get; set; }
        public virtual SysAppusers User { get; set; }
    }
}
