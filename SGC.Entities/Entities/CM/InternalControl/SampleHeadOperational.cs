using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl
{
    public class SampleHeadOperational
    {
        [Key]
        public int SampH_ID { get; set; }
        public int Company_ID { get; set; }
        public string SampH_NO { get; set; }    
        public string SampH_Type { get; set; }
        public string SampH_Desc { get; set; }
        public string SampH_Refer { get; set; }
        public string SampOrig_Module { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampH_Status { get; set; }
        public string SampH_Status_Cod { get; set; }
        public virtual SampleDetailsOperational SampleDetailsOperational { get; set; }
    }
}
