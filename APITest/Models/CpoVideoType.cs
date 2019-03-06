using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoVideoType
    {
        public CpoVideoType()
        {
            CpoRequestTranscode = new HashSet<CpoRequestTranscode>();
        }

        public int IdvideoType { get; set; }
        public string VideoTypeKey { get; set; }
        public string VideoTypeDescription { get; set; }
        public int? IdvideoFormat { get; set; }

        public virtual CpoVideoFormat IdvideoFormatNavigation { get; set; }
        public virtual ICollection<CpoRequestTranscode> CpoRequestTranscode { get; set; }
    }
}
