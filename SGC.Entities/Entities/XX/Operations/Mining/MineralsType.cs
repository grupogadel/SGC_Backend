using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class MineralsType
    {
        public int MinType_ID { get; set; }
        public int Company_ID { get; set; }
        public string MinType_Cod { get; set; }
        public string MinType_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string MinType_Status { get; set; }
    }


}
