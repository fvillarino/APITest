using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoTranscoder
    {
        public CpoTranscoder()
        {
            CpoTranscoderInstance = new HashSet<CpoTranscoderInstance>();
        }

        public int Idtranscoder { get; set; }
        public string TranscoderName { get; set; }
        public bool TranscoderEnable { get; set; }

        public virtual ICollection<CpoTranscoderInstance> CpoTranscoderInstance { get; set; }
    }
}
