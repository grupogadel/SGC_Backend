using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlDetailsConsume
    {
        [Key]
        public int ConsuH_ID { get; set; }
        public int LabProcTyp_ID { get; set; }
        public decimal ConsuH_ReacNaCN { get; set; }
        public decimal ConsuH_ReacNaOH { get; set; }
        public decimal ConsuH_CuPorc { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
