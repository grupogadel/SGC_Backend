using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Finance
{
    public class TaxMaster
    {
        [Key]
        public int MTax_ID { get; set; }
        public int Company_ID { get; set; }
        public string MTax_Cod { get; set; }
        public decimal MTax_Rate1 { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string MTax_Status { get; set; }

    }
}
