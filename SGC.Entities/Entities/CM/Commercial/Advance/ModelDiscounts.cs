using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class ModelDiscounts
    {
        [Key]
        public int AdvanD_ID { get; set; }
        public decimal AdvanD_AmountL { get; set; }
        public string Creation_User { get; set; }
        public string Modified_User { get; set; }
        public string AdvanD_Curr { get; set; }

        public List<Discounts> DiscountsDetails { get; set; }
        public ModelDiscounts()
        {
            DiscountsDetails = new List<Discounts>();
        }

    }
}
