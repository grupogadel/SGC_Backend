using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class Person
    {
        [Key]
		public int Person_ID { get; set; }
        public string Person_DNI { get; set; }
		public string Person_Name { get; set; }
		public string Person_LastName { get; set; }
		public string Person_Number { get; set; }
		public string Person_Email { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Person_Status { get; set; }
    }
}
