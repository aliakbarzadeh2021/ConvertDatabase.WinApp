using ConvertDatabase.WinApp.ConvertClass;
using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertDatabase.WinApp.Engine
{

    public class ConvertEngine : IConvertEngine
    {
        public ConvertDto ConvertDto = new ConvertDto();
        public IDataAnalysis DataAnalysis { get; set; }


        //private bool isDatabaseSource { get; set; }
        //private bool isDatabaseTarget { get; set; }
        //public ConvertTypeEnum ConvertType { get; set; }
        //public SoftwareTypeEnum SoftwareType { get; set; }
        //public IRepository ImportRepository { get; set; }
        //public IRepository OutputRepository { get; set; }       

        //public JournalDataClass SourceData = new JournalDataClass();
        //public JournalDataClass TargetData = new JournalDataClass();

        public bool HasDatabaseSource()
        {
            return ConvertDto.isDatabaseSource;
        }

        public bool HasDatabaseTarget()
        {
            return ConvertDto.isDatabaseTarget;
        }

        public void SetConvertTypeEnum(ConvertTypeEnum convertTypeEnum)
        {
            ConvertDto.ConvertType = convertTypeEnum;
        }

        public void SetImportRepository(InputTypeEnum inputTypeEnum )
        {
            ConvertDto.isDatabaseSource = true;
            ConvertDto.InputTypeEnum = inputTypeEnum;
        }

        public void SetMappingColumns(List<MapColumn> mappColumns)
        {
            ConvertDto.SourceData.MappingColumns = mappColumns;
        }

        public void SetOutputRepository(OutputTypeEnum outputTypeEnum)
        {
            ConvertDto.isDatabaseTarget = true;
            ConvertDto.OutputTypeEnum = outputTypeEnum;
        }

        public void SetSoftwareTypeEnum(SoftwareTypeEnum softwareTypeEnum)
        {
            ConvertDto.SoftwareType = softwareTypeEnum;
        }

        public void Start()
        {
            IDataAnalysis dataAnalysis = new DataAnalysis();
            var result = dataAnalysis.Run();

            if (result.IsSuccess)
            {
                IConvert convertor = GetConvertor();
                convertor.Execute();
            }                
        }

        private IConvert GetConvertor()
        {
            if (ConvertDto.ConvertType == ConvertTypeEnum.Journals)
            {
                if (ConvertDto.SoftwareType == SoftwareTypeEnum.Sepidar)
                {
                    return new ConvertSepidar(ConvertDto);
                }
                else if (ConvertDto.SoftwareType == SoftwareTypeEnum.Afra)
                {
                    return new ConvertJournal();
                }
                else if (ConvertDto.SoftwareType == SoftwareTypeEnum.Shahd)
                {
                    return new ConvertJournal();
                }
                else if (ConvertDto.SoftwareType == SoftwareTypeEnum.Others)
                {
                    return new ConvertJournal();
                }
            }
            else if (ConvertDto.ConvertType == ConvertTypeEnum.Promissory)
            {

            }
            else if (ConvertDto.ConvertType == ConvertTypeEnum.Treasury)
            {

            }          



            return new ConvertJournal();
        }

        public void SetImportSourcePath(JournalFilesPath filesPath)
        {
            ConvertDto.isDatabaseSource = false;
            ConvertDto.SourceData.JournalFilesPath = filesPath;
        }

        public void SetImportTargetPath(JournalFilesPath filesPath)
        {
            ConvertDto.isDatabaseTarget = false;
            ConvertDto.TargetData.JournalFilesPath = filesPath;
        }

        public void SetMappingFilesPath(MappingFilesPath filesPath)
        {
            ConvertDto.SourceData.MappingFilesPath = filesPath;
        }

        public ConvertDto GetConvertDto()
        {
            return ConvertDto;
        }
    }
}
