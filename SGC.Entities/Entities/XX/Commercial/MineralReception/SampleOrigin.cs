using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial.MineralReception
{
    public class SampleOrigin
    {
        [Key]
        public int SampOrig_ID { get; set; }
        public int Company_ID { get; set; }
        public string SampOrig_AreaCod { get; set; }
        public string SampOrig_AreaDesc { get; set; }
        public string SampOrig_Cod { get; set; }   
        public string SampOrig_Module { get; set; }
		public string SampOrig_Name { get; set; }
        public string SampOrig_Desc { get; set; }
        public bool SampOrig_ExgTab { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampOrig_Status { get; set; }
    }
}
