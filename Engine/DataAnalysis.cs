using ConvertDatabase.WinApp.Helpers;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ConvertDatabase.WinApp.Engine
{
    public interface IDataAnalysis
    {
        DataAnalysisResult Run();
    }

    public class DataAnalysisResult
    {
        public bool IsSuccess { get; set; }
    }

    public class DataAnalysis : IDataAnalysis
    {
        FileRepository<SubsidiaryLedgerAccount> fileRepository = new FileRepository<SubsidiaryLedgerAccount>();
        public DataAnalysisResult Run()
        {
            return new DataAnalysisResult() 
            {
                IsSuccess = true
            };
        }

        public List<string> SubsidaryNotExist()
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

        public List<string> DetailNotExist()
        {
            var list = new List<string>();
            foreach (var item in fileRepository.destinationData.EquivalentDetailList)
            {
                if (!fileRepository.destinationData.DetailAccountList.Exists(i => i.code == item.NewCode))
                {
                    list.Add(item.NewCode);
                }
            }
            return list;
        }

        public List<string> DetailFarvardinNotExist()
        {
            var list = new List<string>();
            var journalDB = fileRepository.GetOLEDB(@"\Files\dbFarvardin\SANAD_M.mdb").Result;
            var journalItemDB = fileRepository.GetOLEDB(@"\Files\dbFarvardin\SANAD_D.mdb").Result;

            foreach (DataRow row in journalDB.Tables["SANAD_M"].Rows)
            {
                foreach (DataRow itemRow in journalItemDB.Tables["SANAD_D"].Rows)
                {

                    if (itemRow["SHOM"].ToString() == row["CODE"].ToString())
                    {
                        DetailAccount detailAccount = null;

                        if (!string.IsNullOrEmpty(itemRow["BCOD"].ToString()))
                        {
                            detailAccount = fileRepository.destinationData.DetailAccountList.FindLast(a => a.code == itemRow["BCOD"].ToString());

                            if (detailAccount == null)
                            {
                                list.Add(itemRow["BCOD"].ToString());
                            }
                        }
                    }
                }
            }
            var result = list.Distinct().ToList();
            return result;

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
            //Helper.WriteFile(FilePath ,"EquivalentSubsidiaryListNotExist.json", Helper.ToJson(list));
        }
    }
}
