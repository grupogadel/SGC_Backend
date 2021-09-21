using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.MineralReception
{
    public class ModelBatchMineral
    {
        [Key]
        public int BatchM_ID { get; set; }
        public string BatchM_ApprovedDoc { get; set; }
        public DateTime? BatchM_DateDoc { get; set; }
        public string BatchM_UserDoc { get; set; }
        public string BatchM_Status { get; set; }
        public int Scales_ID { get; set; }
        public string Scales_Lote { get; set; }
        public int Scales_NumSacos { get; set; }
        public string Scales_SubLote { get; set; }
        public decimal Scales_TMH {get; set; }
        public decimal Scales_TMH_Hist {get; set; }
        public DateTime Scales_DateInp {get; set; }
        public DateTime Scales_DateOut {get; set; }
        public string Scales_GuiRemRe_TaxID {get; set; }
        public string Scales_GuiRemRe_Serie {get; set; }
        public string Scales_GuiRemRe_Num {get; set; }
        public DateTime Scales_GuiRemRe_Date {get; set; }
        public string Scales_Conces_NO {get; set; }
        public string Scales_Conces_Name {get; set; }
        public string Scales_Commit_NO {get; set; }
        public string Scales_Patente {get; set; }
        public string Scales_DriverRUC {get; set; }
        public string Scales_DriverName {get; set; }
        public string Scales_GRDriv_Serie {get; set; }
        public string Scales_GRDriv_Num {get; set; }
        public DateTime Scales_GRDriv_Date {get; set; }
        public string Scales_MinOwner {get; set; }
        public string Scales_Operator {get; set; }
        public int MinType_ID {get; set; }
        public string MinType_Desc {get; set; }
        public int MinFrom_ID {get; set; }
        public string MinFrom_Name {get; set; }
        public int Period_ID {get; set; }
        public string Period_NO {get; set; }
        public int Orig_ID {get; set; }
        public string Orig_Name {get; set; }
        public int Zone_ID {get; set; }
        public string Zone_Name {get; set; }
        public int Vendor_ID {get; set; }
        public string Vendor_CatPers {get; set; }
        public string Vendor_TaxID {get; set; }
        public string Vendor_Desc {get; set; }
        public string Vendor_SurName {get; set; }
        public string Vendor_LastName {get; set; }
        public int Person_ID {get; set; }
        public string Person_DNI {get; set; }
        public string Person_Name {get; set; }
        public string Person_LastName {get; set; }
        public int AnalReq_ID {get; set; }
        public string AnalReq_Desc {get; set; }
        public int WrkShi_ID {get; set; }
        public string WrkShi_Desc {get; set; }
        
    }
}
