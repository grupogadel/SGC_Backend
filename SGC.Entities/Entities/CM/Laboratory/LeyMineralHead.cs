using SGC.Entities.Entities.XX.Commercial.Laboratory;
using SGC.Entities.Entities.XX.Commercial.MineralReception;
using SGC.Entities.Entities.XX.Operations.Mining;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class LeyMineralHead
    {
        [Key]
        public int LeyMH_ID { get; set; }
        public int Company_ID { get; set; }
        public decimal LeyMH_FinishAu { get; set; }
        public decimal LeyMH_FinishAg { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LeyMH_Status { get; set; }
        public List<LeyMineralDetail> LeyMineralDetail { get; set; }

    }
}
