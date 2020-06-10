using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class MetricSetting
    {
        public int MetSet_ID { get; set; }
        public int Company_ID { get; set; }
        public string MetSet_Cod { get; set; }
        public decimal MetSet_Value { get; set; }
        public string MetSet_Desc { get; set; }
        public string MetSet_From { get; set; }
        public string MetSet_To { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string MetSet_Status { get; set; }
    }
}
