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
    public partial class ImportTarget : Form
    {
        IConvertEngine Engine { get; set; }

        public ImportTarget(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public ImportTarget()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radioExcel.Checked)
            {
                Engine.SetOutputRepository(Models.OutputTypeEnum.Excel);
                NextFile();
            }
            else if (radioJson.Checked)
            {
                Engine.SetOutputRepository(Models.OutputTypeEnum.Json);
                NextFile();
            }
            else if (radioAccess.Checked)
            {
                Engine.SetOutputRepository(Models.OutputTypeEnum.Access);
                NextDatabase();
            }
            else if (radioODBC.Checked)
            {
                //Engine.SetOutputRepository(Models.OutputTypeEnum.Excel);
                //NextDatabase();
            }
            else if (radioSQLServer.Checked)
            {
                Engine.SetOutputRepository(Models.OutputTypeEnum.SQLServer);
                NextDatabase();
            }
            else if (radioPostgresql.Checked)
            {
                Engine.SetOutputRepository(Models.OutputTypeEnum.Postgresql);
                NextDatabase();
            }

             
        }

        private void NextFile()
        {
            UploadTarget form = new UploadTarget(Engine);
            form.Show();
            this.Hide();
        }

        private void NextDatabase()
        {
            DatabaseTarget form = new DatabaseTarget(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Engine.HasDatabaseSource())
            {
                DatabaseSource form = new DatabaseSource(Engine);
                form.Show();
            }
            else
            {
                UploadSource form = new UploadSource(Engine);
                form.Show();
            }
            this.Hide();
        }
    }
}
