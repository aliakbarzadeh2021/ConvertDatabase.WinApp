using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp.Forms
{
    public partial class ImportSource : Form
    {
        IConvertEngine Engine { get; set; }

        public ImportSource(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public ImportSource()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
             
            if (radioExcel.Checked)
            {
                //Engine.SetImportRepository(new ExcelRepository());
                Engine.SetImportRepository(Models.InputTypeEnum.Excel);
                NextFile();
            }
            else if (radioJson.Checked)
            {
                //Engine.SetImportRepository(new JsonRepository());
                Engine.SetImportRepository(Models.InputTypeEnum.Json);
                NextFile();
            }
            else if (radioAccess.Checked)
            {
                //Engine.SetImportRepository(new AccessRepository());
                Engine.SetImportRepository(Models.InputTypeEnum.Access);
                NextDatabase();
            }
            else if (radioODBC.Checked)
            {
                //Engine.SetImportRepository(new ODBCRepository());
                //Engine.SetImportRepository(Models.InputTypeEnum.);
                //NextDatabase();
            }
            else if (radioSQLServer.Checked)
            {
                //Engine.SetImportRepository(new AdoRepository());
                Engine.SetImportRepository(Models.InputTypeEnum.SQLServer);
                NextDatabase();
            }

             
        }

        private void NextFile()
        {
            UploadSource form = new UploadSource(Engine);
            form.Show();
            this.Hide();
        }

        private void NextDatabase()
        {
            DatabaseSource form = new DatabaseSource(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SoftwareType form = new SoftwareType(Engine);
            form.Show();
            this.Hide();
        }
    }
}
