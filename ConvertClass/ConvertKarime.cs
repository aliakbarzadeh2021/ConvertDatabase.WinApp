using ConvertDatabase.WinApp.Helpers;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConvertDatabase.WinApp.ConvertClass
{
    // Converting Flow :
    //
    // 1. Import Source File/DB
    // 2. Import Target File/DB
    // 3. Map Table
    // 4. Map Column
    // 5. Map Data
    // 6. Convert
    // 7. Export Target File/DB
    //
    public class ConvertKarime : IShahd
    {
        string branchId = "wuEzdVJylHepQzc80sfTqHT";
        FileRepository fileRepository = new FileRepository();

        public void Execute()
        {
            fileRepository.ImportSourceData();

            //CreateAccountCategory();
            //CreateGeneralLedgerAccount();
            //CreateSubsidiaryLedgerAccount();
            //CreateDetailAccounts();
            //CreateFiscalPeriod();
            CreateJournal();


            fileRepository.ExportData();
        }

        public void CreateAccountCategory()
        {

        }

        public void CreateGeneralLedgerAccount()
        {

        }

        public void CreateSubsidiaryLedgerAccount()
        {

        }

        public void CreateDetailAccounts()
        {

        }

        public void CreateFiscalPeriod()
        {

        }

        public void CreateJournal()
        {
            DataTable data = fileRepository.GetData("SELECT * FROM Asnad");
            var fiscalPeriodId = GetPeriodId();
            var uniqueSanadNumberList = UniqueSanadNumberList();
            foreach (var sanadNo in uniqueSanadNumberList)
            {
                var itemFound = fileRepository.destinationData.JournalList.Any(i => i.temporaryNumber == sanadNo);
                if (!itemFound)
                {
                    MapVoucher(data, fiscalPeriodId, sanadNo);
                }

            }
        }

        private void MapVoucher(DataTable data, Guid fiscalPeriodId, string sanadNo)
        {
            var journal = new Journal();
            journal.branchId = branchId;
            journal.id = Guid.NewGuid();
            var sumCreditor = 0.0;
            var sumDebtor = 0.0;

            foreach (DataRow item in data.Rows)
            {
                if (item[22].ToString() == sanadNo)
                {
                    var subItemFound = fileRepository.destinationData.JournalList.Any(i => i.temporaryNumber == item[22].ToString());
                    if (!subItemFound)
                    {
                        MapVoucherItem(fiscalPeriodId, journal, ref sumCreditor, ref sumDebtor, item);
                    }

                }
            }

            journal.creditor = sumCreditor;
            journal.debtor = sumDebtor;
            fileRepository.destinationData.JournalList.Add(journal);
        }

        private void MapVoucherItem(Guid fiscalPeriodId, Journal journal, ref double sumCreditor, ref double sumDebtor, DataRow item)
        {
            journal.accountingType = "";
            journal.attachmentFileName = "";
            journal.createdAt = Helper.ConvertToMiladi(item[7].ToString());
            journal.updatedAt = Helper.ConvertToMiladi(item[7].ToString());
            journal.createdById = "ADMIN";
            journal.date = item[7].ToString();
            journal.description = item[19].ToString();
            journal.fiscalPeriodId = fiscalPeriodId;
            journal.includeSeasonDeals = "f";
            journal.isInComplete = "f";
            journal.isMergedJournal = "f";
            journal.issuer = "Accounting";
            journal.journalDetailId = "";
            journal.journalParentId = "";
            journal.journalStatus = "Temporary";
            journal.journalType = "";
            journal.number = item[22].ToString();
            journal.reference = "";
            //journal.tagId = "";
            journal.temporaryDate = item[7].ToString();
            journal.temporaryNumber = item[22].ToString();

            var subsidary = GetSubsidiaryLedgerAccount(item[26].ToString());
            var journalItem = new JournalItem();
            journalItem.id = Guid.NewGuid();
            journalItem.branchId = branchId;
            journalItem.journalId = journal.id.ToString();
            journalItem.generalLedgerAccountId = subsidary.generalLedgerAccountId;
            journalItem.subsidiaryLedgerAccountId = subsidary.id;
            journalItem.detailAccountId = GetdetailAccountId(item[27].ToString());
            journalItem.article = item[9].ToString();
            journalItem.createdAt = Helper.ConvertToMiladi(item[7].ToString());
            journalItem.createdById = "ADMIN";
            journalItem.creditor = double.Parse(item[1].ToString());
            journalItem.debtor = double.Parse(item[0].ToString());
            journalItem.dimension1Id = "";
            journalItem.dimension2Id = "";
            journalItem.dimension3Id = "";
            journalItem.receiptDate = "";
            journalItem.receiptNumber = "";
            journalItem.row = int.Parse(item[2].ToString());
            journalItem.updatedAt = Helper.ConvertToMiladi(item[7].ToString());

            sumCreditor += journalItem.creditor;
            sumDebtor += journalItem.debtor;

            fileRepository.destinationData.JournalItemList.Add(journalItem);
        }



        private SubsidiaryLedgerAccount GetSubsidiaryLedgerAccount(string code)
        {
            var equivalent = fileRepository.destinationData.EquivalentSubsidiaryList.FirstOrDefault(i => i.OldCode == code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FirstOrDefault(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account == null)
                {
                    return null;
                }
                return account;
            }
            return null;
        }

        private string GetdetailAccountId(string code)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
            {
                return null;
            }
            var account = fileRepository.destinationData.DetailAccountList.FirstOrDefault(i => int.Parse(i.code) == int.Parse(code));
            if (account == null)
            {
                return null;
            }
            return account.id.ToString();
        }

        public List<string> UniqueSanadNumberList()
        {
            DataTable data = fileRepository.GetData("SELECT * FROM Asnad");

            var result = new List<string>();
            foreach (DataRow item in data.Rows)
            {
                if (!result.Exists(i => i == item[22].ToString()))
                {
                    result.Add(item[22].ToString());
                }
            }
            return result;
        }

        private Guid GetPeriodId()//string start, string end)
        {
            //var period = FiscalPeriodList.Where(i => i.minDate == start && i.maxDate == end).FirstOrDefault();

            var period = new FiscalPeriod();
            period.branchId = branchId;
            period.id = Guid.NewGuid();
            //period.Ref = "";
            period.isClosed = "f";
            period.title = "سال 1399";
            period.minDate = "1399/01/01";
            period.maxDate = "1399/12/29";
            period.createdById = "ADMIN";
            fileRepository.destinationData.FiscalPeriodList.Add(period);


            return period.id;
        }



    }
}
