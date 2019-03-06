using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestStatusHistory
    {
        public int IdrequestStatusHistory { get; set; }
        public long Idrequest { get; set; }
        public int IdrequestStatus { get; set; }
        public DateTime RequestStatusDate { get; set; }
        public string RequestStatusHistoryComment { get; set; }
        public string RequestUser { get; set; }

        public virtual CpoRequest IdrequestNavigation { get; set; }
        public virtual CpoRequestStatus IdrequestStatusNavigation { get; set; }
    }
}
