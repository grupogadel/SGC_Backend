using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class SampleOriginArea
    {
        [Key]
       
        public string SampOrig_AreaCod { get; set; }
        public string SampOrig_Area { get; set; }


    }
}
