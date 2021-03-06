using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class BatchMineral
    {
        [Key]
        public int BatchM_ID { get; set; }
        public int Scales_ID { get; set; }
        public int? Hum_ID { get; set; }
        public int? Ruma_ID { get; set; }
        public int? Quota_ID { get; set; }
        public int? LeyMH_ID { get; set; }
        public int Company_ID { get; set; }
        public int Period_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        public string BatchM_SubLote { get; set; }
        public DateTime? BatchM_Retired_Date { get; set; }
        public int? BatchM_TMHInt { get; set; }
        public int? BatchM_PorHumInt { get; set; }
        public decimal? BatchM_TMSHist { get; set; }
        public int? BatchM_TMSInt { get; set; }
        public int? BatchM_LeyInt { get; set; }
        public int? BatchM_RecovInt { get; set; }
        public int? BatchM_MaquilaInt { get; set; }
        public int? BatchM_ConsumeInt { get; set; }
        public int? BatchM_ExpAdmInt { get; set; }
        public int? BatchM_ExpLabInt { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string BatchM_Status { get; set; }
        public virtual Humidity Humiditys { get; set; }
        public virtual Scales Scales { get; set; }
        public virtual LeyMineralHead LeyMineralHeads { get; set; }
        public virtual decimal? LeyMH_FinishAu { get; set; }
        public virtual decimal? LeyMH_FinishAg { get; set; }
        public virtual decimal? ConsuH_ReacNaOH { get; set; }
        public virtual decimal? ConsuH_ReacNaCN { get; set; }
        public virtual decimal? RecovH_AuRecovCalc { get; set; }
        public virtual decimal? RecovH_AgRecovCalc { get; set; }
        public DateTime? Scales_DateInp { get; set; }
        public string Orig_Name { get; set; }
        public string Zone_Name { get; set; }
    }
}
