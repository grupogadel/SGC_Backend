using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class AdvanceBalanceAccumulated
    {
        [Key]
        public decimal? Accumulated { get; set; }
    }
}

