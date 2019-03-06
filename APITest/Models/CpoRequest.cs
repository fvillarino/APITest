using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequest
    {
        public CpoRequest()
        {
            CpoRequestStatusHistory = new HashSet<CpoRequestStatusHistory>();
        }

        public long Idrequest { get; set; }
        public string RequestMaterialId { get; set; }
        public string RequestLongFileId { get; set; }
        public string RequestUser { get; set; }
        public int IdrequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime RequestRequiredDate { get; set; }
        public DateTime RequestStatusDate { get; set; }
        public int IdeventType { get; set; }
        public string RequestComment { get; set; }
        public int? IdrequestType { get; set; }

        public virtual CpoEventType IdeventTypeNavigation { get; set; }
        public virtual CpoRequestStatus IdrequestStatusNavigation { get; set; }
        public virtual CpoRequestType IdrequestTypeNavigation { get; set; }
        public virtual CpoRequestRestore CpoRequestRestore { get; set; }
        public virtual CpoRequestSubtitle CpoRequestSubtitle { get; set; }
        public virtual CpoRequestTranscode CpoRequestTranscode { get; set; }
        public virtual ICollection<CpoRequestStatusHistory> CpoRequestStatusHistory { get; set; }
    }
}
