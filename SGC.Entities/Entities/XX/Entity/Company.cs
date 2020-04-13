using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SGC.Entities.Entities.XX.Finance;

namespace SGC.Entities.Entities.XX.Entity
{
    public class Company
    {
        [Key]
        public int Company_ID { get; set; }
        public int? Company_Father_ID { get; set; }
        public string Company_Cod { get; set; }
        public string Company_Name { get; set; }
        public string Company_TaxID { get; set; }
        public int Country_ID { get; set; }
        public int Region_ID { get; set; }
        public string Company_Address { get; set; }
        public string Company_Curr_Funct { get; set; }
        public string Company_Curr_Loc { get; set; }
        public string Company_Curr_Grp { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Company_Status { get; set; }
        public virtual Currency Currency_Funct { get; set; }
        public virtual Currency Currency_Grp { get; set; }
        public virtual Currency Currency_Loc { get; set; }
        public virtual Country Country { get; set; }
        public virtual Region Region { get; set; }

    }
}
