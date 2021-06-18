using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.WK;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Collector
    {
        [Key]
        public int Collec_ID { get; set; }
        public int PosCollec_ID { get; set; }
        public int Zone_ID { get; set; }
        public int Person_ID { get; set; }
        public int Company_ID { get; set; }
        public string Collec_TaxID { get; set; }
        public string Collec_Name { get; set; }
        public string Collec_LastName { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Collec_Status { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual Person Person { get; set; }
        public virtual PositionCollector PositionCollector { get; set; }
    }
}