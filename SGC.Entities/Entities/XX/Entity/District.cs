using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class District
    {
        [Key]
        public int Dist_ID { get; set; }
        public string Dist_Cod { get; set; }
        public int Prov_ID { get; set; }
        public string Dist_Name { get; set; }
        public string Dist_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Dist_Status { get; set; }
    }
}
