using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.InternalControl.BatchManagement
{
    public class InternalCtrlDetailsRecovery
    {
        [Key]
        public int RecovH_ID { get; set; }
        public int LabProcTyp_ID { get; set; }
        public decimal RecovH_AuRecovCalc { get; set; }
        public decimal RecovH_AuMg48_Tot { get; set; }
        public decimal RecovH_AuMg72_Tot { get; set; }
        public decimal RecovH_AgRecovCalc { get; set; }
        public decimal RecovH_AgMg48_Tot { get; set; }
        public decimal RecovH_AgMg72_Tot { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
