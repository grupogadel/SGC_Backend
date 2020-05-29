using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial
{
    public class CommercialParameters
    {
        public int CommP_ID { get; set; }
        public int Company_ID { get; set; }
        public string CommP_Cod { get; set; }
        public string CommP_Name { get; set; }
        public decimal? CommP_WeigAuPor { get; set; }
        public decimal? CommP_LeyAuQuan { get; set; }
        public decimal? CommP_LeyAgQuan { get; set; }
        public decimal? CommP_HumiAuPor { get; set; }
        public decimal? CommP_HumiAgPor { get; set; }
        public decimal? CommP_RecovAuMin { get; set; }
        public decimal? CommP_RecovAuMax { get; set; }
        public decimal? CommP_MaquilaMin { get; set; }
        public decimal? CommP_MaquilaMax { get; set; }
        public decimal? CommP_ConsuMin { get; set; }
        public decimal? CommP_ConsuMax { get; set; }
        public decimal? CommP_ExpAdm { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string CommP_Status { get; set; }

    }
}
