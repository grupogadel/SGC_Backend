using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.Collect;
using SGC.Entities.Entities.FI.DataMaster;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.Collect
{
    public class ExpCollectorHead
    {
        [Key]
        public int ExpColIH_ID { get; set; }
        public int TPayColl_ID { get; set; }
        public int Company_ID { get; set; }
        public string ExpColIH_NO { get; set; }
        public int Period_ID { get; set; }
        public int Zone_ID { get; set; }
        public int MExpColl_ID { get; set; }
        public int Currency_ID { get; set; }
        public decimal ExpColIH_TotAmount { get; set; }
        public DateTime ExpColIH_DocDate { get; set; }
        public int CompPago_ID { get; set; }
        public string ExpColIH_DocNO { get; set; }
        public string ExpColIH_Type { get; set; }
        public string ExpColIH_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string ExpColIH_Status { get; set; }


        public virtual List<ExpCollectorDetails> ExpCollectorDetails { get; set; }
        public virtual ToPayCollector ToPayCollector { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual ExpCollectMaster ExpCollectMaster { get; set; }
        public virtual ComprobanteDePago ComprobanteDePago { get; set; }
    }
}