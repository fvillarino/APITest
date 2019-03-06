using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestSubtitle
    {
        public long Idrequest { get; set; }
        public string RequestLanguage { get; set; }
        public string SubtitleTitle { get; set; }
        public int? SubtitleVersion { get; set; }
        public string SubtitleLanguage { get; set; }
        public string SubtitleCid { get; set; }
        public string SubtitleFileName { get; set; }

        public virtual CpoRequest IdrequestNavigation { get; set; }
    }
}
