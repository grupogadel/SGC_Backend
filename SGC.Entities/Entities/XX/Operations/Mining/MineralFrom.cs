using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class MineralFrom
    {
        public int MinFrom_ID { get; set; }
        public int Company_ID { get; set; }
        public string MinFrom_Cod { get; set; }
        public string MinFrom_Name { get; set; }
        public string MinFrom_Desc { get; set; }
        public string MinFrom_Location { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string MinFrom_Status { get; set; }
    }
}
