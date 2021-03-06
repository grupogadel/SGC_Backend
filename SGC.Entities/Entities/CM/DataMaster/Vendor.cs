using SGC.Entities.Entities.XX.Entity;
using SGC.Entities.Entities.XX.Finance;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGC.Entities.Entities.CM.DataMaster
{
    public class Vendor
    {
        [Key]
        public int Vendor_ID { get; set; }
        public int? Company_ID { get; set; }
        public string Vendor_TaxID { get; set; }
        public string Vendor_CatPers { get; set; }
        public int? DocIdent_ID { get; set; }
        public int Country_ID { get; set; }
        public int CountryDist_ID { get; set; }
        public string CountryDist_Name { get; set; }
        public string Vendor_Class { get; set; }
        public string Vendor_Type { get; set; }
        public string Vendor_PostalCod { get; set; }
        public string Vendor_Desc { get; set; }
        public string Vendor_LastName { get; set; }
        public string Vendor_SurName { get; set; }
        public string Vendor_Address { get; set; }
        public int? Dist_ID { get; set; }
        public string Vendor_CelPhone { get; set; }
        public string Vendor_Email { get; set; }
        public decimal? Vendor_DetracPorc { get; set; }
        public int? Bank_ID_AcctLocal_NO { get; set; }
        public int? Currency_ID_AcctLocal_NO { get; set; }
        public string Vendor_AcctLocal_NO { get; set; }
        public int? Bank_ID_AcctLocalCCI_NO { get; set; }
        public int? Currency_ID_AcctLocalCCI_NO { get; set; }
        public string Vendor_AcctLocalCCI_NO { get; set; }
        public int? Bank_ID_AcctDetracc_NO { get; set; }
        public int? Currency_ID_AcctDetracc_NO { get; set; }
        public string Vendor_AcctDetracc_NO { get; set; }
        public string Creation_User { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string Vendor_Status { get; set; }
        public Country Country { get; set; }
        public District Districts { get; set; }
        public DocIdentity DocIdentitys { get; set; }
        public Bank Banks { get; set; }
        public Bank Banks1 { get; set; }
        public Bank Banks2 { get; set; }
        public Currency Currencys { get; set; }
        public Currency Currencys1 { get; set; }
        public Currency Currencys2 { get; set; }
    }
}
