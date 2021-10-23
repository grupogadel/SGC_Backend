using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Reports
{
    public class BatchComProcTime
    {
        public int BatchM_ID { get; set; }
        public string BatchM_Lote_New { get; set; }

        //Scale
        public DateTime Scales_DateInp { get; set; }

        //Vendor
        public int Vendor_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }

        //Sample
        public DateTime? SampH_Proces_Date { get; set; }

        //Sample Recep
        public DateTime? SampD_RecLab_Date { get; set; }

        //Laboratory End
        public DateTime? SampH_LabFinish_Date { get; set; }

        //Aprb.Ctrl.Int.
        public DateTime? IntCtrlH_Approved_Date { get; set; }

        //Liquidation
        public DateTime? Creation_DateLiq { get; set; }

        //Prpuesta
        public DateTime? LiquiH_AcceptDate { get; set; }
    }
}
