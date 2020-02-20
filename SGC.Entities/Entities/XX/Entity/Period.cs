using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Period
    {
        [Key]
        public int Period_ID { get; set; }
        public string Period_Cod { get; set; }
        public string Period_NO { get; set; }
        public int Company_ID { get; set; }
        public string Period_Year { get; set; }
        public DateTime Period_Date_Start { get; set; }
        public DateTime Period_Date_End { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Period_Status { get; set; }
    }
}
