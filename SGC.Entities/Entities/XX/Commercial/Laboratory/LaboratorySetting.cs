using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial.Laboratory
{
    public class LaboratorySetting
    {
        public int LabS_ID { get; set; }
        public int Company_ID { get; set; }
        public string LabS_Cod { get; set; }
        public string LabS_Name { get; set; }
        public decimal? LabS_GravEsP1 { get; set; }
        public decimal? LabS_GravEsP2 { get; set; }
        public decimal? LabS_GravEsP3 { get; set; }
        public decimal? LabS_GravEsP4 { get; set; }
        public decimal? LabS_GravEsR { get; set; }
        public decimal? LabS_GravEsP { get; set; }
        public decimal? LabS_ParLixDens { get; set; }
        public decimal? LabS_ParLixK { get; set; }
        public decimal? LabS_ParLixPorSol { get; set; }
        public decimal? LabS_ParLixPorLiq { get; set; }
        public decimal? LabS_ParLixDilucion { get; set; }
        public decimal? LabS_ParLixMalla200 { get; set; }
        public decimal? LabS_ParSamWeight { get; set; }
        public decimal? LabS_SamH2OMml { get; set; }
        public decimal? LabS_SamTot { get; set; }
        public decimal? LabS_VolumDesech2 { get; set; }
        public decimal? LabS_VolumDesech4 { get; set; }
        public decimal? LabS_VolumDesech8 { get; set; }
        public decimal? LabS_VolumDesech12 { get; set; }
        public decimal? LabS_VolumDesech24 { get; set; }
        public decimal? LabS_VolumDesech48 { get; set; }
        public decimal? LabS_VolumDesech72 { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string LabS_Status { get; set; }
    }
}
