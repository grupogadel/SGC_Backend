using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Liquidation
{
    public class ManagementLiquidation
    {
        //Batch
        public int BatchM_ID { get; set; }
        public decimal? BatchM_TMHInt { get; set; }
        public decimal? BatchM_TMSHist { get; set; }
        public decimal? BatchM_TMSInt { get; set; }
        public decimal? BatchM_LeyAuInt { get; set; }
        public decimal? BatchM_LeyAgInt { get; set; }
        public decimal? BatchM_PorHumInt { get; set; }
        public string BatchM_Lote_New { get; set; }
        public string BatchM_LiquidBlock { get; set; }

        //Scale
        public int Scales_ID { get; set; }
        public DateTime Scales_DateInp { get; set; }
        public decimal? Scales_TMH_Hist { get; set; }

        //Humidity
        public decimal? Hum_PorcH2O { get; set; }

        //LeyMineral
        public decimal? LeyMH_FinishAu { get; set; }
        public decimal? LeyMH_FinishAg { get; set; }

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

        //MineralType
        public int MinType_ID { get; set; }
        public string MinType_Desc { get; set; }

        public virtual LiquidationHead LiquidationHead { get; set; }
    }
}
