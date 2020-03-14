using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Finance
{
    public class UnitMeasuare
    {
        [Key]
        public int UM_ID { get; set; }
        public string UM_Cod { get; set; }
        public string UM_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string UM_Status { get; set; }


    }
}
