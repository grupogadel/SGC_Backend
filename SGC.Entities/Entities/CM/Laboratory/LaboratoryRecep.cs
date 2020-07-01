using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class LaboratoryRecep
    {
        public int? SampD_ID { get; set; }
        public string SampD_NO { get; set; }
        public int? LabProcTyp_ID { get; set; }
        public int? AnalType_ID { get; set; }
        public int? SampOrig_ID { get; set; }
        public int? MatType_ID { get; set; }
        public int? MinFrom_ID { get; set; }
        public DateTime? Modified_DateDet { get; set; }
        public string SampD_Status { get; set; }
        public string LabProcTyp_Cod { get; set; }
        public string LabProcTyp_Name { get; set; }
        public string LabProcTyp_Desc { get; set; }
        public string AnalType_Cod { get; set; }
        public string AnalType_Desc { get; set; }
        public string MinFrom_Cod { get; set; }
        public string MinFrom_Name { get; set; }
        public string MinFrom_Desc { get; set; }
        public string MatType_Cod { get; set; }
        public string MatType_Name { get; set; }
        public string MatType_Desc { get; set; }
        public string SampOrig_AreaCod { get; set; }
        public string SampOrig_AreaDesc { get; set; }
        public string SampOrig_Cod { get; set; }
        public string SampOrig_Module { get; set; }
        public string SampOrig_Desc { get; set; }
        public int? SampH_ID { get; set; }
        public int? Company_ID { get; set; }
        public string SampH_NO { get; set; }
        public string SampH_Type { get; set; }
        public int? BatchM_ID { get; set; }
        public string BatchM_Lote_New { get; set; }
        public int? Scales_ID { get; set; }
        public int? AnalReq_ID { get; set; }
        public string AnalReq_Desc { get; set; }
        public string SampH_Desc { get; set; }
        public string SampH_Refer { get; set; }
        public string SampH_Status_Cod { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampH_Status { get; set; }
    }
}
