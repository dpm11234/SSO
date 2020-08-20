using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysRolewithfunctions
    {
        public string Roleid { get; set; }
        public string Functionid { get; set; }

        public virtual SysAppfunctions Function { get; set; }
        public virtual SysApproles Role { get; set; }
    }
}
