using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Commercial.Proposal
{
    public class ModelProposal
    {
        public int LiquiH_ID { get; set; }
        public string LiquiUser { get; set; }
        public List<LiquidationAdvance> LiquidationAdvances { get; set; }
        public ModelProposal()
        {
            LiquidationAdvances = new List<LiquidationAdvance>();
        }
    }
}
