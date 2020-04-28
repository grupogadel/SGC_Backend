using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial.Laboratory
{
    public class LabProcessType
    {
        [Key]
        public int LabProcTyp_ID { get; set; }
        public string LabProcTyp_Cod { get; set; }
        public string LabProcTyp_Name { get; set; }
        public string LabProcTyp_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LabProcTyp_Status { get; set; }
    }
}
