using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

using SGC.Entities.Entities.CM.DataMaster.Commercial;
using SGC.Entities.Entities.CM.DataMaster;
using SGC.Entities.Entities.XX.Operations.Mining;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class Scales
    {
        [Key]
        public int Scales_ID { get; set; }
        public int Vendor_ID { get; set; }
        public int Company_ID { get; set; }
        public string Scales_Lote { get; set; }
        public string Scales_SubLote { get; set; }
        public int MinType_ID { get; set; }
        public int AnalReq_ID { get; set; }
        public int MinFrom_ID { get; set; }
        public string Scales_MinOwner { get; set; }
        public DateTime? Scales_DateInp { get; set; }
        public DateTime? Scales_DateOut { get; set; }
        public int Orig_ID { get; set; }
        public int Collec_ID { get; set; }
        public int WrkShi_ID { get; set; }
        public string Scales_Operator { get; set; }
        public string Scales_GuiRemRe_TaxID { get; set; }
        public DateTime? Scales_GuiRemRe_Date { get; set; }
        public string Scales_GuiRemRe_Serie { get; set; }
        public string Scales_GuiRemRe_Num { get; set; }
        public int? Scales_NumSacos { get; set; }
        public decimal? Scales_TMH { get; set; }
        public decimal? Scales_TMH_Hist { get; set; }
        public string Scales_DriverRUC { get; set; }
        public string Scales_DriverName { get; set; }
        public string Scales_GRDriv_Serie { get; set; }
        public string Scales_GRDriv_Num { get; set; }
        public DateTime? Scales_GRDriv_Date { get; set; }
        public string Scales_Patente { get; set; }
        public string Scales_Conces_NO { get; set; }
        public string Scales_Conces_Name { get; set; }
        public string Scales_Commit_NO { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Scales_Status { get; set; }
        public MineralsType MineralTypes { get; set; }
        public AnalysisRequest AnalysisRequests { get; set; }
        public MineralFrom MineralFroms { get; set; }
        public Origin Origins { get; set; }
        public Collector Collectors { get; set; }
        public WorkShifts WorkShifts { get; set; }
        public Vendor Vendors { get; set; }
    }
}