using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoFeed
    {
        public CpoFeed()
        {
            CpoAppendRequest = new HashSet<CpoAppendRequest>();
        }

        public int Idfeed { get; set; }
        public string FeedName { get; set; }
        public string FeedOriginalLanguage { get; set; }
        public string FeedLogName { get; set; }
        public string FeedRgxLogName { get; set; }
        public int? IdvideoFormat { get; set; }
        public string FeedRepositoryLog { get; set; }
        public int FeedInetsatId { get; set; }
        public bool FeedEnable { get; set; }
        public bool FeedAutoAppendEnable { get; set; }
        public int FeedAutoAppendDays { get; set; }
        public string FeedExternalId { get; set; }
        public string Divacategory { get; set; }
        public string FeedRegion { get; set; }

        public virtual ICollection<CpoAppendRequest> CpoAppendRequest { get; set; }
    }
}
