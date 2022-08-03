using ConvertDatabase.WinApp.Helpers;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace ConvertDatabase.WinApp.ConvertClass
{
    // Converting Flow :
    //
    // 1. Import Source File/DB
    // 2. Import Target File/DB
    // 3. Map Table
    // 4. Map Column
    // 5.1  Map Data
    // 5.2  Execute Method on Colummn
    // 6. Convert
    // 7. Export Target File/DB
    //
    public class ConvertSepidar : ISepidar
    {
        public ConvertSepidar(ConvertDto convertDto)
        {
            ConvertDto.SourceData.MappingColumns = convertDto.SourceData.MappingColumns;
            ConvertDto.SourceData = convertDto.SourceData;
            ConvertDto.TargetData = convertDto.TargetData;
            ConvertDto = convertDto;
            //ImportRepository = GetImportRepository(convertDto);
            //OutputRepository = GetOutputRepository(convertDto);
        }

        private IRepository<T> GetInputRepository<T>(ConvertDto convertDto)
        {
            if (convertDto.InputTypeEnum == InputTypeEnum.Excel)
            {
                return new FileRepository<T>();
            }

            return new FileRepository<T>();
        }

        private IRepository<T> GetOutputRepository<T>(ConvertDto convertDto)
        {
            if (convertDto.OutputTypeEnum == OutputTypeEnum.Excel)
            {
                return new FileRepository<T>();
            }

            return new FileRepository<T>();
        }

        public ConvertDto ConvertDto { get; }
        //public IRepository<T> ImportRepository { get; }
        //public IRepository<T> OutputRepository { get; }
        //public List<MapColumn> MappingColumns { get; }
        //public JournalDataClass SourceData { get; }
        //public JournalDataClass TargetData { get; }


        //public DataTable GetDataTable(JournalDataClass data)
        //{
        //    return new DataTable();
        //}

        private List<JournalItem> MappData(List<JournalItem> data)
        {
            var localData = data;
            foreach (var item in localData)
            {
                var subsidaryCode = GetSubsidiaryCode();
                var subsidary = GetSubsidiaryLedgerAccount(subsidaryCode);
                item.subsidiaryLedgerAccountId = subsidary.id;
                item.generalLedgerAccountId = subsidary.generalLedgerAccountId;
                item.detailAccountId = GetDetailAccount("").id.ToString();
            }
            return localData;
        }

        private string GetSubsidiaryCode()
        {
            throw new NotImplementedException();
        }

        private SubsidiaryLedgerAccount GetSubsidiaryLedgerAccount(string code)
        {
            var equivalent = ConvertDto.TargetData.EquivalentSubsidiaryList.FindLast(i => i.OldCode == code);
            if (equivalent != null)
            {
                var account = ConvertDto.TargetData.SubsidiaryLedgerAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account;
                }
                // TODO : Create Account

            }
            return ConvertDto.TargetData.SubsidiaryLedgerAccountList.FindLast(a => a.AccountId == code);
        }

        private DetailAccount GetDetailAccount(string code)
        {
            var equivalent = ConvertDto.TargetData.EquivalentDetailList.FindLast(i => i.OldCode == code);
            if (equivalent != null)
            {
                var account = ConvertDto.TargetData.DetailAccountList.FindLast(i => int.Parse(i.code) == int.Parse(equivalent.NewCode));
                if (account != null)
                {
                    return account;
                }
                // TODO : Create Account

            }
            return ConvertDto.TargetData.DetailAccountList.FindLast(a => a.AccountId == code);
        }

        public void CreateAccountCategory()
        {
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<AccountCategories>(targetTable);
            outputRepository.Export(dataList);
        }

        public void CreateDetailAccounts()
        {
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<AccountCategories>(targetTable);
            outputRepository.Export(dataList);
        }

        public void CreateFiscalPeriod()
        {
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<AccountCategories>(targetTable);
            outputRepository.Export(dataList);
        }

        public void CreateGeneralLedgerAccount()
        {
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<AccountCategories>(targetTable);
            outputRepository.Export(dataList);
        }

        public void CreateJournal()
        {
            var inputRepository = GetInputRepository<JournalItem>(ConvertDto);
            var outputRepository = GetOutputRepository<JournalItem>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<JournalItem>(targetTable);
            var ConvertedData = MappData(dataList);
            outputRepository.Export(ConvertedData);
        }

        public void CreateSubsidiaryLedgerAccount()
        {
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetData();
            var targetData = outputRepository.GetData();
            var targetTable = Helper.MappColumn(sourceData, targetData, ConvertDto.SourceData.MappingColumns);
            var dataList = Helper.GetList<AccountCategories>(targetTable);
            outputRepository.Export(dataList);
        }

        public void Execute()
        {
            CreateAccountCategory();
            CreateGeneralLedgerAccount();
            CreateSubsidiaryLedgerAccount();
            CreateDetailAccounts();
            CreateFiscalPeriod();
            CreateJournal();
        }

        
    }
}
