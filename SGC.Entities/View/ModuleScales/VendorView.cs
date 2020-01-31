using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.View.ModuleScales
{
    public class VendorView
    {
        public int vendor_ID { get; set; }
        public string vendor_LastName { get; set; }
        public string vendor_SurName { get; set; }
        public bool vendor_Status { get; set; }
    }
}
