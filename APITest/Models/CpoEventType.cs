using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoEventType
    {
        public CpoEventType()
        {
            CpoRequest = new HashSet<CpoRequest>();
        }

        public int IdeventType { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeFriendlyName { get; set; }

        public virtual ICollection<CpoRequest> CpoRequest { get; set; }
    }
}
