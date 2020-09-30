using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Entities.Entities.CM.Laboratory
{
    public class ConsumeDetail
    {

        public int ConsuD_ID { get; set; }
        public int ConsuH_ID { get; set; }  
        public int LabS_ID { get; set; }
        public decimal ConsuD_CNLixHrs0 { get; set; }
        public decimal ConsuD_CNLixHrs2 { get; set; }
        public decimal ConsuD_CNLixHrs4 { get; set; }
        public decimal ConsuD_CNLixHrs8 { get; set; }   
        public decimal ConsuD_CNLixHrs12 { get; set; }
        public decimal ConsuD_CNLixHrs24 { get; set; }
        public decimal ConsuD_CNLixHrs48 { get; set; }
        public decimal ConsuD_CNLixHrs72 { get; set; }
        public decimal ConsuD_PHLixHrs0 { get; set; }
        public decimal ConsuD_PHLixHrs2 { get; set; }
        public decimal ConsuD_PHLixHrs4 { get; set; }
        public decimal ConsuD_PHLixHrs8 { get; set; }
        public decimal ConsuD_PHLixHrs12 { get; set; }
        public decimal ConsuD_PHLixHrs24 { get; set; }
        public decimal ConsuD_PHLixHrs48 { get; set; }
        public decimal ConsuD_PHLixHrs72 { get; set; }
        public decimal ConsuD_OHLixReacAgr0 { get; set; }
        public decimal ConsuD_OHLixReacAgr2 { get; set; }
        public decimal ConsuD_OHLixReacAgr4 { get; set; }
        public decimal ConsuD_OHLixReacAgr8 { get; set; }
        public decimal ConsuD_OHLixReacAgr12 { get; set; }
        public decimal ConsuD_OHLixReacAgr24 { get; set; }
        public decimal ConsuD_OHLixReacAgr48 { get; set; }
        public decimal ConsuD_OHLixReacAgr72 { get; set; }
        public decimal ConsuD_CNLLixReacAgr0 { get; set; }
        public decimal ConsuD_CNLLixReacAgr2 { get; set; }
        public decimal ConsuD_CNLLixReacAgr4 { get; set; }
        public decimal ConsuD_CNLLixReacAgr8 { get; set; }
        public decimal ConsuD_CNLLixReacAgr12 { get; set; }
        public decimal ConsuD_CNLLixReacAgr24 { get; set; }
        public decimal ConsuD_CNLLixReacAgr48 { get; set; }
        public decimal ConsuD_CNLLixReacAgr72 { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string ConsuD_Status { get; set; }
    }
}
