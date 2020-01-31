using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.BatchMineral
{
    public class Origin
    {
        public int Orig_ID { get; set; }
        public string Orig_Date { get; set; }
        public int Zone_ID { get; set; }
        public string Orig_Cod { get; set; }
        public string Orig_Name { get; set; }
        public string Orig_Desc { get; set; }
        public string Orig_Address { get; set; }
        public string Orig_Reference { get; set; }
        public string Orig_Coordinates { get; set; }
        public string Orig_Status { get; set; }

        public Zone zone { get; set; }
    }
}
