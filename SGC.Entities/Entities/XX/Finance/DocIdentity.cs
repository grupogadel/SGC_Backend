using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Finance
{
    public class DocIdentity
    {
        public int DocIdent_ID { get; set; }
        public string DocIdent_Cod { get; set; }
        public string DocIdent_Name { get; set; }
        public string DocIdent_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string DocIdent_Status { get; set; }
    }


}
