using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class Humidity
    {
        [Key]
        public int Hum_ID { get; set; }
        public int Company_ID { get; set; }
        public string Hum_Cod { get; set; }
        public decimal Hum_FirstWeig { get; set; }
        public decimal Hum_EndWeig { get; set; }
        public decimal Hum_PorcH2O { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; } 
        public string Hum_Status { get; set; }
    }
}
