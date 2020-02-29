using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class MPeriod
    {
        [Key]
        public int MPeriod_ID { get; set; }
        public string MPeriod_Cod { get; set; }
        public string MPeriod_Name { get; set; }
        public string MPeriod_Name2 { get; set; }
        public string MPeriod_Desc { get; set; }
        public string MPeriod_Month { get; set; }
        public string MPeriod_Status { get; set; }
    }
}
