﻿using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class Ruma
    {
        public int Ruma_ID { get; set; }
        public int Company_ID { get; set; }
        public string Ruma_NO { get; set; }
        public string Ruma_Desc { get; set; }
        public int? MinType_ID { get; set; }
        public DateTime Ruma_Date { get; set; }
        public string Ruma_Period { get; set; }
        public decimal Ruma_Weigth { get; set; }
        public decimal? Ruma_LeyAu { get; set; }
        public decimal? Ruma_LeyAg { get; set; }
        public decimal? Ruma_RecovAu { get; set; }
        public decimal? Ruma_RecovAg { get; set; }
        public decimal? Ruma_ConsNaCN { get; set; }
        public decimal? Ruma_ConsNaOH { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Ruma_Status { get; set; }
        public MineralsType MineralTypes { get; set; }
    }
}
