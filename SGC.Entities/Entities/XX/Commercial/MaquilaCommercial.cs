using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial
{
    public class MaquilaCommercial
    {
        [Key]
        public int MaqComm_ID { get; set; }
        public int Cond_ID { get; set; }
        public int Company_ID { get; set; }
        public decimal MaqComm_LeyFrom { get; set; }
        public decimal MaqComm_LeyTo { get; set; }
        public decimal MaqComm_Maquila { get; set; }
        public decimal MaqComm_Recov { get; set; }
        public decimal MaqComm_MarginPI { get; set; }
        public decimal MaqComm_Consu { get; set; }
        public decimal MaqComm_ExpAdm { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string MaqComm_Status { get; set; }
    }
}
