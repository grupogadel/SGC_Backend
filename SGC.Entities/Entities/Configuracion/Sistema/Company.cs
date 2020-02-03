using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.Configuracion.Sistema
{
    public class Company
    {
        public int Compa_ID { get; set; }
        public string Compa_Cod { get; set; }
        public string Compa_Name { get; set; }
        public string Compa_TaxID { get; set; }
        public string Compa_Country { get; set; }
        public string Compa_Region { get; set; }
        public string Compa_Address { get; set; }
        public string Compa_Curr_Funct { get; set; }
        public string Compa_Curr_Loc { get; set; }
        public string Compa_Curr_Grp { get; set; }
        public string Compa_AcctDeb { get; set; }
        public string Compa_AcctCre { get; set; }
        public string Compa_Status { get; set; }
        public virtual ICollection<Period> Periods { get; set; }
    }
}
