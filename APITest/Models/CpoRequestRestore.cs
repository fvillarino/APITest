using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestRestore
    {
        public long Idrequest { get; set; }
        public long Divaidrequest { get; set; }
        public int Divapriority { get; set; }
        public string DivarestoreFileName { get; set; }

        public virtual CpoRequest IdrequestNavigation { get; set; }
    }
}
