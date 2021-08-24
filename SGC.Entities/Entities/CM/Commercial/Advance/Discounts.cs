using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class Discounts
    {
        [Key]
        public int Discount_ID { get; set; }
        public int AdvanD_ID { get; set; }
        public string Discount_NO { get; set; }
        public int Currency_ID { get; set; }
        public string Discount_Curr { get; set; }
        public decimal Discount_ExchRateSale { get; set; }
        public decimal Discount_AmountL { get; set; }
        public decimal Discount_AmountF { get; set; }
        public DateTime? Discount_PaidDate { get; set; }
        public int Bank_ID { get; set; }
        public string Bank_Name { get; set; }
        public string Discount_BankAcct { get; set; }
        public string Discount_Refer { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Discount_Status { get; set; }

    }
}
