using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.MineralReception;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.Collect
{
    public class ExpCollectorDetails
    {
        [Key]
        public int ExpColID_ID { get; set; }
        public int ExpColIH_ID { get; set; }
        public int Batch_ID { get; set; }
        public decimal ExpColID_Amount { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string ExpColID_Status { get; set; }

        public string Zone_Name { get; set; }
        public string BatchM_Lote_New { get; set; }
    }
}