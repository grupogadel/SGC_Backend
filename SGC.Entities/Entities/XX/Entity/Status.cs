using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Status
    {
        [Key]
        public int Status_ID { get; set; }
        public string Status_Cod { get; set; }
        public string Status_Cod2 { get; set; }
        public string Status_Name { get; set; }
        public string Status_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Status_Status { get; set; }
    }
}
