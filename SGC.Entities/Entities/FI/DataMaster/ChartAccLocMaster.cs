using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.FI.DataMaster
{
    public class ChartAccLocMaster
    {
        [Key]
        public int MAccL_ID { get; set; }
        public int Company_ID { get; set; } 
        public string MAccL_Cod { get; set; }
        public string MAccL_Level { get; set; }
        public string MAccL_Father { get; set; }
        public string MAccL_Desc { get; set; }
        public string AccCat_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string MAccL_Status { get; set; }
    }
}
