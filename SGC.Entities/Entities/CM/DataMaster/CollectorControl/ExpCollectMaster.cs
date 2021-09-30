using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.DataMaster.CollectorControl
{
    public class ExpCollectMaster
    {
        [Key]
        public int MExpColl_ID { get; set; }
        public int MAccL_ID { get; set; }
        public string MAccL_Cod { get; set; }
        public string MAccL_Desc { get; set; }
        public int Company_ID { get; set; }
        public string MExpColl_Cod { get; set; }
        public int UM_ID { get; set; }
        public string UM_Cod { get; set; }
        public string MExpColl_Level { get; set; }
        public string MExpColl_Name { get; set; }
        public string MExpColl_Desc { get; set; }
        public int AccCat_ID { get; set; }
        public string AccCat_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string MExpColl_Status { get; set; }
    }
}
