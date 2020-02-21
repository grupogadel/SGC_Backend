using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.DataMaster.Commercial
{
    public class Origin
    {
        [Key]
        public int Orig_ID { get; set; }
        public string Orig_Cod { get; set; }
        public int Zone_ID { get; set; }
        public string Orig_Name { get; set; }
        public string Orig_Desc { get; set; }
        public string Orig_Address { get; set; }
        public string Orig_Reference { get; set; }
        public string Orig_Coordinates { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public int Company_ID { get; set; }
        public string Orig_Status { get; set; }
    }
}
