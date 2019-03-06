using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoTranscoderInstance
    {
        public CpoTranscoderInstance()
        {
            CpoRequestTranscode = new HashSet<CpoRequestTranscode>();
        }

        public int IdtranscoderInstance { get; set; }
        public string TranscoderInstanceServerName { get; set; }
        public bool? TranscoderInstanceEnable { get; set; }
        public int? Idtranscoder { get; set; }

        public virtual CpoTranscoder IdtranscoderNavigation { get; set; }
        public virtual ICollection<CpoRequestTranscode> CpoRequestTranscode { get; set; }
    }
}
