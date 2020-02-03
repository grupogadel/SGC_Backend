using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.View.Comercial.Maestro
{
    public class CollectorView
    {
        public int Quota_ID { get; set; }
        public int Acopi_ID { get; set; }
        public int Period_ID { get; set; }
        public double Quota_TM_Est { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public int Quota_Status { get; set; }
    }
}
