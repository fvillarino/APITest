using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoAppendRequest
    {
        public int Idfeed { get; set; }
        public int IdappendStatus { get; set; }
        public DateTime AppendRequestDate { get; set; }
        public int AppendRequestVersion { get; set; }
        public DateTime StatusAppendRequestDate { get; set; }
        public string AppendRequestLogFileName { get; set; }
        public string AppendRequestResponse { get; set; }

        public virtual CpoAppendStatus IdappendStatusNavigation { get; set; }
        public virtual CpoFeed IdfeedNavigation { get; set; }
    }
}
