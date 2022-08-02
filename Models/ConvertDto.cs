using System;
using System.Text;

namespace ConvertDatabase.WinApp.Models
{
    public class ConvertDto
    {
        public bool isDatabaseSource { get; set; }
        public bool isDatabaseTarget { get; set; }
        public ConvertTypeEnum ConvertType { get; set; }
        public SoftwareTypeEnum SoftwareType { get; set; }
        public InputTypeEnum InputTypeEnum { get; set; }
        public OutputTypeEnum OutputTypeEnum { get; set; }

        public JournalDataClass SourceData = new JournalDataClass();
        public JournalDataClass TargetData = new JournalDataClass();
    }

    public enum ConvertTypeEnum
    {
        Journals,
        Treasury,
        Promissory
    }

    public enum SoftwareTypeEnum
    {
        Sepidar,
        Afra,
        Shahd,
        Others
    }

    public enum InputTypeEnum
    {
        Excel,
        Json,
        Access,
        SQLServer
    }

    public enum OutputTypeEnum
    {
        Excel,
        Json,
        Access,
        SQLServer,
        Postgresql
    }

    public class MapColumn
    {
        public string SourceValue { get; set; }
        public string TargetValue { get; set; }
        public string Method { get; set; }
    }
}
