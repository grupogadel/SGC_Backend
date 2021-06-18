using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.Commercial.SampleReferential
{
    public class SampleHeadReferential
    {
        [Key]
        public int SampH_ID { get; set; }
        public int Company_ID { get; set; }
        public int SampH_Current_Detail { get; set; }
        public string SampH_NO { get; set; }
        public string SampH_Type { get; set; }
        public string SampH_Desc { get; set; }
        public string SampH_Refer { get; set; }
        public DateTime SampH_Recep_Date { get; set; }
        public int Collec_ID { get; set; }
        public int Person_ID { get; set; }
        public string Person_DNI { get; set; }
        public string Person_Name { get; set; }
        public string Person_LastName { get; set; }
        public int UserAcc_ID { get; set; }
        public string SampH_ApprUser { get; set; }
        public DateTime? SampH_ApprDate { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string SampH_Status_Cod { get; set; }
        public string SampH_Status { get; set; }
        public List<SampleDetailsReferential> SampleDetailsReferentials { get; set; }
        public SampleHeadReferential()
        {
            SampleDetailsReferentials = new List<SampleDetailsReferential>();
        }

    }
}
