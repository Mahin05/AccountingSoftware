using System;

namespace Atrai.Core.ViewModel
{
    public class COAUploadDTO
    {
        public int SLNo { get; set; }
        public string AccountCode { get; set; }
        public string AccountHead { get; set; }
        public string ParentHead { get; set; }
        public string AccountType { get; set; }
        public string LedgerType { get; set; }
        public double OpeningDr { get; set; }
        public double OpeningCr { get; set; }
        public string RefNo { get; set; }

    }
    public class CustomerUploadDTO
    {
        public int Id { get; set; }
        public string SecoundaryAddress { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string CustType { get; set; }
        public decimal OpBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal MonthlyTarget { get; set; }
        public decimal CustomerCommissionPer { get; set; }
        public decimal SRCommissionPer { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonName { get; set; }
        public string Website { get; set; }
        public decimal ClBalance { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Other { get; set; }
        public int PaymentTermsId { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingProvince { get; set; }
        public string BillingStreetAddress { get; set; }
        public string DeliveryOptions { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string Language { get; set; }
        public string MiddelName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingProvince { get; set; }
        public string ShippingStreetAddress { get; set; }
        public decimal Taxes { get; set; }
        public string CustomerCode { get; set; }
        public decimal OverDueBalance { get; set; }
    }
    public class SupplierUploadDTO
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PrimaryAddress { get; set; }
        public string Notes { get; set; }
        public string City { get; set; }
        public string SecondaryAddress { get; set; }
        public string SupType { get; set; }
        public decimal OpBalance { get; set; }
        public decimal SupplierCommissionPer { get; set; }
        public string TradeLicenseNo { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonName { get; set; }
        public string Website { get; set; }
        public decimal ClBalance { get; set; }
        public string AccountNo { get; set; }
        public decimal BillingRate { get; set; }
        public string BusinessIdNo { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string FilePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Mobileno { get; set; }
        public string Other { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string StreetAddress { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string StatusRemarks { get; set; }
        public string SupplierCode { get; set; }
    }
    public class VocherUploadDto
    {

        public string VoucherNo { get; set; }
        public string VoucherDate { get; set; }
        public string VoucherInputDate { get; set; }
        public string VoucherType { get; set; }
        public string VoucherDesc { get; set; }
        public string Ledger { get; set; }
        public string Currency { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        public string Note { get; set; }
        public string Reference { get; set; }



    }
}
