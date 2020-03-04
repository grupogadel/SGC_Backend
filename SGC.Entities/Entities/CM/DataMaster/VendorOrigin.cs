using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class VendorOrigin
    {
        [Key]
        public int Orig_ID { get; set; }
        public string Orig_Name { get; set; }
        public int Company_ID { get; set; }
        public List<Vendor> Vendors{ get; set; }
        public VendorOrigin()
        {
            Vendors = new List<Vendor>();
        }
    }
}
