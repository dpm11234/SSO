using System;
using System.Collections.Generic;

namespace AuthSSO.Models
{
    public partial class SysBranchUsers
    {
        public string Branchid { get; set; }
        public string Userid { get; set; }

        public virtual SysBranch Branch { get; set; }
        public virtual SysAppusers User { get; set; }
    }
}
