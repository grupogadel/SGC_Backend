using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class AdvanceBalance
    {
        [Key]
        public string Period_Cod { get; set; }
        public string MPeriod_Name { get; set; }
        public decimal Amount { get; set; }
    }
}
