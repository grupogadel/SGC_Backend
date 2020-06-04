using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception.Sampling
{
    public class SampleDetailsCommercial
    {
        [Key]
        public int SampD_ID { get; set; }
        public int SampH_ID { get; set; }
		public string SampD_NO { get; set; }
        public int LabProcTyp_ID { get; set; }
        public int AnalType_ID { get; set; }
        public int SampOrig_ID { get; set; }
        public int MatType_ID { get; set; }
        public decimal SampD_Weight { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampD_Status { get; set; }
        public LabProcessType LabProcessTypes { get; set; }
        public AnalisysType AnalisysTypes { get; set; }
        public SampleOrigin SampleOrigins { get; set; }
        public MaterialType MaterialTypes { get; set; }
    }
}
