using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlHeadCommercial
    {
        [Key]
        public int IntCtrlH_ID { get; set; }
        public int SampH_ID { get; set; }
        public int Company_ID { get; set; }
        public int IntCtrlH_Current_Detail { get; set; }
        public int BatchM_ID { get; set; }
        public int SampH_Current_Detail { get; set; }
        public int AnalType_ID { get; set; }
        public string AnalType_Desc { get; set; }
        public int Hum_ID { get; set; }
        public decimal Hum_PorcH2O { get; set; }
        public int Scales_ID { get; set; }
        public string Scales_Lote { get; set; }
        public decimal Scales_TMH { get; set; }
        public DateTime Scales_DateInp { get; set; }
        public int MinType_ID { get; set; }
        public string MinType_Desc { get; set; }
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string IntCtrlH_Status { get; set; }
	public decimal? LeyMH_FinishAu { get; set; }
	public string SampH_Status_Cod { get; set; }
        public List<InternalCtrlDetailsCommercial> InternalCtrlDetailsCommercials { get; set; }
        public List<InternalCtrlDetailsLeyM> InternalCtrlDetailsLeyMs { get; set; }
        public List<InternalCtrlDetailsConsume> InternalCtrlDetailsConsumes { get; set; }
        public List<InternalCtrlDetailsRecovery> InternalCtrlDetailsRecoverys { get; set; }
        public InternalCtrlHeadCommercial()
        {
            InternalCtrlDetailsCommercials = new List<InternalCtrlDetailsCommercial>();
            InternalCtrlDetailsLeyMs = new List<InternalCtrlDetailsLeyM>();
            InternalCtrlDetailsConsumes = new List<InternalCtrlDetailsConsume>();
            InternalCtrlDetailsRecoverys = new List<InternalCtrlDetailsRecovery>();
        }
    }
}
