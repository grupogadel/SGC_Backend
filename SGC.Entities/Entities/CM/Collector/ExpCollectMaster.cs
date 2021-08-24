using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.CM.Collect;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.CM.Collect
{
    public class ExpCollectMaster
    {
        [Key]
        public int MExpColl_ID { get; set; }
        public int MExp_ID { get; set; }
        public int Company_ID { get; set; }
        public string MExpColl_Cod { get; set; }
        public int UM_ID { get; set; }
        public string MExpColl_Categ { get; set; }
        public string MExpColl_Name { get; set; }
        public string MExpColl_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string MExpColl_Status { get; set; }
    }
}