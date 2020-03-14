using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.Collect
{
    public class Quota
    {
        [Key]
        public int Quota_ID { get; set; }
        public int Company_ID { get; set; }
        public int Period_ID { get; set; }
        public int Collec_ID { get; set; }
        public int Zone_ID { get; set; }
        public string UM_Cod { get; set; }
        public decimal Quota_TM_Est { get; set; }
        public decimal  Quota_LeyAver { get; set; }
        public string Creation_User { get; set; }   
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Quota_Status { get; set; }
        public virtual Period Period { get; set; }
        public virtual Collector Collector { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual UnitMeasuare UnitMeasuare { get; set; }
    }
}
