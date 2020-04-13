using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class PositionCollector
    {
        [Key]
        public int PosCollec_ID { get; set; }
        public int PosCollec_Cod { get; set; }
        public string PosCollec_Name { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string PosCollec_Status { get; set; }
    }
}
