using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial.Laboratory
{
    public class AnalisysType
    {
        public int? AnalType_ID { get; set; }
        public string AnalType_Cod { get; set; }
        public string AnalType_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string AnalType_Status { get; set; }
    }
}
