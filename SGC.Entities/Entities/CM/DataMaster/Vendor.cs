using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Vendor
    {
        [Key]
        public int Vendor_ID { get; set; }
        public int VendorOrig_ID { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }
        public int Company_ID { get; set; }

    }
}
