namespace ConvertDatabase.WinApp.ConvertClass
{
    public interface IConvert
    {
        void Execute();
    }

    public interface IJournalConvert : IConvert
    {
        void CreateAccountCategory();
        void CreateGeneralLedgerAccount();
        void CreateSubsidiaryLedgerAccount();
        void CreateDetailAccounts();
        void CreateFiscalPeriod();
        void CreateJournal();
    }


    public interface ISepidar : IJournalConvert
    {

    }

    public interface IAfra : IJournalConvert
    {

    }

    public interface IShahd : IJournalConvert
    {

    }

    public interface ITreasuryConvert : IConvert
    {

    }

    public interface IPromissoryConvert : IConvert
    {

    }
}
