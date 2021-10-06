using System;
using SGC.Entities.Entities.CM.Commercial;
using SGC.Entities.Entities.XX.Commercial;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Liquidation
{
    public class LiquidationHead
    {
        public int? LiquiH_ID { get; set; }
        public int? Cond_ID { get; set; }
        public int? CorpP_ID { get; set; }
        public int? Price_ID { get; set; }
        public int? BatchM_ID { get; set; }
        public int? Company_ID { get; set; }
        public string LiquiH_NO { get; set; }
        public DateTime? LiquiH_DateProc { get; set; }
        public string LiquiH_UserApro { get; set; }
        public DateTime? LiquiH_DateApro { get; set; }
        public decimal? LiquiH_ExpLabVal { get; set; }
        public decimal? LiquiH_ExpLabValInitial { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LiquiH_Status { get; set; }
        public virtual LiquidationDetail LiquidationDetailAu { get; set; }
        public virtual LiquidationDetail LiquidationDetailAg { get; set; }
        public virtual LiquidationDetail LiquidationDetailAuInt { get; set; }
        public virtual LiquidationDetail LiquidationDetailAgInt { get; set; }
        public virtual PriceInternational PriceInternational { get; set; }
        //public virtual CorporationParameters CorporationParameters { get; set; }
    }
}
