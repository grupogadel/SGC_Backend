using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlDetails
    {
        [Key]
        public int IntCtrlD_ID { get; set; }
        public int IntCtrlH_ID { get; set; }
        public int LabExt_ID { get; set; }
        public string LabExt_Name { get; set; }
	    public decimal? IntCtrlD_PolCorp { get; set; }
        public int LabProcTyp_ID { get; set; }
        public string LabProcTyp_Name { get; set; }
        public string LabProcTyp_Desc { get; set; }
        public int AnalType_ID { get; set; }
        public string AnalType_Desc { get; set; }
        public int SampOrig_ID { get; set; }
        public string SampOrig_Cod { get; set; }
        public string SampOrig_AreaDesc { get; set; }
        public string SampOrig_Desc { get; set; }
        public string IntCtrlD_LoteNew { get; set; }
        public DateTime? IntCtrlD_Process_Date { get; set; }
        public string IntCtrlD_SubLoteNew { get; set; }
        public decimal? IntCtrlD_SampWeig { get; set; }
        public DateTime? IntCtrlD_Puruna_Date { get; set; }
        public decimal? IntCtrlD_LeyAu_Puru { get; set; }
        public decimal? IntCtrlD_ConsuNaCN_Puru { get; set; }
        public decimal? IntCtrlD_ConsuNaOH_Puru { get; set; }
        public decimal? IntCtrlD_Recov_Puru { get; set; }
        public string IntCtrlD_AnalInf_NO { get; set; }
        public DateTime? IntCtrlD_AnalInf_Date { get; set; }
        public string IntCtrlD_AnalType_LExt { get; set; }
        public decimal? IntCtrlD_LeyAu_LExt { get; set; }
        public decimal? IntCtrlD_LeyAg_LExt { get; set; }
        public decimal? IntCtlD_NaCN_LExt { get; set; }
        public decimal? IntCtlD_NaOH_LExt { get; set; }
        public decimal? IntCtrlD_RecovAu_LExt { get; set; }
        public decimal? IntCtrlD_RecovAg_LExt { get; set; }
        public string IntCtrlD_Status_Var { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string IntCtrlD_Status { get; set; }

    }
}
