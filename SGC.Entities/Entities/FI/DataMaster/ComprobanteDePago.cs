using System;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.FI.DataMaster
{
    public class ComprobanteDePago
    {
        [Key]
        public int CompPago_ID { get; set; }
        public string CompPago_Cod { get; set; }
        public string CompPago_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string CompPago_Status { get; set; }
    }
}
