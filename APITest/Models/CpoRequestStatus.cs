using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestStatus
    {
        public CpoRequestStatus()
        {
            CpoRequest = new HashSet<CpoRequest>();
            CpoRequestStatusHistory = new HashSet<CpoRequestStatusHistory>();
        }

        public int IdrequestStatus { get; set; }
        public string RequestStatusName { get; set; }
        public string RequestStatusDescription { get; set; }
        public bool RequestStatusRunning { get; set; }
        public int RequestStatusLogicalOrder { get; set; }

        public virtual ICollection<CpoRequest> CpoRequest { get; set; }
        public virtual ICollection<CpoRequestStatusHistory> CpoRequestStatusHistory { get; set; }
    }
}
