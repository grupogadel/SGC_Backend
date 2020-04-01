using System;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.FI.DataMaster
{
    public class ExchangeRate
    {
        [Key]
        public int ExchRate_ID { get; set; }
        public string ExchRate_From_Cod { get; set; }
        public string ExchRate_To_Cod { get; set; }
        public DateTime ExchRate_Date { get; set; } 
        public decimal ExchRate_Buy { get; set; }
        public decimal ExchRate_Sale { get; set; }
        public decimal ExchRate_Agrem { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string ExchRate_Status { get; set; }
        public virtual Currency Currency_From { get; set; }
        public virtual Currency Currency_To { get; set; }
    }
}
