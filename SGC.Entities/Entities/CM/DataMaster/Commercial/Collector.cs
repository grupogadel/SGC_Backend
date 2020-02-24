using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Collector
    {
        [Key]
        public int Collec_ID { get; set; }
        public int  Zone_ID { get; set; }
        public int Company_ID { get; set; }
        public string Collec_Cod { get; set; }
        public string Collec_TaxID { get; set; }
        public string Collec_Name { get; set; }
        public string Collec_LastName { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Collec_Status { get; set; }
    }
}
