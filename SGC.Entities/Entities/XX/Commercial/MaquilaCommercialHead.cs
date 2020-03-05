using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.XX.Commercial
{
    public class MaquilaCommercialHead
    {
        public int Cond_ID { get; set; }
        public int Company_ID { get; set; }
        public string CreaModi_User { get; set; }
        public List<MaquilaCommercial> MaquilasCommercials { get; set; }
        public MaquilaCommercialHead()
        {
            MaquilasCommercials = new List<MaquilaCommercial>();
        }

    }
}
