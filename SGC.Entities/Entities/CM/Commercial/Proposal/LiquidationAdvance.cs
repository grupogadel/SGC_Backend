using System;

namespace SGC.Entities.Entities.CM.Commercial.Proposal
{
    public class LiquidationAdvance
    {
        public int LiqAdv_ID { get; set; }
        public int LiquiH_ID { get; set; }
        public int AdvanD_ID { get; set; }
        public int BatchM_ID { get; set; }
        public int? Zone_ID { get; set; }
        public string LiqAdv_NO { get; set; }
        public string LiqAdv_DocSerieNO { get; set; }
        public DateTime? LiqAdv_Date { get; set; }
        public decimal LiqAdv_Amount { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LiqAdv_Status { get; set; }
    }
}
