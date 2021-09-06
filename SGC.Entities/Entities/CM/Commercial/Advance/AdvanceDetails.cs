using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class AdvanceDetails
    {
        [Key]
        public int AdvanD_ID { get; set; }
        public int AdvanH_ID { get; set; }
        public int AdvanD_Item { get; set; }
        public int BatchM_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        public int Collec_ID { get; set; }
        public string Collec_FullName { get; set; }
        public DateTime? AdvanD_Date { get; set; }
        public int Currency_ID { get; set; }
        public string AdvanD_Curr { get; set; }
        public decimal? AdvanD_ExchRateSale { get; set; }
        public string AdvanD_Desc { get; set; }
        public DateTime? AdvanD_ApprDate { get; set; }
        public string AdvanD_ApprUser { get; set; }
        public decimal AdvanD_AmountL { get; set; }
        public decimal AdvanD_AmountF { get; set; }
        public int AdvanD_Days { get; set; }
        public DateTime? AdvanD_PayToDate { get; set; }
        public bool? AdvanD_PayFull { get; set; }
        public decimal? AdvanD_AmountPayFullL { get; set; }
        public decimal? AdvanD_AmountPayFullF { get; set; }
        public string AdvanD_Status_Cod { get; set; }
        public string AdvanD_DocSerie { get; set; }
        public string AdvanD_DocNO { get; set; }
        public DateTime? AdvanD_DocDate { get; set; }
        public string AdvanD_Status_Doc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string AdvanD_Status { get; set; }
       
    }
}
