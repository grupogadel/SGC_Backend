using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.View.Configuracion.Sistema
{
    public class PeriodView
    {
        public int Id { get; set; }
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

        //Datos de Tipo de Periodo
        public int Period_Value_ID { get; set; }
        public string Period_Name { get; set; }
        public string Period_Name2 { get; set; }

        //Datos Tipo de Estado
        public int Status_ID { get; set; }
        public string Status_Name { get; set; }
    }
}
