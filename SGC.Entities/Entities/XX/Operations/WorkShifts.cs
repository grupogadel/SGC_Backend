using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations
{
    public class WorkShifts
    {
        [Key]
        public int WrkShi_ID { get; set; }
        public string WrkShi_Cod { get; set; }
        public string WrkShi_Desc { get; set; }
        public DateTime? WrkShi_TimeStar { get; set; }
        public DateTime? WrkShi_TimeEnd { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string WrkShi_Status { get; set; }
    }
}
