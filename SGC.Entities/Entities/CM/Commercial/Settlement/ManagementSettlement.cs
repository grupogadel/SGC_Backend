using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Settlement
{
    public class ManagementSettlement
    {
        public int SampH_ID { get; set; }
        public int? BatchM_ID { get; set; }
        public int Scales_ID { get; set; }
        public int? Hum_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        public decimal? BatchM_TMHInt { get; set; }
        public decimal? BatchM_PorHumInt { get; set; }
        public decimal? BatchM_TMSHist { get; set; }
        public decimal? BatchM_TMSInt { get; set; }
        public decimal? BatchM_LeyInt { get; set; }
        public decimal? BatchM_RecovInt { get; set; }
        public decimal? BatchM_MaquilaInt { get; set; }
        public decimal? BatchM_ConsumeInt { get; set; }
        public decimal? BatchM_ExpAdmInt { get; set; }
        public decimal? BatchM_ExpLabInt { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string BatchM_Status { get; set; }
        public int? LeyMH_ID { get; set; }
        public int? RecovH_ID { get; set; }
        public int? ConsuH_ID { get; set; }
        public int Vendor_ID { get; set; }
        public DateTime Scales_DateInp { get; set; }
        public decimal Scales_TMH { get; set; }
        public int Orig_ID { get; set; }
        public int Collec_ID { get; set; }
        public decimal Hum_PorcH2O { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Orig_Name { get; set; }
        public string Collec_Name { get; set; }
        public decimal LeyMH_FinishAu { get; set; }
        public decimal LeyMH_FinishAg { get; set; }
        public decimal? ConsuH_ReacNaCN { get; set; }
        public decimal? ConsuH_ReacNaOH { get; set; }
        public decimal? ConsuH_CuPorc { get; set; }
        public decimal? RecovH_AuRecovCalc { get; set; }
        public decimal? RecovH_AgRecovCalc { get; set; }
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
        public decimal? Cond_RecovAu_Estim { get; set; }
        public decimal? Cond_MaquilaAu_Estim { get; set; }
        public decimal? Cond_ConsuAu_Estim { get; set; }
        public decimal? Cond_ExpAdmin_Estim { get; set; }
        public decimal? Cond_ExpLab { get; set; }
        public decimal? Cond_MaquilaAg { get; set; }
    }
}
