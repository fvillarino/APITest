using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public partial class CpoProcess
    {
        public string ProcessName { get; set; }
        public DateTime ProcessFirstStart { get; set; }
        public string ProcessStatus { get; set; }
    }
}
