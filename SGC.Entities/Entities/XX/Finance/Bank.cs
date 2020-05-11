using SGC.Entities.Entities.XX.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Finance
{
    public class Bank
    {
        public int Bank_ID { get; set; }
        public int? Country_ID { get; set; }
        public string Bank_Cod { get; set; }
        public string Bank_Name { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Bank_Status { get; set; }
        public Country Countrys { get; set; }
    }
}
