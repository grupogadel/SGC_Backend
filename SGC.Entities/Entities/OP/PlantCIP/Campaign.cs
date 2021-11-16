using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.OP.PlantCIP
{
    public class Campaign
    {
        public int CampH_ID { get; set; }
        public int Company_ID { get; set; }
        public int Plant_ID { get; set; }
        public DateTime? CampH_Process_Date { get; set; }
        public string CampH_NO { get; set; }
        public string CampH_Desc { get; set; }
        public DateTime? CampH_First_Date { get; set; }
        public DateTime? CampH_End_Date { get; set; }
        public decimal CampH_Ruma_TotWeight { get; set; }
        public decimal CampH_Ruma_LeyAuOzTc_Aver { get; set; }
        public decimal CampH_Ruma_LeyAgOzTc_Aver { get; set; }
        public decimal CampH_Ruma_FinosAuGr_Aver { get; set; }
        public decimal CampH_Ruma_FinosAgGr_Aver { get; set; }
        public decimal CampH_Ruma_ConsuCN_Aver { get; set; }
        public decimal CampH_Ruma_ConsuOH_Aver { get; set; }
        public decimal CampH_Ruma_RecovAu_Aver { get; set; }
        public decimal CampH_Ruma_RecovAg_Aver { get; set; }
        public string CampH_Authsd_By { get; set; }
        public DateTime? CampH_Authsd_Date { get; set; }
        public string CampH_Status_Cod { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string CampH_Status { get; set; }
        public List<Ruma> LstRumas { get; set; }
        public Plants Plants { get; set; }
    }
}
