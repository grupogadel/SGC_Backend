using SGC.Entities.Entities.XX.Operations.Mining;
using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class Ruma
    {
        public int Ruma_ID { get; set; }
        public int? CampH_ID { get; set; }
        public int Company_ID { get; set; }
        public string Ruma_NO { get; set; }
        public string Ruma_Desc { get; set; }
        public int? MatType_ID { get; set; }
        public DateTime Ruma_Process_Date { get; set; }
        public int Period_ID { get; set; }
        public decimal Ruma_Weigth { get; set; }
        public int? Ruma_NumLotes { get; set; }
        public decimal? Ruma_LeyAuAver { get; set; }
        public decimal? Ruma_LeyAgAver { get; set; }
        public decimal? Ruma_ConsuCNAver { get; set; }
        public decimal? Ruma_ConsuOHAver { get; set; }
        public decimal? Ruma_RecovAuAver { get; set; }
        public decimal? Ruma_RecovAgAver { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Ruma_Status { get; set; }
        public MaterialType MaterialTypes { get; set; }
        public Period Period { get; set; }
        public List<BatchMineral> LstLotes { get; set; }
    }
}
