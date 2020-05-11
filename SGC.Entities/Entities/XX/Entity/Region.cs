using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Region
    {
        public int Region_ID { get; set; }
        public int Country_ID { get; set; }
        public string Region_Cod { get; set; }
        public string Region_Name { get; set; }
        public string Region_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Region_Status { get; set; }
        public Country Countrys { get; set; }
    }

}
