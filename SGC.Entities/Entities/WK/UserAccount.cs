using SGC.Entities.Entities.WK;
using System;
using SGC.Entities.Entities.XX.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.WK
{
    public class UserAccount
    {
        [Key]
        public int UserAcc_ID { get; set; }
        public int Person_ID { get; set; }
        public string UserAcc_User { get; set; }
        public string UserAcc_Pass { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string UserAcc_Status { get; set; }
		//Person
		public string Person_DNI { get; set; }
		public string Person_Name { get; set; }
		public string Person_LastName { get; set; }
		public string Person_Number { get; set; }
		public string Person_Email { get; set; }

        public List<UserPosition> UserPositions { get;  set;}

        public List<Company> Company { get; set; }


        public UserAccount()
        {
            UserPositions = new List<UserPosition>();
        }
    }
    
}
