using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.OP.PlantCIP
{
    public class GrindingHead
    {
        public int GrindH_ID { get; set; }
        public int CampH_ID { get; set; }
        public int Circuit_ID { get; set; }
        public int Mill_ID { get; set; }
        public DateTime GrindH_Date { get; set; }
        public decimal GrindH_GravEsp_GE { get; set; }
        public decimal GrindH_DensAver { get; set; }
        public decimal GrindH_SolidosPor { get; set; }
        public decimal GrindH_WeightS { get; set; }
        public decimal GrindH_DIL { get; set; }
        public decimal GrindH_VOLSOL { get; set; }
        public decimal GrindH_Cola_Mesh { get; set; }
        public string GrindH_Operator_User { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string GrindH_Status { get; set; }

        //Campaign
        public string CampH_NO { get; set; }        
    }
}
