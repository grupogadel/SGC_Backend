using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class ConsumeHead
    {
        public int ConsuH_ID { get; set; }
        public int Company_ID { get; set; }
        public decimal ConsuH_ReacNaCN { get; set; }
        public decimal ConsuH_ReacNaOH { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string ConsuH_Status { get; set; }
        public virtual ConsumeDetail ConsumeDetail { get; set; }
    }
}
