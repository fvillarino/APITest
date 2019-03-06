using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoRequestTranscode
    {
        public long Idrequest { get; set; }
        public string RequestTranscodeFileNameIn { get; set; }
        public string RequestTranscodeFileNameOut { get; set; }
        public string TranscodeIdrequest { get; set; }
        public int? RequestTranscodePriority { get; set; }
        public int? IdtranscoderInstance { get; set; }
        public int? IdvideoType { get; set; }
        public string RequestAudioShuffling { get; set; }
        public bool? IsCropping { get; set; }
        public bool? ClosedCaption { get; set; }
        public long? FileSize { get; set; }
        public string TimecodeIn { get; set; }
        public string MaterialType { get; set; }

        public virtual CpoRequest IdrequestNavigation { get; set; }
        public virtual CpoTranscoderInstance IdtranscoderInstanceNavigation { get; set; }
        public virtual CpoVideoType IdvideoTypeNavigation { get; set; }
    }
}
