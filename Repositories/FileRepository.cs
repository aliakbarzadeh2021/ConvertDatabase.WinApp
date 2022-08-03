using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Linq;
using System.Data;
using System.IO;
//using NsExcel = Microsoft.Office.Interop.Excel;
using Aspose.Cells;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.OleDb;
using ConvertDatabase.WinApp.Models;
using ExcelDataReader;
using System.Data.SqlClient;

namespace ConvertDatabase.WinApp.Repositories
{
    public class FileRepository<T> : IRepository<T>
    {
        private string FilePath = "";
        public JournalDataClass sourceData ;
        public JournalDataClass destinationData ;

        public FileRepository(JournalDataClass sourceData1 , JournalDataClass destinationData1)
        {
            sourceData = sourceData1;
            destinationData = destinationData1;
        }

        public FileRepository()
        {
            sourceData = new JournalDataClass();
            destinationData = new JournalDataClass();
        }

        public DataTable GetData(string query)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable data = new DataTable())
                        {
                            sda.Fill(data);
                            return data;
                        }
                    }
                }
            }
        }


        public string GetFilePath(string path)
        {
            Directory.SetCurrentDirectory(@"..\..\..");
            var result = Directory.GetCurrentDirectory() + path;
            FilePath = result;
            return result;
        }
        public void ExportData()
        {
            WriteFile(FilePath, "1.AccountCategory.json", ToJson(destinationData.AccountCategoriesList));
            WriteFile(FilePath, "2.GeneralLedgerAccount.json",ToJson(destinationData.GeneralLedgerAccountList));
            WriteFile(FilePath, "3.SubsidiaryLedgerAccount.json", ToJson(destinationData.SubsidiaryLedgerAccountList));
            WriteFile(FilePath, "4.DetailAccounts.json", ToJson(destinationData.DetailAccountList));
            WriteFile(FilePath, "5.FiscalPeriod.json", ToJson(destinationData.FiscalPeriodList));
            WriteFile(FilePath, "6.Journal.json", ToJson(destinationData.JournalList));
            WriteFile(FilePath, "7.JournalItem.json", ToJson(destinationData.JournalItemList));
        }

        public string ToJson(object data)
        {
            var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return json1;
        }

        public void WriteFile(string path, string name, string json)
        {
            if (!Directory.Exists(path + "output"))
            {
                Directory.CreateDirectory(path + "output");
            }
            File.WriteAllText(path + @"output\" + name, json);
        }

        public void ImportSourceData()
        {
            //string accountCategory = FilePath + ConfigurationManager.AppSettings["AccountCategory"];
            string accountCategory = FilePath + @"importSource\accountCategories.json";
            string generalLedgerAccount = FilePath + @"importSource\GeneralLedgerAccounts.json";
            string subsidiaryLedgerAccount = FilePath + @"importSource\SubsidiaryLedgerAccounts.json";
            string detailAccounts = FilePath + @"importSource\DetailAccounts.json";
            string fiscalPeriod = FilePath + @"importSource\FiscalPeriods.json";
            string journal = FilePath + @"importSource\Journals.json";
            string journalItem = FilePath + @"importSource\JournalLines.json";
            string subsidaryEquivalent = FilePath + @"importSource\_SubsidaryEquivalent.xlsx";
            string detailEquivalent = FilePath + @"importSource\_DetailEquivalent.xlsx";
            string generalEquivalent = FilePath + @"importSource\_GeneralEquivalent.xlsx";

            //LoadAccountCategories(accountCategory);
            //LoadGeneralLedgerAccount(generalLedgerAccount);
            //LoadSubsidiaryLedgerAccount(subsidiaryLedgerAccount);
            //LoadDetailAccount(detailAccounts);
            //LoadFiscalPeriod(fiscalPeriod);
            //LoadJournal(journal);
            //LoadJournalItem(journalItem);
            sourceData.AccountCategoriesList.AddRange(LoadAccount<AccountCategories>(accountCategory));
            sourceData.GeneralLedgerAccountList.AddRange(LoadAccount<GeneralLedgerAccount>(generalLedgerAccount));
            sourceData.SubsidiaryLedgerAccountList.AddRange(LoadAccount<SubsidiaryLedgerAccount>(subsidiaryLedgerAccount));
            sourceData.DetailAccountList.AddRange(LoadAccount<DetailAccount>(detailAccounts));
            sourceData.FiscalPeriodList.AddRange(LoadAccount<FiscalPeriod>(fiscalPeriod));
            //sourceData.JournalList.AddRange(LoadAccount<Journal>(journal));
            //sourceData.JournalItemList.AddRange(LoadAccount<JournalItem>(journalItem));
            sourceData.EquivalentGeneralList.AddRange(LoadEquivalent(generalEquivalent));
            sourceData.EquivalentSubsidiaryList.AddRange(LoadEquivalent(subsidaryEquivalent));
            sourceData.EquivalentDetailList.AddRange(LoadEquivalent(detailEquivalent));

        }

        public void ImportDestinationData()
        {
            //string accountCategory = FilePath + ConfigurationManager.AppSettings["AccountCategory"];
            string accountCategory = FilePath + @"importDestination\accountCategories.json";
            string generalLedgerAccount = FilePath + @"importDestination\GeneralLedgerAccounts.json";
            string subsidiaryLedgerAccount = FilePath + @"importDestination\SubsidiaryLedgerAccounts.json";
            string detailAccounts = FilePath + @"importDestination\DetailAccounts.json";
            string fiscalPeriod = FilePath + @"importDestination\FiscalPeriods.json";
            string journal = FilePath + @"importDestination\Journals.json";
            string journalItem = FilePath + @"importDestination\JournalLines.json";
            string subsidaryEquivalent = FilePath + @"importDestination\_SubsidaryEquivalent.xlsx";
            string detailEquivalent = FilePath + @"importDestination\_DetailEquivalent.xlsx";
            string generalEquivalent = FilePath + @"importDestination\_GeneralEquivalent.xlsx";

            //LoadAccountCategories(accountCategory);
            //LoadGeneralLedgerAccount(generalLedgerAccount);
            //LoadSubsidiaryLedgerAccount(subsidiaryLedgerAccount);
            //LoadDetailAccount(detailAccounts);
            //LoadFiscalPeriod(fiscalPeriod);
            destinationData.AccountCategoriesList.AddRange(LoadAccount<AccountCategories>(accountCategory));
            destinationData.GeneralLedgerAccountList.AddRange(LoadAccount<GeneralLedgerAccount>(generalLedgerAccount));
            destinationData.SubsidiaryLedgerAccountList.AddRange(LoadAccount<SubsidiaryLedgerAccount>(subsidiaryLedgerAccount));
            destinationData.DetailAccountList.AddRange(LoadAccount<DetailAccount>(detailAccounts));
            destinationData.FiscalPeriodList.AddRange(LoadAccount<FiscalPeriod>(fiscalPeriod));
            //destinationData.JournalList.AddRange(LoadAccount<Journal>(journal));
            //destinationData.JournalItemList.AddRange(LoadAccount<JournalItem>(journalItem));
            destinationData.EquivalentGeneralList.AddRange(LoadEquivalent(generalEquivalent));
            destinationData.EquivalentSubsidiaryList.AddRange(LoadEquivalent(subsidaryEquivalent));
            destinationData.EquivalentDetailList.AddRange(LoadEquivalent(detailEquivalent));

        }

        public void ImportDestinationDataFromExcel()
        {
            destinationData.AccountCategoriesList.AddRange(new Ganss.Excel.ExcelMapper(FilePath + @"importExcel\accountCategory.xlsx").Fetch<AccountCategories>());
            destinationData.GeneralLedgerAccountList.AddRange(new Ganss.Excel.ExcelMapper(FilePath + @"importExcel\generalleaderAccount.xlsx").Fetch<GeneralLedgerAccount>());
            destinationData.SubsidiaryLedgerAccountList.AddRange(new Ganss.Excel.ExcelMapper(FilePath + @"importExcel\subsidaryAccount.xlsx").Fetch<SubsidiaryLedgerAccount>());
            destinationData.DetailAccountList.AddRange(new Ganss.Excel.ExcelMapper(FilePath + @"importExcel\detailAccount.xlsx").Fetch<DetailAccount>());

            string fiscalPeriod = FilePath + @"importDestination\FiscalPeriods.json";
            string subsidaryEquivalent = FilePath + @"importDestination\_SubsidaryEquivalent.xlsx";
            string detailEquivalent = FilePath + @"importDestination\_DetailEquivalent.xlsx";
            string generalEquivalent = FilePath + @"importDestination\_GeneralEquivalent.xlsx";
            destinationData.FiscalPeriodList.AddRange(LoadAccount<FiscalPeriod>(fiscalPeriod));
            destinationData.EquivalentGeneralList.AddRange(LoadEquivalent(generalEquivalent));
            destinationData.EquivalentSubsidiaryList.AddRange(LoadEquivalent(subsidaryEquivalent));
            destinationData.EquivalentDetailList.AddRange(LoadEquivalent(detailEquivalent));
        }

        private List<EquivalentSubsidiary> LoadEquivalent(string fileUrl)
        {
            var equivalentData = ReadExcelFile3("Sheet2", fileUrl);
            var result = new List<EquivalentSubsidiary>();
            foreach (DataRow item in equivalentData.Rows)
            {
                var e = new EquivalentSubsidiary
                {
                    OldCode = item[0].ToString(),
                    NewCode = item[1].ToString()
                };
                result.Add(e);
            }
            //EquivalentSubsidiaryList = EquivalentSubsidiaryList.Distinct().ToList();
            return result;
        }

        public DataTable ReadExcelFile3(string sheetName, string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                    return result.Tables[sheetName];
                }
            }
        }

        public List<T> LoadAccount<T>(string fileUrl)
        {
            var data = JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText(fileUrl));
            return data.ToList();
        }

        public void ExportExcel(string jsonInput)
        {
            // create a Workbook object
            var workbook = new Workbook();
            var worksheet = workbook.Worksheets[0];

            // read JSON data from file
            //string jsonInput = File.ReadAllText("Data.json");

            // set JsonLayoutOptions to treat Arrays as Table
            var options = new Aspose.Cells.Utility.JsonLayoutOptions();
            options.ArrayAsTable = true;

            // import JSON data to worksheet starting at cell A1
            Aspose.Cells.Utility.JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

            // save resultant file in XLS format
            workbook.Save("output.xls", SaveFormat.Auto);
        }

        private async Task OLEDB(string dbName)
        {
            var sourceFile = Path.Combine(Environment.CurrentDirectory, "panahi1399.mdb");
            var connectionStringWithPassword = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";Jet OLEDB:Database Password=8k#w%sXzKlAq!209_+4#;";
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";";
            using (var db = new OleDbConnection(connectionString))
            {
                await db.OpenAsync();

                var schemaTable = db.GetSchema("Tables");
                var dataSet = new DataSet();

                Console.WriteLine();
                Console.WriteLine("Tables:");
                Console.WriteLine();

                var timer = new Stopwatch();
                timer.Start();
                for (var i = 0; i < schemaTable.Rows.Count; i++)
                {
                    //only source tables
                    if (schemaTable.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
                    {
                        var tableName = schemaTable.Rows[i]["TABLE_NAME"].ToString();
                        var sql = "SELECT * FROM [" + tableName + "]";
                        var dataTable = new DataTable(tableName);

                        using (var command = new OleDbCommand(sql, db))
                        {
                            using (var adapter = new OleDbDataAdapter(command))
                            {
                                adapter.Fill(dataTable);
                            }
                        }

                        Console.WriteLine(tableName + "(" + dataTable.Rows.Count + " rows)");
                        var json1 = JsonConvert.SerializeObject(dataTable);
                        await File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory + @"\khorasan", tableName + ".json"), json1, Encoding.UTF8);
                        dataSet.Tables.Add(dataTable);
                    }
                }
                dataSet.AcceptChanges();
                timer.Stop();

                Console.WriteLine();
                Console.WriteLine("Done!({0:g})", timer.Elapsed);
                Console.WriteLine();

                var jsonResults = DataSetToJson(dataSet);
                var jsonFile = "test-" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".json";
                await File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory, jsonFile), jsonResults, Encoding.UTF8);

                Console.WriteLine("Data loaded in '" + jsonFile + "'");
            }

            Console.ReadLine();
        }

        public async Task<DataSet> GetOLEDB(string dbName, string password = "")
        {
            var sourceFile = Environment.CurrentDirectory + dbName;
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";";
            if (password != "")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";Jet OLEDB:Database Password=8k#w%sXzKlAq!209_+4#;";
            }

            using (var db = new OleDbConnection(connectionString))
            {
                await db.OpenAsync();

                var schemaTable = db.GetSchema("Tables");
                var dataSet = new DataSet();

                Console.WriteLine();
                Console.WriteLine("Tables:");
                Console.WriteLine();

                var timer = new Stopwatch();
                timer.Start();
                for (var i = 0; i < schemaTable.Rows.Count; i++)
                {
                    //only source tables
                    if (schemaTable.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
                    {
                        var tableName = schemaTable.Rows[i]["TABLE_NAME"].ToString();
                        var sql = "SELECT * FROM [" + tableName + "]";
                        var dataTable = new DataTable(tableName);

                        using (var command = new OleDbCommand(sql, db))
                        {
                            using (var adapter = new OleDbDataAdapter(command))
                            {
                                adapter.Fill(dataTable);
                            }
                        }

                        Console.WriteLine(tableName + "(" + dataTable.Rows.Count + " rows)");
                        dataSet.Tables.Add(dataTable);
                    }
                }
                dataSet.AcceptChanges();
                timer.Stop();

                Console.WriteLine();
                Console.WriteLine("Done!({0:g})", timer.Elapsed);
                Console.WriteLine();
                Console.WriteLine("Data loaded ");
                return dataSet;
            }
        }

        private string DataSetToJson(DataSet ds)
        {
            var results = new List<object>();
            foreach (var table in ds.Tables.Cast<DataTable>())
            {

                var parentRows = new List<Dictionary<string, object>>();
                foreach (var row in table.Rows.Cast<DataRow>())
                {

                    var childRow = new Dictionary<string, object>();
                    foreach (var column in table.Columns.Cast<DataColumn>())
                    {
                        childRow.Add(column.ColumnName, row[column]);
                    }

                    parentRows.Add(childRow);
                }

                results.Add(new
                {
                    name = table.TableName,
                    items = parentRows
                });
            }

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> Export()
        {
            throw new NotImplementedException();
        }


        //public static void ListToExcel(List<string> list)
        //{
        //    //start excel
        //    NsExcel.ApplicationClass excapp = new Microsoft.Office.Interop.Excel.ApplicationClass();

        //    //if you want to make excel visible           
        //    excapp.Visible = true;

        //    //create a blank workbook
        //    var workbook = excapp.Workbooks.Add(NsExcel.XlWBATemplate.xlWBATWorksheet);

        //    //or open one - this is no pleasant, but yue're probably interested in the first parameter
        //    //string workbookPath = "C:\test.xls";
        //    //workbook = excapp.Workbooks.Open(workbookPath,
        //    //    0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        //    //    true, false, 0, true, false, false);

        //    //Not done yet. You have to work on a specific sheet - note the cast
        //    //You may not have any sheets at all. Then you have to add one with NsExcel.Worksheet.Add()
        //    var sheet = (NsExcel.Worksheet)workbook.Sheets[1]; //indexing starts from 1

        //    //do something usefull: you select now an individual cell
        //    var range = sheet.get_Range("A1", "A1");
        //    range.Value2 = "test"; //Value2 is not a typo

        //    //now the list
        //    string cellName;
        //    int counter = 1;
        //    foreach (var item in list)
        //    {
        //        cellName = "A" + counter.ToString();
        //        var range1 = sheet.get_Range(cellName, cellName);
        //        range1.Value2 = item.ToString();
        //        ++counter;
        //    }

        //    //you've probably got the point by now, so a detailed explanation about workbook.SaveAs and workbook.Close is not necessary
        //    //important: if you did not make excel visible terminating your application will terminate excel as well - I tested it
        //    //but if you did it - to be honest - I don't know how to close the main excel window - maybee somewhere around excapp.Windows or excapp.ActiveWindow
        //}

        //public static void ListToExcel(List<EquivalentSubsidiary> list)
        //{
        //    //start excel
        //    NsExcel.ApplicationClass excapp = new Microsoft.Office.Interop.Excel.ApplicationClass();

        //    //if you want to make excel visible           
        //    excapp.Visible = true;

        //    //create a blank workbook
        //    var workbook = excapp.Workbooks.Add(NsExcel.XlWBATemplate.xlWBATWorksheet);

        //    //or open one - this is no pleasant, but yue're probably interested in the first parameter
        //    //string workbookPath = "C:\test.xls";
        //    //workbook = excapp.Workbooks.Open(workbookPath,
        //    //    0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
        //    //    true, false, 0, true, false, false);

        //    //Not done yet. You have to work on a specific sheet - note the cast
        //    //You may not have any sheets at all. Then you have to add one with NsExcel.Worksheet.Add()
        //    var sheet = (NsExcel.Worksheet)workbook.Sheets[1]; //indexing starts from 1

        //    //do something usefull: you select now an individual cell
        //    var range = sheet.get_Range("A1", "A1");
        //    range.Value2 = "test"; //Value2 is not a typo

        //    //now the list
        //    string cellName;
        //    int counter = 1;
        //    foreach (var item in list)
        //    {
        //        cellName = "A" + counter.ToString();
        //        var range1 = sheet.get_Range(cellName, cellName);
        //        range1.Value2 = item.OldCode.ToString();

        //        cellName = "B" + counter.ToString();
        //        var range2 = sheet.get_Range(cellName, cellName);
        //        range2.Value2 = item.NewCode.ToString();
        //        ++counter;
        //    }

        //    //you've probably got the point by now, so a detailed explanation about workbook.SaveAs and workbook.Close is not necessary
        //    //important: if you did not make excel visible terminating your application will terminate excel as well - I tested it
        //    //but if you did it - to be honest - I don't know how to close the main excel window - maybee somewhere around excapp.Windows or excapp.ActiveWindow
        //}


        //private static void LoadGeneralLedgerAccount(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<GeneralLedgerAccount>>(File.ReadAllText(fileUrl));
        //    destinationData.GeneralLedgerAccountList = data.ToList();
        //}

        //private static void LoadSubsidiaryLedgerAccount(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<SubsidiaryLedgerAccount>>(File.ReadAllText(fileUrl));
        //    destinationData.SubsidiaryLedgerAccountList = data.ToList();
        //}

        //private static void LoadDetailAccount(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<DetailAccount>>(File.ReadAllText(fileUrl));
        //    destinationData.DetailAccountList = data.ToList();
        //}

        //private static void LoadFiscalPeriod(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<FiscalPeriod>>(File.ReadAllText(fileUrl));
        //    destinationData.FiscalPeriodList = data.ToList();
        //}

        //private static void LoadJournal(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Journal>>(File.ReadAllText(fileUrl));
        //    destinationData.JournalList = data.ToList();
        //}

        //private static void LoadJournalItem(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<JournalItem>>(File.ReadAllText(fileUrl));
        //    destinationData.JournalItemList = data.ToList();
        //}

        //private static void LoadAccountCategories(string fileUrl)
        //{
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AccountCategories>>(File.ReadAllText(fileUrl));
        //    destinationData.AccountCategoriesList = data.ToList();
        //}

    }
}

