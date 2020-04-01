using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.MineralReception;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class SampleHead
    {
        [Key]
        public int SampH_ID { get; set; }
        public int BatchM_ID { get; set; }
        public int Hum_ID { get; set; }
        public string Ruma_ID { get; set; }
        public string LeyM_ID { get; set; }
        public int Recov_ID { get; set; }
        public string Consu_ID { get; set; }
        public string Company_ID { get; set; }
        public DateTime SampOrig_ID { get; set; }
        public DateTime SampH_Cod { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string SampH_Status { get; set; }
        public virtual BatchMineral BatchMineral { get; set; }
        public virtual Humidity Humidity { get; set; }

    }
}
