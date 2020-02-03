using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.Acopio.Maestro
{
    public class Quota
    {
        public int Quota_ID { get; set; }
        public int Collec_ID { get; set; }
        public int Period_ID { get; set; }
        public double Quota_TM_Est { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Quota_Status { get; set; }
    }
}
