using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Province
    {
        [Key]
        public int Prov_ID { get; set; }
        public string Prov_Cod { get; set; }
        public int Depa_ID { get; set; }
        public string Prov_Name { get; set; }
        public string Prov_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Prov_Status { get; set; }
    }
}
