using ConvertDatabase.WinApp.Models;
using ConvertDatabase.WinApp.Repositories;
using System.Collections.Generic;

namespace ConvertDatabase.WinApp.Engine
{
    public interface IConvertEngine
    {
        void Start();
        void SetConvertTypeEnum(ConvertTypeEnum convertTypeEnum);
        void SetSoftwareTypeEnum(SoftwareTypeEnum softwareTypeEnum);
        void SetImportRepository(InputTypeEnum inputTypeEnum);
        void SetImportSourcePath(JournalFilesPath filesPath);
        void SetImportTargetPath(JournalFilesPath filesPath);
        void SetMappingColumns(List<MapColumn> mappColumns);
        void SetOutputRepository(OutputTypeEnum outputTypeEnum);
        void SetMappingFilesPath(MappingFilesPath filesPath);
        bool HasDatabaseSource();
        bool HasDatabaseTarget();
        ConvertDto GetConvertDto(); 
    }
}
