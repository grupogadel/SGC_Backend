using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class AnalysisRequest
    {
        public int AnalReq_ID { get; set; }
        public string AnalReq_Cod { get; set; }
        public string AnalReq_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string AnalReq_Status { get; set; }
    }
}
