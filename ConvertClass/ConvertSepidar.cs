﻿using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ConvertSepidar(IRepository importRepository, IRepository outputRepository, JournalDataClass sourceData, JournalDataClass targetData)
        {
            ImportRepository = importRepository;
            OutputRepository = outputRepository;
            MappingColumns = sourceData.MappingColumns;
            SourceData = sourceData;
            TargetData = targetData;
        }

        public ConvertSepidar(ConvertDto convertDto)
        {
            MappingColumns = convertDto.SourceData.MappingColumns;
            SourceData = convertDto.SourceData;
            TargetData = convertDto.TargetData;
            ConvertDto = convertDto;
            ImportRepository = GetImportRepository(convertDto);
            OutputRepository = GetOutputRepository(convertDto);
            
        }

        private IRepository GetOutputRepository(ConvertDto convertDto)
        {
            if (convertDto.InputTypeEnum == InputTypeEnum.Excel)
            {
                return new FileRepository();
            }

            return new FileRepository();
        }

        private IRepository GetImportRepository(ConvertDto convertDto)
        {
            if (convertDto.OutputTypeEnum == OutputTypeEnum.Excel)
            {
                return new FileRepository();
            }

            return new FileRepository();
        }

        public ConvertDto ConvertDto { get; }
        public IRepository ImportRepository { get; }
        public IRepository OutputRepository { get; }
        public List<MapColumn> MappingColumns { get; }
        public JournalDataClass SourceData { get; }
        public JournalDataClass TargetData { get; }


        public DataTable GetDataTable(JournalDataClass data)
        {
            return new DataTable();
        }

        public DataTable MappColumn(DataTable source, DataTable target, List<MapColumn> maps)
        {
            var counter = 0;

            foreach (DataRow item in source.Rows)
            {
                foreach (MapColumn map in maps)
                {
                    target.Rows[counter][map.TargetValue] = item[map.SourceValue];
                }
                counter++;
            }

            return target;
        }

        private static List<T> GetList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        private List<T> MappData<T>(List<T> data)
        {
            throw new NotImplementedException();
        }

        public void CreateAccountCategory()
        {
            var sourceData = ImportRepository.GetAll();
            var targetTable = MappColumn(GetDataTable(SourceData), GetDataTable(TargetData), MappingColumns);
            var data = GetList<AccountCategories>(targetTable);
            var ConvertedData = MappData(data);
            OutputRepository.Export();
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

        public void CreateJournal()
        {
            throw new NotImplementedException();
        }

        public void CreateSubsidiaryLedgerAccount()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            
        }

        
    }
}