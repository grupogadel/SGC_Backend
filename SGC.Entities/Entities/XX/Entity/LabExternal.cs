using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Entity
{
    public class LabExternal
    {
        [Key]
        public int LabExt_ID { get; set; }
        public int Company_ID { get; set; }
        public int LabExt_Cod { get; set; }
        public bool LabExt_Authorized { get; set; }
        public string LabExt_Name { get; set; }
        public string LabExt_Address { get; set; }
        public string LabExt_City { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LabExt_Status { get; set; }
    }
}
