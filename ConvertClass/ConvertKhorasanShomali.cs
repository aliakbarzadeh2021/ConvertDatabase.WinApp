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
    public class ConvertKhorasanShomali : IJournalConvert
    {
        string FilePath = @"\Files\KhorasanShomali\";
        string branchId = "Ls5Apa5DQwbC7ZqveKkH7n";
        FileRepository fileRepository = new FileRepository();
        public void Execute()
        {
            fileRepository.GetFilePath(FilePath);
            fileRepository.ImportDestinationData();

            CreateJournal();

            fileRepository.ExportData();
        }

        public List<string> UniqueSanadNumberList(DataTable data)
        {
            var result = new List<string>();
            foreach (DataRow item in data.Rows)
            {
                if (!result.Exists(i => i == item["NumF"].ToString()))
                {
                    result.Add(item["NumF"].ToString());
                }
            }
            return result;
        }

        public async void CreateJournal()
        {
            var journalDB = await fileRepository.GetOLEDB(FilePath + @"\dbSource\panahi1400.MDB", "8k#w%sXzKlAq!209_+4#");
            var SanadTable = journalDB.Tables["SANAD"];
            var SanadList = SanadTable.AsEnumerable().GroupBy(r => r["NUMF"]);

            foreach (var sanadItems in SanadList)
            {
                MapVoucher(sanadItems);
            }


        }

        private void MapVoucher(IGrouping<object, DataRow> sanadItems)
        {
            var journalData = sanadItems.First();
            var date = journalData["Date_fac"].ToString();
            if (date.Substring(0, 4) != "1399")
            {
                return;
            }

            var journal = new Journal();
            journal.branchId = branchId;
            journal.id = Guid.NewGuid();
            journal.number = journalData["NUMF"].ToString();
            journal.temporaryNumber = journalData["NUMF"].ToString();
            journal.date = date;
            journal.temporaryDate = date;
            journal.createdAt = Helper.ConvertToMiladi(date);
            journal.updatedAt = Helper.ConvertToMiladi(date);
            journal.createdById = "ADMIN";
            journal.fiscalPeriodId = fileRepository.destinationData.FiscalPeriodList.FindLast(a => a.title.Contains(date.Substring(0, 4))).id;
            journal.description = journalData["SH_2"].ToString();
            journal.journalStatus = "Temporary";
            journal.issuer = "Accounting";
            journal.includeSeasonDeals = "f";
            journal.isInComplete = "f";
            journal.isMergedJournal = "f";
            var sumCreditor = 0.0;
            var sumDebtor = 0.0;

            foreach (DataRow row in sanadItems)
            {
                var journalItem = new JournalItem();
                journalItem.id = Guid.NewGuid();
                journalItem.branchId = branchId;
                journalItem.journalId = journal.id.ToString();
                SubsidiaryLedgerAccount subsidiaryLedgerAccount = GetSubsidiaryLedgerAccount(row);
                DetailAccount detailAccount = null, dimension1 = null, dimension2 = null, dimension3 = null;

                if (!string.IsNullOrEmpty(row["TAFSIL"].ToString()) && row["TAFSIL"].ToString() != "0000")
                {
                    detailAccount = GetDetailAccount(row);
                    if (detailAccount == null)
                    {
                        throw new Exception();
                    }

                    detailAccount.isDetailAccount = "t";
                    subsidiaryLedgerAccount.hasDetailAccount = "t";
                }

                journalItem.row = int.Parse(row["Radif"].ToString());
                journalItem.generalLedgerAccountId = subsidiaryLedgerAccount.generalLedgerAccountId;
                journalItem.subsidiaryLedgerAccountId = subsidiaryLedgerAccount.id;
                journalItem.detailAccountId = detailAccount != null ? detailAccount.id.ToString() : null;
                //journalItem.dimension1Id = dimension1 != null ? dimension1.id.ToString() : null;
                //journalItem.dimension2Id = dimension2 != null ? dimension2.id.ToString() : null;
                journalItem.article = row["SH_2"].ToString() + " -- " + row["SH_1"].ToString();
                journalItem.debtor = double.Parse(row["BED"].ToString());
                journalItem.creditor = double.Parse(row["BES"].ToString());
                journalItem.createdAt = Helper.ConvertToMiladi(row["Date_fac"].ToString());
                journalItem.updatedAt = Helper.ConvertToMiladi(row["Date_fac"].ToString());
                journalItem.createdById = "ADMIN";
                sumCreditor += journalItem.creditor;
                sumDebtor += journalItem.debtor;

                fileRepository.destinationData.JournalItemList.Add(journalItem);
            }


            journal.debtor = sumDebtor;
            journal.creditor = sumCreditor;

            fileRepository.destinationData.JournalList.Add(journal);

        }

        private SubsidiaryLedgerAccount GetSubsidiaryLedgerAccount(DataRow voucherItemRow)
        {
            var code = voucherItemRow["IDMOIN"].ToString();
            var equivalent = fileRepository.destinationData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account;
                }
                // TODO : Create Account

            }
            return fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(a => a.code == code);
        }

        private DetailAccount GetDetailAccount(DataRow voucherItemRow)
        {
            var code = voucherItemRow["TAFSIL"].ToString();
            var equivalent = fileRepository.destinationData.EquivalentDetailList.FindLast(i => i.OldCode == code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.DetailAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account;
                }
                // TODO : Create Account

            }
            return fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == code);
        }



        public void CreateAccountCategory()
        {
            throw new NotImplementedException();
        }

        public void CreateDetailAccounts()
        {
            throw new NotImplementedException();
        }

        public void CreateFiscalPeriod()
        {
            throw new NotImplementedException();
        }

        public void CreateGeneralLedgerAccount()
        {
            throw new NotImplementedException();
        }



        public void CreateSubsidiaryLedgerAccount()
        {
            throw new NotImplementedException();
        }


    }
}
