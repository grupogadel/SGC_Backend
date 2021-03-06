using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class MaterialType
    {
        public int MatType_ID { get; set; }
        public int Company_ID { get; set; }
        public string MatType_Cod { get; set; }
        public string MatType_Name { get; set; }
        public string MatType_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string MatType_Status { get; set; }
    }
}
