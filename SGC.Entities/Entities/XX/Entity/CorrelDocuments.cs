using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Entity
{
    public class CorrelDocuments
    {
        [Key]
        public int Correl_ID { get; set; }
        public int Company_ID { get; set; }
        public string Correl_Cod { get; set; }
        public string Correl_Module { get; set; }
        public string Correl_ProcessName { get; set; }
        public string Correl_TransacName { get; set; }
        public string Correl_Prefix { get; set; }
        public string Correl_OrigDoc_NO { get; set; }
        public string Correl_AcctDoc_NO { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Correl_Status { get; set; }
    }
}
