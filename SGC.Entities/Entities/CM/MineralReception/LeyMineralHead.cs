using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class LeyMineralHead
    {
        public int LeyMH_ID { get; set; }
        public int? SampH_ID { get; set; }
        public int Company_ID { get; set; }
        public int LabProcTyp_ID { get; set; }
        public int AnalType_ID { get; set; }
        public DateTime LeyMH_ProcDate { get; set; }
        public virtual LeyMineralDetail LeyMineralDetails { get; set; }
    }
}
