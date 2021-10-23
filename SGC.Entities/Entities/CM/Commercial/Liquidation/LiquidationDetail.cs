using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Liquidation
{
    public class LiquidationDetail
    {
        public int? LiquiD_ID { get; set; }
        public int? LiquiH_ID { get; set; }
        public decimal? LiquiD_TMH { get; set; }
        public decimal? LiquiD_PorHum { get; set; }
        public decimal? LiquiD_TMS { get; set; }
        public decimal? LiquiD_Recov { get; set; }
        public decimal? LiquiD_Ley { get; set; }
        public decimal? LiquiD_PriceInt { get; set; }
        public decimal? LiquiD_MarginPI { get; set; }
        public decimal? LiquiD_Maquila { get; set; }
        public decimal? LiquiD_ConsuCN { get; set; }
        public decimal? LiquiD_ExpAdm { get; set; }
        public decimal? LiquiD_UnitPrec { get; set; }
        public decimal? LiquiD_TotLiq { get; set; }
        public decimal? LiquiD_PorcBrutMarg { get; set; }
        public decimal? LiquiD_ImpBrutMarg { get; set; }
        public string LiquiD_Mineral { get; set; }
        public string LiquiD_DataLine { get; set; }
        public decimal? LiquiD_TMHInitial { get; set; }
        public decimal? LiquiD_PorHumInitial { get; set; }
        public decimal? LiquiD_LeyInitial { get; set; }
        public decimal? LiquiD_RecovInitial { get; set; }
        public decimal? LiquiD_MarginPIInitial { get; set; }
        public decimal? LiquiD_MaquilaInitial { get; set; }
        public decimal? LiquiD_ConsuCNInitial { get; set; }
        public decimal? LiquiD_ExpAdmInitial { get; set; }
        public int? CompPago_ID { get; set; }
        public string LiquiD_InvSerie { get; set; }
        public string LiquiD_InvNO { get; set; }
        public DateTime? LiquiD_InvDate { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LiquiD_Status { get; set; }
    }
}
