using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Language
    {
        [Key]
        public int Lang_ID { get; set; }
        public string Lang_Cod { get; set; }
        public string Lang_Name { get; set; }
        public string Lang_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Lang_Status { get; set; }
    }
}
