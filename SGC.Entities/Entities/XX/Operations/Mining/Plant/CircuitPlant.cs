using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.XX.Operations.Mining.Plant
{
    public class CircuitPlant
    {
        [Key]
        public int Circuit_ID { get; set; }
        public int Company_ID { get; set; }
        public int Plant_ID { get; set; }
        public int Circuit_Cod { get; set; }
        public string Circuit_Desc { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Circuit_Status { get; set; }
    }
}