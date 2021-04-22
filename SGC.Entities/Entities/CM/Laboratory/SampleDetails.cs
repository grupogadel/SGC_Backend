using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class SampleDetails
    {
        [Key]
        public int SampD_ID { get; set; }
        public int SampH_ID { get; set; }   
        public int? LeyMH_ID { get; set; }
        public int? ConsuH_ID { get; set; }
        public int? RecovH_ID { get; set; }
        public string SampD_NO { get; set; }
        public int LabProcTyp_ID { get; set; }
        public int AnalType_ID { get; set; }
        public int SampOrig_ID { get; set; }
        public int MatType_ID { get; set; }
        public int MinFrom_ID { get; set; }
        public decimal SampD_Weight { get; set; }
        public DateTime? SampD_RecLab_Date { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampD_Status { get; set; }
        public virtual LabProcessType LabProcessType { get; set; }
        public virtual AnalisysType AnalisysType { get; set; }
        public virtual SampleOrigin SampleOrigin { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public virtual MineralFrom MineralFrom { get; set; }

    }
}
