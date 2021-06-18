using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.Commercial.SampleReferential
{
    public class SampleDetailsReferential
    {
        [Key]
        public int SampD_ID { get; set; }
        public int SampH_ID { get; set; }
        public int LeyMH_ID { get; set; }
        public decimal? LeyMH_FinishAu { get; set; }
        public decimal? LeyMH_FinishAg { get; set; }
        public string SampD_NO { get; set; }
        public int LabProcTyp_ID { get; set; }
        public string LabProcTyp_Name { get; set; }
        public string LabProcTyp_Desc { get; set; }
        public int AnalType_ID { get; set; }
        public string AnalType_Desc { get; set; }
        public int SampOrig_ID { get; set; }
        public string SampOrig_Cod { get; set; }
        public string SampOrig_Desc { get; set; }
        public string SampOrig_AreaDesc { get; set; }
        public int MatType_ID { get; set; }
        public string MatType_Cod { get; set; }
        public string MatType_Name { get; set; }
        public decimal SampD_Weight { get; set; }
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampD_Status { get; set; }
    }
}
