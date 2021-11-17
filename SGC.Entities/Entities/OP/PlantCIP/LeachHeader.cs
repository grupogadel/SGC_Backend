using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.CM.MineralReception;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.OP.PlantCIP
{
    public class LeachHeader
    {
        public int LeachH_ID { get; set; }
        public int CampH_ID { get; set; }
        public int Company_ID { get; set; }
        public DateTime LeachH_Process_Date { get; set; }
        public string LeachH_NO { get; set; }
        public string LeachH_Desc { get; set; }
        public DateTime LeachH_First_Date { get; set; }
        public DateTime LeachH_End_Date { get; set; }
        public decimal LeachH_Coal_FinosAuGr { get; set; }
        public decimal LeachH_Coal_FinosAgGr { get; set; }
        public decimal LeachH_Solid_FinosAuGr { get; set; }
        public decimal LeachH_Solid_FinosAgGr { get; set; }
        public decimal LeachH_Solution_FinosAuGr { get; set; }
        public decimal LeachH_Solution_FinosAgGr { get; set; }
        public string LeachH_Authsd_By { get; set; }
        public DateTime LeachH_Authsd_Date { get; set; }
        public string LeachH_Authsd_Status { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LeachH_Status { get; set; }

        //Campaign
        public string CampH_NO { get; set; }
    }
}
