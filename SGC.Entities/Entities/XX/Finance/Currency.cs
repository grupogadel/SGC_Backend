using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Finance
{
    public class Currency
    {
        [Key]
        public int Currency_ID { get; set; }
        public string Currency_Country { get; set; }
        public string Currency_Cod { get; set; }
        public string Currency_Name { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Currency_Status { get; set; }


    }
}
