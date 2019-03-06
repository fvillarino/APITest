using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoAppendStatus
    {
        public CpoAppendStatus()
        {
            CpoAppendRequest = new HashSet<CpoAppendRequest>();
        }

        public int IdappendStatus { get; set; }
        public string AppendStatusName { get; set; }
        public string AppendStatusDescription { get; set; }
        public string AppendStatusFriendlyName { get; set; }

        public virtual ICollection<CpoAppendRequest> CpoAppendRequest { get; set; }
    }
}
