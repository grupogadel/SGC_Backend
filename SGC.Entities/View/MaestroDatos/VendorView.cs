using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.View.MaestroDatos
{
    public class VendorView
    {
        public int Vendor_ID { get; set; }
        public int District_ID { get; set; }
        public string Vendor_NO { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_CatPers { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }
        public string Vendor_Address { get; set; }
        public string Vendor_CelPhone { get; set; }
        public string Vendor_Email { get; set; }
        public string Vendor_BankCod { get; set; }
        public string Vendor_BankAcct { get; set; }
        public string Vendor_BankCodDet { get; set; }
        public string Vendor_BankAcctDet { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Vendor_Status { get; set; }
    }
}
