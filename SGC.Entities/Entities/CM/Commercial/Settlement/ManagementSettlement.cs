using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Settlement
{
    public class ManagementSettlement
    {
        //Batch
        public int BatchM_ID { get; set; }
        public decimal? BatchM_TMHInt { get; set; }
        public decimal? BatchM_TMSHist { get; set; }
        public string BatchM_Lote_New { get; set; }
        public string BatchM_LiquidBlock { get; set; }
        public string BatchM_LiquidStatus { get; set; }

        //Scale
        public int Scales_ID { get; set; }
        public DateTime Scales_DateInp { get; set; }

        //Vendor
        public int Vendor_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }

        //Collect
        public int Collec_ID { get; set; }
        public string Collec_Name { get; set; }
        public string Collec_LastName { get; set; }
        public string Collec_DNI { get; set; }

        //Origin
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public string Orig_Desc { get; set; }

        //Zone
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }

        //public virtual LiquidationHead LiquidationHead { get; set; }
    }
}
