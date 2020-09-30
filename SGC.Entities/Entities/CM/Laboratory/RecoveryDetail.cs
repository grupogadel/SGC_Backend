using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class RecoveryDetail
    {
        [Key]
        public int RecovD_ID { get; set; }
        public int RecovH_ID { get; set; }
        public int RecovD_Row { get; set; }
        public string RecovD_Type { get; set; }

        public decimal RecovD_Solution_Ppn { get; set; }
        public decimal RecovD_Solution_Mg { get; set; }
        public decimal RecovD_Desc_Accumul { get; set; }
        public decimal RecovD_W3 { get; set; }
        public decimal RecovD_Total { get; set; }

        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string RecovD_Status { get; set; }
    }
}
    