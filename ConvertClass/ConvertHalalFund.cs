using ConvertDatabase.WinApp.Helpers;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
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
    public class ConvertHalalFund : ISepidar
    {
        string FilePath = @"\Files\HalalFund\";
        string branchId = "spncY6QGW2vA7MHJpuQGWa";
        FileRepository fileRepository = new FileRepository();
        public void Execute()
        {
            fileRepository.GetFilePath(FilePath);
            fileRepository.ImportSourceData();

            //CheckEquivalentForImportedData();

            CheckExceptions();



            //CreateAccountCategory();
            //CreateGeneralLedgerAccount();
            //CreateSubsidiaryLedgerAccount();
            //CreateDetailAccounts();
            //CreateFiscalPeriod();
            CreateJournal();


            fileRepository.ExportData();
        }

        private void CheckExceptions()
        {
            var exceptions = NewSubsidaryNotExist();
            List<EquivalentSubsidiary> EquivalentExceptions = new List<EquivalentSubsidiary>();
            List<DataRow> rows = new List<DataRow>();
            List<string> codeHesabExceptions = new List<string>();

            var journalItemData = fileRepository.GetData("SELECT * FROM ACC.VoucherItem");
            foreach (DataRow item in journalItemData.Rows)
            {
                var code = item["AccountSLRef"].ToString();
                var codeHesab = GetCodeHesab(code);
                if (string.IsNullOrEmpty(codeHesab)) { throw new Exception(); }
                var equivalent = fileRepository.destinationData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == codeHesab);
                if (equivalent != null)
                {
                    var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                    if (account != null)
                    {
                        continue;
                    }
                    // TODO : Create Account
                    if (!EquivalentExceptions.Exists(i => i.OldCode == equivalent.OldCode && i.NewCode == equivalent.NewCode))
                    {
                        EquivalentExceptions.Add(equivalent);
                    }

                    continue;
                }
                var exist = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(codeHesab));
                if (exist == null)
                {
                    if (!codeHesabExceptions.Exists(i => i == codeHesab))
                    {
                        codeHesabExceptions.Add(codeHesab);
                    }

                }

            }
            fileRepository.ExportExcel(fileRepository.ToJson(codeHesabExceptions));
        }

        public List<string> NewSubsidaryNotExist()
        {
            var list = new List<string>();
            foreach (var item in fileRepository.destinationData.EquivalentSubsidiaryList)
            {
                if (!fileRepository.destinationData.SubsidiaryLedgerAccountList.Exists(i => i.code == item.NewCode))
                {
                    list.Add(item.NewCode);
                }
            }
            return list;
        }

        private void CheckEquivalentForImportedData()
        {
            int countOld = 0;
            int countNew = 0;
            int countNull = 0;
            var list = new List<EquivalentSubsidiary>();
            foreach (var item in fileRepository.destinationData.JournalItemList)
            {
                var subsidary = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(a => a.id == item.subsidiaryLedgerAccountId);
                if (subsidary == null)
                {
                    countNull++;
                }
                var equivalent = fileRepository.destinationData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == subsidary.code);
                if (equivalent != null)
                {
                    countOld++;
                    var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                    if (account != null)
                    {
                        countNew++;
                    }
                    else
                    {
                        list.Add(equivalent);
                    }

                    // TODO : Create Account

                }
            }
            fileRepository.ExportExcel(fileRepository.ToJson(list));
            fileRepository.WriteFile(FilePath, "EquivalentSubsidiaryListNotExist.json", fileRepository.ToJson(list));
        }

        public void CreateAccountCategory()
        {
            var data = fileRepository.GetData("SELECT * FROM ACC.Account where ParentAccountRef = -5");

            foreach (DataRow item in data.Rows)
            {
                var r = new AccountCategories()
                {
                    AccountId = item["AccountId"].ToString(),
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    key = item["Code"].ToString(),
                    display = item["Title"].ToString(),
                    createdAt = DateTime.Now.ToString(),
                    updatedAt = DateTime.Now.ToString(),
                    createdById = "ADMIN",
                    //type
                };
                fileRepository.destinationData.AccountCategoriesList.Add(r);
            }
        }

        public void CreateGeneralLedgerAccount()
        {
            foreach (var category in fileRepository.destinationData.AccountCategoriesList)
            {
                var data = fileRepository.GetData($"SELECT * FROM ACC.Account where ParentAccountRef = {category.AccountId}");

                foreach (DataRow item in data.Rows)
                {
                    fileRepository.destinationData.GeneralLedgerAccountList.Add(new GeneralLedgerAccount()
                    {
                        AccountId = item["AccountId"].ToString(),
                        branchId = branchId,
                        id = Guid.NewGuid(),
                        code = category.key + item["Code"].ToString(),
                        title = item["Title"].ToString(),
                        categoryId = category.id,
                        createdAt = item["CreationDate"].ToString(),
                        updatedAt = item["LastModificationDate"].ToString(),
                        createdById = "ADMIN",
                        //postingType
                    });
                }
            }
        }

        public void CreateSubsidiaryLedgerAccount()
        {
            foreach (var category in fileRepository.destinationData.GeneralLedgerAccountList)
            {
                var data = fileRepository.GetData($"SELECT * FROM ACC.Account where ParentAccountRef = {category.AccountId}");

                foreach (DataRow item in data.Rows)
                {
                    fileRepository.destinationData.SubsidiaryLedgerAccountList.Add(new SubsidiaryLedgerAccount()
                    {
                        AccountId = item["AccountId"].ToString(),
                        branchId = branchId,
                        id = Guid.NewGuid(),
                        code = category.code + item["Code"].ToString(),
                        title = item["Title"].ToString(),
                        generalLedgerAccountId = category.id,
                        hasDetailAccount = "f",
                        hasDimension1 = "f",
                        hasDimension2 = "f",
                        hasDimension3 = "f",
                        createdAt = item["CreationDate"].ToString(),
                        updatedAt = item["LastModificationDate"].ToString(),
                        createdById = "ADMIN",
                        //balanceType = "f",
                    });
                }
            }
        }

        public void CreateDetailAccounts()
        {
            var data = fileRepository.GetData("SELECT * FROM ACC.DL");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.DetailAccountList.Add(new DetailAccount()
                {
                    AccountId = item["DLId"].ToString(),
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    code = item["Code"].ToString(),
                    title = item["Title"].ToString(),
                    detailAccountType = "other",
                    isDetailAccount = "f",
                    isDimension1 = "f",
                    isDimension2 = "f",
                    isDimension3 = "f",
                    createdAt = item["CreationDate"].ToString(),
                    updatedAt = item["LastModificationDate"].ToString(),
                    createdById = "ADMIN",
                });
            }
        }

        public void CreateFiscalPeriod()
        {
            var data = fileRepository.GetData("SELECT * FROM FMK.FiscalYear");

            foreach (DataRow item in data.Rows)
            {
                fileRepository.destinationData.FiscalPeriodList.Add(new FiscalPeriod()
                {
                    branchId = branchId,
                    id = Guid.NewGuid(),
                    title = item["Title"].ToString(),
                    minDate = Helper.ConvertToShamsi(item["StartDate"].ToString()),
                    maxDate = Helper.ConvertToShamsi(item["EndDate"].ToString()),
                    oldId = item["FiscalYearId"].ToString(),
                    createdAt = item["CreationDate"].ToString(),
                    updatedAt = item["LastModificationDate"].ToString(),
                    createdById = "ADMIN",
                });
            }
        }



        public void CreateJournal()
        {
            var journalData = fileRepository.GetData("SELECT * FROM ACC.Voucher");
            var journalItemData = fileRepository.GetData("SELECT * FROM ACC.VoucherItem");

            foreach (DataRow e in journalData.Rows)
            {
                var journal = new Journal();
                journal.branchId = branchId;
                journal.id = Guid.NewGuid();
                journal.number = e["ReferenceNumber"].ToString();
                journal.temporaryNumber = e["Number"].ToString();
                journal.date = Helper.ConvertToShamsi(e["Date"].ToString());
                journal.temporaryDate = Helper.ConvertToShamsi(e["Date"].ToString());
                journal.createdAt = e["CreationDate"].ToString();
                journal.updatedAt = e["LastModificationDate"].ToString();
                journal.createdById = "ADMIN";
                // journal.fiscalPeriodId = fileRepository.FiscalPeriodList.FindLast(a => a.oldId == e["FiscalYearRef"].ToString()).id;
                journal.description = e["Description"].ToString();
                journal.journalStatus = "Temporary";
                journal.issuer = "Accounting";
                journal.includeSeasonDeals = "f";
                journal.isInComplete = "f";
                journal.isMergedJournal = "f";
                var sumCreditor = 0.0;
                var sumDebtor = 0.0;


                foreach (DataRow i in journalItemData.Rows)
                {
                    if (i["VoucherRef"].ToString() == e["VoucherId"].ToString())
                    {
                        var journalItem = new JournalItem();
                        journalItem.id = Guid.NewGuid();
                        journalItem.branchId = branchId;
                        journalItem.journalId = journal.id.ToString();
                        SubsidiaryLedgerAccount subsidiaryLedgerAccount = GetSubsidiaryLedgerAccount(i);
                        DetailAccount detailAccount = null, dimension1 = null, dimension2 = null, dimension3 = null;

                        if (!string.IsNullOrEmpty(i["DLRef"].ToString()))
                        {
                            detailAccount = fileRepository.destinationData.DetailAccountList.FindLast(a => a.AccountId == i["DLRef"].ToString());

                            if (detailAccount == null)
                            {
                                throw new Exception();
                            }

                            detailAccount.isDetailAccount = "t";
                            subsidiaryLedgerAccount.hasDetailAccount = "t";
                        }

                        journalItem.row = int.Parse(i["RowNumber"].ToString());
                        journalItem.generalLedgerAccountId = subsidiaryLedgerAccount.generalLedgerAccountId;
                        journalItem.subsidiaryLedgerAccountId = subsidiaryLedgerAccount.id;
                        journalItem.detailAccountId = detailAccount != null ? detailAccount.id.ToString() : null;
                        //journalItem.dimension1Id = dimension1 != null ? dimension1.id.ToString() : null;
                        //journalItem.dimension2Id = dimension2 != null ? dimension2.id.ToString() : null;
                        journalItem.article = i["Description"].ToString();
                        journalItem.debtor = double.Parse(i["Debit"].ToString());
                        journalItem.creditor = double.Parse(i["Credit"].ToString());
                        journalItem.createdAt = e["CreationDate"].ToString();
                        journalItem.updatedAt = e["LastModificationDate"].ToString();
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

        private SubsidiaryLedgerAccount GetSubsidiaryLedgerAccount(DataRow voucherItemRow)
        {
            var code = voucherItemRow["AccountSLRef"].ToString();
            var codeHesab = GetCodeHesab(code);
            var equivalent = fileRepository.destinationData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == codeHesab);
            if (equivalent != null)
            {
                var account = fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account;
                }
                // TODO : Create Account

            }
            return fileRepository.destinationData.SubsidiaryLedgerAccountList.FindLast(a => a.AccountId == code);
        }

        private string GetCodeHesab(string accoundId)
        {
            var query = $"WITH category AS ("
                       + "  select AccountId, CAST(Code AS VARCHAR(MAX)) AS Code  FROM [SepidarHalalFund].[ACC].[Account] where ParentAccountRef = -5"
                       + "   UNION ALL"
                       + "    select a.AccountId,CAST(category.Code + a.Code  AS VARCHAR(MAX)) AS Code "
                       + "    FROM [SepidarHalalFund].[ACC].[Account] a,category where a.ParentAccountRef = category.AccountId)"
                       + " SELECT* FROM category c where AccountId = " + accoundId;
            var result = fileRepository.GetData(query);

            foreach (DataRow item in result.Rows)
            {
                var code = item["Code"].ToString();
                return code;
            }

            return "";
        }



    }
}
