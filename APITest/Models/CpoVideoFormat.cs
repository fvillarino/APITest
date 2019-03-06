using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoVideoFormat
    {
        public CpoVideoFormat()
        {
            CpoVideoType = new HashSet<CpoVideoType>();
        }

        public int IdvideoFormat { get; set; }
        public int? VideoFormatHeight { get; set; }
        public int? VideoFormatWidth { get; set; }
        public int? VideoFormatBitRate { get; set; }
        public string VideoFormatAspectRatio { get; set; }
        public int? VideoFormatAspectX { get; set; }
        public int? VideoFormatAspectY { get; set; }
        public string VideoFormatDescription { get; set; }
        public string VideoFormatFileExtension { get; set; }

        public virtual ICollection<CpoVideoType> CpoVideoType { get; set; }
    }
}
