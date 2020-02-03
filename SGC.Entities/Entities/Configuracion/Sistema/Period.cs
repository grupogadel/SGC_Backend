using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.Configuracion.Sistema
{
    public class Period
    {
        public int Period_ID { get; set; }
        public int Company_ID { get; set; }
        public string Period_Value { get; set; }
        public string Period_Cod { get; set; }
        public string Period_Year { get; set; }
        public DateTime Period_Date_Start { get; set; }
        public DateTime Period_Date_End { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Period_Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual Global Period_Global { get; set; }
        public virtual Global Status { get; set; }
    }
}
