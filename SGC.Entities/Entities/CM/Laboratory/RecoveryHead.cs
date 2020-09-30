using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class RecoveryHead
    {
        [Key]
        public int RecovH_ID { get; set; }
        public int Company_ID { get; set; }

        public decimal RecovH_LeyAuRipio { get; set; }
        public decimal RecovH_LeyAgRipio { get; set; }

        public decimal RecovH_AuHeadTest { get; set; }
        public decimal RecovH_AuTailTest { get; set; }
        public decimal RecovH_AuHeadCalc { get; set; }
        public decimal RecovH_AuRecovTest { get; set; }
        public decimal RecovH_AuRecovCalc { get; set; }
        public decimal RecovH_AuHeadMet { get; set; }
        public decimal RecovH_AuSoluMet { get; set; }
        public decimal RecovH_AuTailMet { get; set; }

        public decimal RecovH_AgHeadTest { get; set; }
        public decimal RecovH_AgTailTest { get; set; }
        public decimal RecovH_AgHeadCalc { get; set; }
        public decimal RecovH_AgRecovTest { get; set; }
        public decimal RecovH_AgRecovCalc { get; set; }
        public decimal RecovH_AgHeadMet { get; set; }
        public decimal RecovH_AgSoluMet { get; set; }
        public decimal RecovH_AgTailMet { get; set; }

        public decimal RecovH_AuRecovArtif { get; set; }
        public decimal RecovH_CuRecovCalc { get; set; }
        public decimal RecovH_AuREEDrive { get; set; }
        public decimal RecovH_AuHrsAgita { get; set; }

        public decimal RecovH_CuPpm48 { get; set; }
        public decimal RecovH_CuPpm72 { get; set; }
        public decimal RecovH_CuPpm90 { get; set; }

        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string RecovH_Status { get; set; }
        public List<RecoveryDetail> RecoveryDetail { get; set; }

    }
}
