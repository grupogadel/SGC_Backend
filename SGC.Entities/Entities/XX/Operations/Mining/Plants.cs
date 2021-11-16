using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class Plants
    {
        public int Plant_ID { get; set; }
        public int Company_ID { get; set; }
        public int Plant_Cod { get; set; }
        public string Plant_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Plant_Status { get; set; }
    }
}
