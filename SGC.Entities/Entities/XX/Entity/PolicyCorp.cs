using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class PolicyCorp
    {
        [Key]
        public int PolCorp_ID { get; set; }
        public int Company_ID { get; set; }
        public string PolCorp_Cod { get; set; }
        public decimal PolCorp_Value1 { get; set; }
        public decimal? PolCorp_Value2 { get; set; }
        public string PolCorp_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string PolCorp_Status { get; set; }
    }
}
