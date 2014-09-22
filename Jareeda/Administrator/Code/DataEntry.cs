using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administrator.Code
{
    class DataEntry
    {
        public List<Metric> Metrics { get; set; }
        public Titles Title;
        public struct Titles {
            public  string Text;
        }

        public struct Metric {
            public string Value;
        }
    }
}
