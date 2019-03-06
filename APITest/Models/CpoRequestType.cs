using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestType
    {
        public CpoRequestType()
        {
            CpoRequest = new HashSet<CpoRequest>();
        }

        public int IdrequestType { get; set; }
        public string RequestTypeName { get; set; }

        public virtual ICollection<CpoRequest> CpoRequest { get; set; }
    }
}
