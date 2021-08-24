using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.Collect
{
    public class ToPayCollector
    {
        [Key]
        public int TPayColl_ID { get; set; }
        public int Company_ID { get; set; }
        public string TPayColl_NO { get; set; }
        public int Collec_ID { get; set; }
        public int Zone_ID { get; set; }
        public int Period_ID { get; set; }
        public int Currency_ID { get; set; }
        public DateTime TPayColl_ProcDate { get; set; }
        public string TPayColl_Days { get; set; }
        public string TPayColl_Desc { get; set; }
        public decimal TPayColl_Amount { get; set; }
        public decimal? TPayColl_AmountPaid { get; set; }
        public DateTime? Date_Approved { get; set; }
        public string User_Approved { get; set; }
        public string TPayColl_StatusProc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string TPayColl_Status { get; set; }

        public virtual Period Period { get; set; }
        public virtual Collector Collector { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Zone Zone { get; set; }
    }
}