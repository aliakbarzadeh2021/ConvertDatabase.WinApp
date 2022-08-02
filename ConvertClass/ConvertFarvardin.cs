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
    public class ConvertFarvardin : IJournalConvert
    {
        string FilePath = @"\Files\Farvardin\";
        string branchId = "Eakvn2ivVzs1TA3wqCA2YP";
        FileRepository fileRepository = new FileRepository();
        public void Execute()
        {
            fileRepository.GetFilePath(FilePath);
            //fileRepository.ImportSourceData();
            fileRepository.ImportDestinationDataFromExcel();
            ChangeBranchId(branchId);

            //MapJournal(branchId);
            CreateJournal();



            fileRepository.ExportData();
        }

        private void ChangeBranchId(string branchId)
        {
            foreach (var item in fileRepository.destinationData.AccountCategoriesList)
            {
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.GeneralLedgerAccountList)
            {
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.SubsidiaryLedgerAccountList)
            {
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.DetailAccountList)
            {
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.FiscalPeriodList)
            {
                item.id = Guid.NewGuid();
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.JournalList)
            {
                item.branchId = branchId;
            }
            foreach (var item in fileRepository.destinationData.JournalItemList)
            {
                item.branchId = branchId;
            }
        }

        private void MapJournal(string branchId)
        {
            var journals = fileRepository.sourceData.JournalList;
            foreach (var journal in journals)
            {
                journal.fiscalPeriodId = MapEquivalentFiscalPeriod(journal);
                journal.branchId = branchId;
            }


            var JournalItems = fileRepository.sourceData.JournalItemList;
            foreach (var journalItem in JournalItems)
            {
                journalItem.generalLedgerAccountId = MapEquivalentGeneral(journalItem);
                journalItem.subsidiaryLedgerAccountId = MapEquivalentSubsidiary(journalItem);
                journalItem.branchId = branchId;
                //journalItem.detailAccountId = MapEquivalentDetail(journalItem);

            }

            foreach (var journal in journals)
            {
                var journalId = Guid.NewGuid();

                foreach (var journalItem in JournalItems)
                {

                    if (journal.id.ToString() == journalItem.journalId)
                    {
                        journalItem.journalId = journalId.ToString();
                        journalItem.id = Guid.NewGuid();
                    }

                }
                journal.id = journalId;
            }
        }

        private Guid MapEquivalentFiscalPeriod(Journal journal)
        {
            var fiscalPeriod = fileRepository.destinationData.FiscalPeriodList.FindLast(a => a.title.Contains(journal.temporaryDate.Substring(0, 4)));
            return fiscalPeriod.id;
        }

        private string MapEquivalentDetail(JournalItem journalItem)
        {
            var sourceDetail = fileRepository.sourceData.DetailAccountList.FirstOrDefault(i => i.id == Guid.Parse(journalItem.detailAccountId));
            var equivalent = fileRepository.sourceData.EquivalentDetailList.FindLast(i => i.OldCode == sourceDetail.code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.DetailAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account.id.ToString();
                }
            }
            return journalItem.detailAccountId;
        }

        private Guid MapEquivalentSubsidiary(JournalItem journalItem)
        {
            var sourceDetail = fileRepository.sourceData.SubsidiaryLedgerAccountList.FirstOrDefault(i => i.id == journalItem.subsidiaryLedgerAccountId);
            var equivalent = fileRepository.sourceData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == sourceDetail.code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account.id;
                }
            }
            var mapSameAccount = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(sourceDetail.code));
            return mapSameAccount.id;
        }

        private Guid MapEquivalentGeneral(JournalItem journalItem)
        {
            var sourceDetail = fileRepository.sourceData.GeneralLedgerAccountList.FirstOrDefault(i => i.id == journalItem.generalLedgerAccountId);
            var equivalent = fileRepository.sourceData.EquivalentGeneralList.FindLast(i => i.OldCode == sourceDetail.code);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.GeneralLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account.id;
                }
            }
            var mapSameAccount = fileRepository.destinationData.GeneralLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(sourceDetail.code));
            return mapSameAccount.id;
        }


        public async void CreateJournal()
        {
            var journalDB = await fileRepository.GetOLEDB(FilePath + @"dbSource\SANAD_M.mdb");
            var journalItemDB = await fileRepository.GetOLEDB(FilePath + @"dbSource\SANAD_D.mdb");

            foreach (DataRow row in journalDB.Tables["SANAD_M"].Rows)
            {
                var date = Helper.PersianDateFormat(row["DAT"].ToString());
                var journal = new Journal();
                journal.branchId = branchId;
                journal.id = Guid.NewGuid();
                journal.number = row["CODE"].ToString();
                journal.temporaryNumber = row["CODE"].ToString();
                journal.date = date;
                journal.temporaryDate = date;
                journal.createdAt = Helper.ConvertToMiladi(date);
                journal.updatedAt = Helper.ConvertToMiladi(date);
                journal.createdById = "JK2FQgkwzmWwjBZWLf17rv";
                journal.fiscalPeriodId = fileRepository.destinationData.FiscalPeriodList.FindLast(a => a.title.Contains(date.Substring(0, 4))).id;
                journal.description = row["SHRH"].ToString();
                journal.journalStatus = "Temporary";
                journal.issuer = "Accounting";
                journal.includeSeasonDeals = "f";
                journal.isInComplete = "f";
                journal.isMergedJournal = "f";
                var sumCreditor = 0.0;
                var sumDebtor = 0.0;

                foreach (DataRow itemRow in journalItemDB.Tables["SANAD_D"].Rows)
                {

                    if (itemRow["SHOM"].ToString() == row["CODE"].ToString())
                    {
                        var journalItem = new JournalItem();
                        journalItem.id = Guid.NewGuid();
                        journalItem.branchId = branchId;
                        journalItem.journalId = journal.id.ToString();
                        SubsidiaryLedgerAccount subsidiaryLedgerAccount = GetSubsidiaryLedgerAccount(itemRow);
                        DetailAccount detailAccount = null, dimension1 = null, dimension2 = null, dimension3 = null;

                        if (!string.IsNullOrEmpty(itemRow["BCOD"].ToString()))
                        {
                            detailAccount = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == itemRow["BCOD"].ToString());

                            if (detailAccount == null)
                            {
                                throw new Exception();
                            }

                            detailAccount.isDetailAccount = "t";
                            subsidiaryLedgerAccount.hasDetailAccount = "t";
                        }

                        journalItem.row = int.Parse(itemRow["RADF"].ToString());
                        journalItem.generalLedgerAccountId = subsidiaryLedgerAccount.generalLedgerAccountId;
                        journalItem.subsidiaryLedgerAccountId = subsidiaryLedgerAccount.id;
                        journalItem.detailAccountId = detailAccount != null ? detailAccount.id.ToString() : null;
                        //journalItem.dimension1Id = dimension1 != null ? dimension1.id.ToString() : null;
                        //journalItem.dimension2Id = dimension2 != null ? dimension2.id.ToString() : null;
                        journalItem.article = itemRow["SHRH"].ToString();
                        journalItem.debtor = double.Parse(itemRow["BEDH"].ToString());
                        journalItem.creditor = double.Parse(itemRow["BEST"].ToString());
                        journalItem.createdAt = itemRow["LUPD"].ToString();
                        journalItem.updatedAt = itemRow["LUPD"].ToString();
                        journalItem.createdById = "JK2FQgkwzmWwjBZWLf17rv";
                        sumCreditor += journalItem.creditor;
                        sumDebtor += journalItem.debtor;

                        fileRepository.destinationData.JournalItemList.Add(journalItem);
                    }
                }

                journal.debtor = sumDebtor;
                journal.creditor = sumCreditor;

                fileRepository.destinationData.JournalList.Add(journal);
            }
        }

        private SubsidiaryLedgerAccount GetSubsidiaryLedgerAccount(DataRow voucherItemRow)
        {
            var code = voucherItemRow["MCOD"].ToString();
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

            //var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(code));
            //if (account != null)
            //{
            //    return account;
            //}

            //return null;
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

        public void CreateSubsidiaryLedgerAccount()
        {
            throw new NotImplementedException();
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
    }
}
