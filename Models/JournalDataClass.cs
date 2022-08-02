using System.Collections.Generic;

namespace ConvertDatabase.WinApp.Models
{
    public class JournalDataClass
    {
        public List<MapColumn> MappingColumns { get; set; }

        public JournalFilesPath JournalFilesPath { get; set; }
        public MappingFilesPath MappingFilesPath { get; set; }

        public List<Journal> JournalList = new List<Journal>();
        public List<JournalItem> JournalItemList = new List<JournalItem>();
        public List<FiscalPeriod> FiscalPeriodList = new List<FiscalPeriod>();
        public List<DetailAccount> DetailAccountList = new List<DetailAccount>();
        public List<GeneralLedgerAccount> GeneralLedgerAccountList = new List<GeneralLedgerAccount>();
        public List<SubsidiaryLedgerAccount> SubsidiaryLedgerAccountList = new List<SubsidiaryLedgerAccount>();
        public List<AccountCategories> AccountCategoriesList = new List<AccountCategories>();
        public List<EquivalentSubsidiary> EquivalentGeneralList = new List<EquivalentSubsidiary>();
        public List<EquivalentSubsidiary> EquivalentSubsidiaryList = new List<EquivalentSubsidiary>();
        public List<EquivalentSubsidiary> EquivalentDetailList = new List<EquivalentSubsidiary>();
    }

    public class JournalFilesPath
    {
        //public string ImportSourcePath { get; set; } = "";
        //public string ImportTargetPath { get; set; } = "";
        //public string MappingFilePath { get; set; } = "";

        public string AccountCategoryFilePath { get; set; } = "";
        public string GeneralLedgerAccountFilePath { get; set; } = "";
        public string SubsidiaryLedgerAccountFilePath { get; set; } = "";
        public string DetailAccountsFilePath { get; set; } = "";
        public string FiscalPeriodFilePath { get; set; } = "";
        public string JournalFilePath { get; set; } = "";
        public string JournalItemFilePath { get; set; } = "";
        public string SubsidaryEquivalentFilePath { get; set; } = "";
        public string DetailEquivalentFilePath { get; set; } = "";
        public string GeneralEquivalentFilePath { get; set; } = "";
    }

    public class MappingFilesPath
    {
        public string DetailEquivalent { get; internal set; }
        public string GeneralEquivalent { get; internal set; }
        public string SubsidaryEquivalent { get; internal set; }
    }
}
