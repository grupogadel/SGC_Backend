using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class BatchMineral
    {
        [Key]
        public int BatchM_ID { get; set; }
        public int Scales_ID { get; set; }
        public int Company_ID { get; set; }
        public int BatchM_PorHumInt { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; } 
        public string BatchM_Status { get; set; }
        public virtual Scales Scales { get; set; }
    }
}
