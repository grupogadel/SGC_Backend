using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Commercial
{
    public class Conditions
    {
        [Key]
        public int Cond_ID { get; set; }
        public int Company_ID { get; set; }
        public int Vendor_ID { get; set; }
        public int Orig_ID { get; set; }
        public int Zone_ID { get; set; }
        public string Cond_Cod { get; set; }
        public string Cond_Desc { get; set; }
        public DateTime Cond_DateStart { get; set; }
        public DateTime Cond_DateEnd { get; set; }
        public decimal Cond_WeigPor_Sec { get; set; }
        public decimal Cond_LeyAuPor_Sec { get; set; }
        public decimal Cond_LeyAgPor_Sec { get; set; }
        public decimal Cond_HumiAu_Sec { get; set; }
        public decimal Cond_HumiAg_Sec { get; set; }
        public decimal Cond_RecovAu_Sec { get; set; }
        public decimal Cond_RecovAg_Sec { get; set; }
        public decimal Cond_ConsuAu_Sec { get; set; }
        public decimal Cond_ConsuAg_Sec { get; set; }
        public decimal Cond_MarginPI { get; set; }
        public decimal Cond_Maquila { get; set; }
        public decimal Cond_ExpLab { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime  Modified_Date { get; set; }
        public string Cond_Status { get; set; }
        
	}
}
