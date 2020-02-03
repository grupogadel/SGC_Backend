﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.View.Configuracion.Sistema
{
    public class VendorView
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
    }
}
