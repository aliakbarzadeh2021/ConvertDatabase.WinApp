using ConvertDatabase.WinApp.Helpers;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Data;

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
    public class ConvertSaderat : IAfra
    {
        string branchId = "spncY6QGW2vA7MHJpuQGWa";
        FileRepository fileRepository = new FileRepository();
        public void Execute()
        {
            fileRepository.ImportSourceData();

            CreateAccountCategory();
            CreateGeneralLedgerAccount();
            CreateSubsidiaryLedgerAccount();
            CreateDetailAccounts();
            CreateFiscalPeriod();
            CreateJournal();


            fileRepository.ExportData();
        }

        public void CreateAccountCategory()
        {
            var data = fileRepository.GetData("SELECT * FROM AccPL");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.AccountCategoriesList.Add(new AccountCategories()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    key = item["pl_Code"].ToString(),
                    display = item["pl_Title"].ToString(),
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN",
                });
            }
        }

        public void CreateGeneralLedgerAccount()
        {
            var data = fileRepository.GetData("SELECT * FROM AccGL");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.GeneralLedgerAccountList.Add(new GeneralLedgerAccount()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    code = item["gl_Code"].ToString(),
                    title = item["gl_Title"].ToString(),
                    categoryId = fileRepository.destinationData.AccountCategoriesList.FindLast(i => i.key == item["PlRef"].ToString()).id,
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN",
                });
            }
        }

        public void CreateSubsidiaryLedgerAccount()
        {
            var data = fileRepository.GetData("SELECT * FROM AccSL");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.SubsidiaryLedgerAccountList.Add(new SubsidiaryLedgerAccount()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    code = item["sl_Code"].ToString(),
                    title = item["sl_Title"].ToString(),
                    generalLedgerAccountId = fileRepository.destinationData.GeneralLedgerAccountList.FindLast(i => i.code == item["GlRef"].ToString()).id,
                    hasDetailAccount = "f",
                    hasDimension1 = "f",
                    hasDimension2 = "f",
                    hasDimension3 = "f",
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN",
                    //balanceType = "f",

                });
            }
        }

        public void CreateDetailAccounts()
        {
            var data = fileRepository.GetData("SELECT * FROM AccDL");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.DetailAccountList.Add(new DetailAccount()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    code = item["dl_Code"].ToString(),
                    title = item["dl_Title"].ToString(),
                    detailAccountType = "other",
                    isDetailAccount = "f",
                    isDimension1 = "f",
                    isDimension2 = "f",
                    isDimension3 = "f",
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN"
                });
            }
        }

        public void CreateFiscalPeriod()
        {
            var data = fileRepository.GetData("SELECT * FROM AccPeriod");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.FiscalPeriodList.Add(new FiscalPeriod()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    title = item["PeriodTitle"].ToString(),
                    minDate = item["p_FromDate"].ToString(),
                    maxDate = item["p_ToDate"].ToString(),
                    oldId = item["PeriodId"].ToString(),
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN"
                });
            }
        }

        public void CreateJournal()
        {
            var journalData = fileRepository.GetData("SELECT * FROM AccVchHdr");
            var journalItemData = fileRepository.GetData("SELECT * FROM AccVchItm");

            foreach (DataRow e in journalData.Rows)
            {
                var journal = new Journal();
                journal.branchId = branchId;
                journal.id = Guid.NewGuid();
                journal.number = e["AVHTempNum"].ToString();
                journal.temporaryNumber = e["AVHNum"].ToString();
                journal.date = e["AVHDate"].ToString();
                journal.temporaryDate = e["AVHDate"].ToString();
                journal.createdAt = Helper.ConvertToMiladi(e["AVHDate"].ToString());
                journal.updatedAt = Helper.ConvertToMiladi(e["AVHDate"].ToString());
                journal.createdById = "ADMIN";
                journal.fiscalPeriodId = fileRepository.destinationData.FiscalPeriodList.FindLast(a => a.oldId == e["AccPrdRef"].ToString()).id;
                journal.description = e["AVHDescr"].ToString();
                journal.journalStatus = "Temporary";
                journal.issuer = "Accounting";
                journal.includeSeasonDeals = "f";
                journal.isInComplete = "f";
                journal.isMergedJournal = "f";
                var sumCreditor = 0.0;
                var sumDebtor = 0.0;


                foreach (DataRow i in journalItemData.Rows)
                {
                    if (e["AccVchHdrId"].ToString() == i["AccVchHdrRef"].ToString())
                    {
                        var journalItem = new JournalItem();
                        journalItem.id = Guid.NewGuid();
                        journalItem.branchId = branchId;
                        journalItem.journalId = journal.id.ToString();

                        var subsidiaryLedgerAccount = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(a => a.code == i["AVISLRef"].ToString());
                        DetailAccount detailAccount = null, dimension1 = null, dimension2 = null, dimension3 = null;

                        if (!string.IsNullOrEmpty(i["AVIDLRef"].ToString()))
                        {
                            detailAccount = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == i["AVIDLRef"].ToString());

                            if (detailAccount == null)
                            {
                                throw new Exception();
                            }

                            detailAccount.isDetailAccount = "t";
                            subsidiaryLedgerAccount.hasDetailAccount = "t";
                        }

                        if (!string.IsNullOrEmpty(i["AVIDL5Ref"].ToString()))
                        {
                            dimension1 = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == i["AVIDL5Ref"].ToString());

                            if (dimension1 == null)
                            {
                                throw new Exception();
                            }

                            dimension1.isDimension1 = "t";
                            subsidiaryLedgerAccount.hasDimension1 = "t";
                        }

                        if (!string.IsNullOrEmpty(i["AVIDL6Ref"].ToString()))
                        {
                            dimension2 = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == i["AVIDL6Ref"].ToString());

                            if (dimension2 == null)
                            {
                                throw new Exception();
                            }

                            dimension2.isDimension2 = "t";
                            subsidiaryLedgerAccount.hasDimension2 = "t";
                        }

                        if (!string.IsNullOrEmpty(i["AVIDL7Ref"].ToString()))
                        {
                            dimension3 = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == i["AVIDL7Ref"].ToString());


                            if (dimension3 == null)
                            {
                                throw new Exception();
                            }

                            dimension3.isDimension3 = "t";
                            subsidiaryLedgerAccount.hasDimension3 = "t";
                        }

                        journalItem.row = int.Parse(i["AVISeq"].ToString());
                        journalItem.generalLedgerAccountId = subsidiaryLedgerAccount.generalLedgerAccountId;
                        journalItem.subsidiaryLedgerAccountId = subsidiaryLedgerAccount.id;
                        journalItem.detailAccountId = detailAccount != null ? detailAccount.id.ToString() : null;
                        journalItem.dimension1Id = dimension1 != null ? dimension1.id.ToString() : null;
                        journalItem.dimension2Id = dimension2 != null ? dimension2.id.ToString() : null;
                        journalItem.article = i["AVIDescr"].ToString();
                        journalItem.debtor = double.Parse(i["AVIDebit"].ToString());
                        journalItem.creditor = double.Parse(i["AVICredit"].ToString());
                        journalItem.createdAt = Helper.ConvertToMiladi(e["AVHDate"].ToString());
                        journalItem.updatedAt = Helper.ConvertToMiladi(e["AVHDate"].ToString());
                        journalItem.createdById = "ADMIN";

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

    }
}
