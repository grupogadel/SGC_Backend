using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.Commercial.CommercialCondition
{
    public class CommercialConditions
    {
        [Key]
        public int Cond_ID { get; set; }
        public int Vendor_ID { get; set; }
        public string Vendor_FullName { get; set; }
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        public int Company_ID { get; set; }
        public string Cond_Cod { get; set; }
        public string Cond_Desc { get; set; }
        public DateTime Cond_DateStart { get; set; }
        public DateTime Cond_DateEnd { get; set; }
        public decimal? Cond_WeigPor_Sec { get; set; }
        public decimal? Cond_LeyAuPor_Sec { get; set; }
        public decimal? Cond_LeyAgPor_Sec { get; set; }
        public decimal? Cond_Humi_Sec { get; set; }
        public decimal? Cond_RecovAg_Sec { get; set; }
        public decimal? Cond_ConsuAg_Sec { get; set; }
        public decimal? Cond_MarginPIAg_Sec { get; set; }
        public decimal? Cond_OzMinAg { get; set; }
        public decimal? Cond_MaquilaAg { get; set; }
        public decimal? Cond_ExpLab { get; set; }
        public decimal? Cond_ExpAdmin_Estim { get; set; }
        public decimal? Cond_RecovAu_Estim { get; set; }
        public decimal? Cond_MaquilaAu_Estim { get; set; }
        public decimal? Cond_MarginPI_Estim { get; set; }
        public decimal? Cond_ConsuAu_Estim { get; set; }
        public decimal? Cond_MaquilaAg_Estim { get; set; }
	    public decimal? Cond_RecovAg_Estim { get; set; }
        public decimal? Cond_MarginPIAg_Estim { get; set; }
        public decimal? Cond_ConsuAg_Estim { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Cond_Status { get; set; }
        public List<MaquilaCommercial> MaquilasCommercials { get; set; }
        public CommercialConditions()
        {
            MaquilasCommercials = new List<MaquilaCommercial>();
        }
	}
}
