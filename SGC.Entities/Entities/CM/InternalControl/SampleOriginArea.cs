using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl
{
    public class SampleOriginArea
    {
        [Key]
       
        public string SampOrig_AreaCod { get; set; }
        public string SampOrig_Area { get; set; }


    }
}
