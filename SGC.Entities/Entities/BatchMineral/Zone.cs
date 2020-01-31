using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.BatchMineral
{
    public class Zone
    {
        public int Zone_ID { get; set; }
        public string District_ID { get; set; }
        public String Zone_Cod { get; set; }
        public String Zone_Name { get; set; }
        public String Zone_Desc { get; set; }
        public String Creation_User { get; set; }
        public String Creation_Date { get; set; }
        public String Modified_User { get; set; }
        public String Modified_Date { get; set; }

        public ICollection<Origin>origins { get; set; }

    }
}
