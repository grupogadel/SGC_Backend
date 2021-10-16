using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Advance
{
    public class AdvanceHead
    {
        [Key]
        public int AdvanH_ID { get; set; }
        public int Company_ID { get; set; }
        public int Period_ID { get; set; }
        public string Period_NO { get; set; }
        public int Vendor_ID { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_SurName { get; set; }
        public string Vendor_LastName { get; set; }
        public string AdvanH_NO { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string AdvanH_Status { get; set; }
        public List<AdvanceDetails> AdvanceDetails { get; set; }
        public AdvanceHead()
        {
            AdvanceDetails = new List<AdvanceDetails>();
        }
    }
}
