using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class Module
    {
        [Key]
        public int Module_ID { get; set; }
        public string Module_Cod { get; set; }
        public int? Module_Father { get; set; }
        public string Module_Name { get; set; }
        public string Module_Desc { get; set; }
        public int? Module_Level { get; set; }
		public string Module_FatherName { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Module_Status { get; set; }
    }
}
