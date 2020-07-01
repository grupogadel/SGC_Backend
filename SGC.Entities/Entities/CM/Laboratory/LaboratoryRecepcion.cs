using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class LaboratoryRecepcion
    {
        public DateTime SampD_RecLab_Date { get; set; }
        public string SampD_RecLab_Oper { get; set; }
        public List<int> LstSamples { get; set; }
    }
}
