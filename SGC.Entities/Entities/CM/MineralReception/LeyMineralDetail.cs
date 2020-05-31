using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class LeyMineralDetail
    {
        public int LeyMD_ID { get; set; }
        public int? LeyMH_ID { get; set; }
        public DateTime? LeyMD_RecepDate { get; set; }
        public string LeyMD_RecepUser { get; set; }
        public decimal? LeyMD_BK { get; set; }
        public decimal? LeyMD_PMFino { get; set; }
        public decimal? LeyMD_PMGrueso { get; set; }
        public decimal? LeyMD_PesoAu_Ag { get; set; }
        public decimal? LeyMD_AuFino1 { get; set; }
        public decimal? LeyMD_AuFino2 { get; set; }
        public decimal? LeyMD_AuGrueso { get; set; }
        public decimal? LeyMD_OzTcAuFino { get; set; }
        public decimal? LeyMD_OzTcAuGrueso { get; set; }
        public decimal? LeyMD_OzTcAuFinal { get; set; }
        public decimal? LeyMD_OzTcAgFinal { get; set; }
        public decimal? LeyMD_FinalAu { get; set; }
        public decimal? LeyMD_FinalAg { get; set; }
        public decimal? LeyMD_PorcAuFino { get; set; }
        public decimal? LeyMD_PorcAuGrueso { get; set; }
        public string LeyMD_CheckStatus { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LeyMD_Status { get; set; }
    }
}
