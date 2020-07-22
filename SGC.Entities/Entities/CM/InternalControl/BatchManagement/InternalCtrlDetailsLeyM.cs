using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlDetailsLeyM
    {
        [Key]
        public int LeyMH_ID { get; set; }
        public int LabProcTyp_ID { get; set; }
        public decimal LeyMH_FinishAu { get; set; }
        public decimal LeyMH_FinishAg { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
