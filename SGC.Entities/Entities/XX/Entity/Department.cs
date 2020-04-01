using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Department
    {
        public int Depa_ID { get; set; }
        public int? Region_ID { get; set; }
        public string Depa_Cod { get; set; }
        public string Depa_Name { get; set; }
        public string Depa_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Depa_Status { get; set; }
    }
}
