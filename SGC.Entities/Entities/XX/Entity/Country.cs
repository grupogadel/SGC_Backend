using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Country
    {
        public int Country_ID { get; set; }
        public string Country_Cod { get; set; }
        public string Country_Name { get; set; }
        public string Country_Desc { get; set; }
        public int? Lenguaje_ID { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Country_Status { get; set; }
    }


}
