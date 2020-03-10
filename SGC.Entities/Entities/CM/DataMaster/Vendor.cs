using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Vendor
    {
        [Key]
        public int Vendor_ID { get; set; }
        public string Vendor_Cod { get; set; }
        public int Company_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_CatPers { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }
        public string Vendor_Address { get; set; }
        public int Dist_ID { get; set; }
        public string Vendor_CelPhone { get; set; }
        public string Vendor_Email { get; set; }
        public string Bank_Acct_Cod { get; set; }
        public string Vendor_BankAcct { get; set; }
        public string Bank_AcctDet_Cod { get; set; }
        public string Vendor_BankAcctDet { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Vendor_Status { get; set; }
    }
}
