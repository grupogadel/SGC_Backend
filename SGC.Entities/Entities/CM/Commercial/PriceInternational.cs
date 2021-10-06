using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.Commercial
{
    public class PriceInternational
    {
        [Key]
        public int Price_ID { get; set; }
        public DateTime? Price_DatePrice { get; set; }
        public decimal? Price_GoldAM { get; set; }
        public decimal? Price_GoldPM { get; set; }
        public decimal? Price_Silver { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Price_Status { get; set; }
    }
}
