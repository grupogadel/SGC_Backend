using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlHeadOperational
    {
        [Key]
        public int IntCtrlH_ID { get; set; }
        public int SampH_ID { get; set; }
        public int Company_ID { get; set; }
        public int IntCtrlH_Current_Detail { get; set; }
        public int SampH_Current_Detail { get; set; }
	    public string SampH_NO { get; set; }
	    public string SampH_Refer { get; set; }
	    public string SampH_Desc { get; set; }
	    public int SampOrig_ID { get; set; }
        public string SampOrig_Desc { get; set; }
	    public string SampOrig_AreaDesc { get; set; }
        public int AnalType_ID { get; set; }
        public string AnalType_Desc { get; set; }
	    public int LabProcTyp_ID { get; set; }
        public string LabProcTyp_Name { get; set; }
	    public int MatType_ID { get; set; }
        public string MatType_Name { get; set; }
	    public decimal SampD_Weight { get; set; }
        public DateTime SampD_Date { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string IntCtrlH_Status { get; set; }
	    public decimal? LeyMH_FinishAu { get; set; }
	    public string SampH_Status_Cod { get; set; }
        public List<InternalCtrlDetails> InternalCtrlDetailss { get; set; }
        public List<InternalCtrlDetailsLeyM> InternalCtrlDetailsLeyMs { get; set; }
        public List<InternalCtrlDetailsConsume> InternalCtrlDetailsConsumes { get; set; }
        public List<InternalCtrlDetailsRecovery> InternalCtrlDetailsRecoverys { get; set; }
        public InternalCtrlHeadOperational()
        {
            InternalCtrlDetailss = new List<InternalCtrlDetails>();
            InternalCtrlDetailsLeyMs = new List<InternalCtrlDetailsLeyM>();
            InternalCtrlDetailsConsumes = new List<InternalCtrlDetailsConsume>();
            InternalCtrlDetailsRecoverys = new List<InternalCtrlDetailsRecovery>();
        }
    }
}
