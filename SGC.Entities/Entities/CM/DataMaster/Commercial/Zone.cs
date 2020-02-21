using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Zone
    {
        [Key]
        public int Zone_ID { get; set; }
        public string Zone_Cod { get; set; }
        public int Dist_ID { get; set; }
        public string Zone_Name { get; set; }
        public string Zone_Desc { get; set; }
        public string Zone_Status { get; set; }
        //public virtual ICollection<Origin> Origins { get; set; }
    }
}
