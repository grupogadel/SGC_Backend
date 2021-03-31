using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class Access
    {
        [Key]
        public int Access_ID { get; set; }
        public int? Module_ID { get; set; }
        public string Access_Cod { get; set; }
        public string Access_Name { get; set; }
        public string Access_Desc { get; set; }
        public string Access_Url { get; set; }
        public string Access_IconName { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Access_Status { get; set; }
        public Module Module { get; set; }

    }
}
