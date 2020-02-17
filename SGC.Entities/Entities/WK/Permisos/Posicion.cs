using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.M_WK
{
    public class Posicion
    {
        [Key]
        public int Position_ID { get; set; }
        public string Position_Cod { get; set; }
        public string Position_Name { get; set; }
        public string Position_Desc { get; set; }
        public int Position_Father_ID { get; set; }
        public string Position_Level { get; set; }
        public string Position_Status { get; set; }
    }
}
