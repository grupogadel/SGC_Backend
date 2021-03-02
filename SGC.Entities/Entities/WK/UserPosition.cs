using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class UserPosition
    {
        [Key]
        public int UserPos_ID { get; set; }
		public int UserAcc_ID { get; set; }
		public int Position_ID { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string UserPos_Status { get; set; }
		
		public string Position_Name { get; set; }
		public int Company_ID { get; set; }
		public string Company_Name { get; set; }
    }
}
