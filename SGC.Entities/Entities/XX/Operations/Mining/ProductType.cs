using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Operations.Mining
{
    public class ProductType
    {
        [Key]
        public int ProdType_ID { get; set; }
        public int Company_ID { get; set; }
        public string ProdType_Cod { get; set; }
        public string ProdType_Name { get; set; }
        public string ProdType_Desc { get; set; }
        public string ProdType_Area { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string ProdType_Status { get; set; }
    }
}
