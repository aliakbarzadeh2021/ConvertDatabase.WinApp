using ConvertDatabase.WinApp.Models;
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
            ConvertDto.SourceData.MappingColumns = sourceData.MappingColumns;
            ConvertDto.SourceData = sourceData;
            ConvertDto.TargetData = targetData;
            ImportRepository = importRepository;
            OutputRepository = outputRepository;
        }

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


        public DataTable GetDataTable(JournalDataClass data)
        {
            return new DataTable();
        }

        public DataTable MappColumn()
        {
            var source = GetDataTable(ConvertDto.SourceData);
            var target = GetDataTable(ConvertDto.TargetData);
            var maps = ConvertDto.SourceData.MappingColumns;
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
            var inputRepository = GetInputRepository<AccountCategories>(ConvertDto);
            var outputRepository = GetOutputRepository<AccountCategories>(ConvertDto);
            var sourceData = inputRepository.GetAll();
            var targetTable = MappColumn();
            var data = GetList<AccountCategories>(targetTable);
            var ConvertedData = MappData(data);
            outputRepository.Export();
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
