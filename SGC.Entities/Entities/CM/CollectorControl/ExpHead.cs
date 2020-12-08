using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.CollectorControl
{
    public class ExpHead
    {
        [Key]
        public int ExpH_ID { get; set; }
        public int Company_ID { get; set; }
        public int Zone_ID { get; set; }
        public int Period_ID { get; set; }
        public int Collec_ID { get; set; }
        public int Currency_ID { get; set; }
        public string ExpH_Cod { get; set; }
        public string ExpH_Desc { get; set; }
        public int ExpH_DaysRender { get; set; }
        public decimal ExpH_TotAmount { get; set; }
        public string Creation_User { get; set; }   
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string ExpH_Status { get; set; }
        public virtual Period Period { get; set; }
        public virtual Collector Collector { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Zone Zone { get; set; }

    }
}
