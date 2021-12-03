using System;
using System.Collections.Generic;
using System.Text;
using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.CM.Commercial.Liquidation;

namespace SGC.Entities.Entities.CM.Commercial.Reports
{
    public class MineralBatchLiquidation
    {
        public int BatchM_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        public decimal? BatchM_TMSInt { get; set; }
        public decimal? BatchM_TMHInt { get; set; }
        public decimal? BatchM_TMSHist { get; set; }

        //Scale
        public DateTime Scales_DateInp { get; set; }
        public int Scales_NumSacos { get; set; }

        //Ruuma
        public string Ruma_NO { get; set; }


        //Humidity
        public decimal? Hum_PorcH2O { get; set; }

        //Period
        public string Period_NO { get; set; }

        //Origin
        public string Orig_Name { get; set; }

        //Vendor
        public int Vendor_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }

        //MaterialType
        public string MinType_Desc { get; set; }

        //Liquidation
        public int? LiquiH_ID { get; set; }
        public string LiquiH_Status { get; set; }
        public decimal? LiquiH_ExpLabVal { get; set; }
        public DateTime? LiquiH_DateProc { get; set; }

        //Liquidation Details
        public virtual LiquidationDetail LiquidationDetailAuReport { get; set; }
        public virtual LiquidationDetail LiquidationDetailAgReport { get; set; }
        public virtual LiquidationDetail LiquidationDetailAuInt { get; set; }
        public virtual LiquidationDetail LiquidationDetailAgInt { get; set; }

    }
}
