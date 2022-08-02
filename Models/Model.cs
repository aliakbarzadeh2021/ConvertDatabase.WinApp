using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDatabase.WinApp.Models
{
    public class AccountCategories
    {
        public Guid id { get; set; }
        public string branchId { get; set; }
        public string key { get; set; }
        public string display { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string postingType { get; set; }
        public string createdById { get; set; }
        public string type { get; set; }
        public string AccountId { get; internal set; }
    }

    public class GeneralLedgerAccount
    {
        public Guid id { get; set; }
        public Guid categoryId { get; set; }
        public string branchId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string description { get; set; }
        public string postingType { get; set; }

        //bool
        public string isLocked { get; set; }
        public string createdById { get; set; }
        public string AccountId { get; internal set; }
    }

    public class SubsidiaryLedgerAccount
    {
        public Guid id { get; set; }
        public string branchId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public Guid generalLedgerAccountId { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string description { get; set; }
        public string balanceType { get; set; }
        public string createdById { get; set; }

        //bool
        public string hasDetailAccount { get; set; }
        public string hasDimension1 { get; set; }
        public string hasDimension2 { get; set; }
        public string hasDimension3 { get; set; }
        public string isBankAccount { get; set; }
        public string isLocked { get; set; }
        public string AccountId { get; internal set; }
    }

    public class DetailAccount
    {
        public Guid id { get; set; }
        public string branchId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string nationalCode { get; set; }
        public string email { get; set; }
        public string personType { get; set; }
        //public string referenceId { get; set; }
        public string economicCode { get; set; }
        public string registrationNumber { get; set; }
        public string bank { get; set; }
        public string bankBranch { get; set; }
        public string bankAccountNumber { get; set; }
        public string detailAccountType { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string mobile { get; set; }
        public string accountNumber { get; set; }
        public string accountCartNumber { get; set; }
        public string fax { get; set; }
        public string createdById { get; set; }
        public string bankAccountCartNumber { get; set; }
        //public string priceListId { get; set; }        
        public string marketerCommissionRate { get; set; }
        public string title2 { get; set; }
        //public string bankTypeId { get; set; }
        public string shaba { get; set; }
        public string accountOwner { get; set; }
        public string initialBalance { get; set; }
        //public string pos_connectedBankId { get; set; }
        //public string gateway_connectedBankId { get; set; }
        public string pos_terminalNumber { get; set; }
        public string gateway_terminalNumber { get; set; }
        public string person_bankAccountNumber { get; set; }
        public string person_shaba { get; set; }
        public string customerTaxAdministrationCategory { get; set; }
        public string supplierTaxAdministrationCategory { get; set; }
        //public string person_bankTypeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        //bool
        public string isDetailAccount { get; set; }
        public string isDimension1 { get; set; }
        public string isDimension2 { get; set; }
        public string isDimension3 { get; set; }
        public string isMarketer { get; set; }
        public string isCustomer { get; set; }
        public string isSupplier { get; set; }
        public string AccountId { get; internal set; }
    }

    public class FiscalPeriod
    {
        internal string oldId;

        public Guid id { get; set; }
        public string branchId { get; set; }
        //public string Ref { get; set; }
        public string minDate { get; set; }
        public string maxDate { get; set; }
        public string title { get; set; }

        //bool
        public string isClosed { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string createdById { get; set; }
    }

    public class Journal
    {
        public Guid id { get; set; }
        public string branchId { get; set; }
        public string number { get; set; }
        public string temporaryNumber { get; set; }
        public string temporaryDate { get; set; }
        public string date { get; set; }
        public Guid fiscalPeriodId { get; set; }
        public string description { get; set; }
        public string journalStatus { get; set; }
        public string journalType { get; set; }
        public string issuer { get; set; }
        public double debtor { get; set; }
        public double creditor { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string createdById { get; set; }
        public string attachmentFileName { get; set; }
        //public string tagId { get; set; }
        public string reference { get; set; }
        public string accountingType { get; set; }
        public string journalDetailId { get; set; }
        public string journalParentId { get; set; }

        //bool
        public string isMergedJournal { get; set; }
        public string isInComplete { get; set; }
        public string includeSeasonDeals { get; set; }
    }

    public class JournalItem
    {
        public Guid id { get; set; }
        public string branchId { get; set; }
        public string journalId { get; set; }
        public int row { get; set; }
        public Guid generalLedgerAccountId { get; set; }
        public Guid subsidiaryLedgerAccountId { get; set; }
        public string detailAccountId { get; set; }
        public string article { get; set; }
        public double debtor { get; set; }
        public double creditor { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string dimension1Id { get; set; }
        public string dimension2Id { get; set; }
        public string dimension3Id { get; set; }
        public string receiptNumber { get; set; }
        public string receiptDate { get; set; }
        public string createdById { get; set; }
    }

    public class EquivalentSubsidiary
    {
        public string OldCode { get; set; }
        public string NewCode { get; set; }

    }

    public enum ConvertType
    {
        Karime,
        Hamedan
    }
}
