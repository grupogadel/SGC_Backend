using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class ModelCrushed
    {
        //Batch
        public int BatchM_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        //Scale
        public int Scales_ID { get; set; }
        public DateTime Scales_DateInp { get; set; }
        public int Scales_NumSacos { get; set; }
        public decimal Scales_TMH { get; set; }
        //Vendor
        public int Vendor_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }
        //MineralType
        public int MinType_ID { get; set; }
        public string MinType_Desc { get; set; }
        //Origin
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public string Orig_Desc { get; set; }
        //Zone
        public int Zone_ID { get; set; }
        public string Zone_Name { get; set; }
        //Crushed
        public int? Crush_ID { get; set; }
        public int? Company_ID { get; set; }
        public int? Circuit_ID { get; set; }
        public DateTime? Crush_Process_Date { get; set; }
        public string Crush_Operator { get; set; }
        public int? WrkShi_ID { get; set; }
        public DateTime? Crush_Horom_DateTimeStar { get; set; }
        public DateTime? Crush_Horom_DateTimeEnd { get; set; }
        public string Crush_Horom_TotalTime { get; set; }
        public string Crush_Status_Cod { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Crush_Status { get; set; }
    }
}



