using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class AccessPosition
    {
        [Key]
        public int AccPos_ID { get; set; }
		public int Access_ID { get; set; }
		public int Position_ID { get; set; }
        public decimal AccPos_LimMin { get; set; }
        public decimal AccPos_LimMax { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string AccPos_Status { get; set; }
        public Access Access { get; set; }

    }
}
