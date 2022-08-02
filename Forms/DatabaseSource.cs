using ConvertDatabase.WinApp.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp.Forms
{
    public partial class DatabaseSource : Form
    {
        IConvertEngine Engine { get; set; }

        public DatabaseSource()
        {
            InitializeComponent();
            InitialDatabaseType();
        }

        public DatabaseSource(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
            InitialDatabaseType();
        }

        private void InitialDatabaseType()
        {
            //cmbDatabase.Items.Add(KeyValuePair.Create(1,"SQL Server"));
            //cmbDatabase.Items.Add(KeyValuePair.Create(2,"Access"));
            //cmbDatabase.Items.Add(KeyValuePair.Create(3, "PostgreSQL"));
            cmbDatabase.Items.Add("SQL Server");
            cmbDatabase.Items.Add("Access");
            cmbDatabase.Items.Add("PostgreSQL");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ImportSource form = new ImportSource(Engine);
            form.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void Next()
        {
            ImportTarget form = new ImportTarget(Engine );
            form.Show();
            this.Hide();
        }
    }
}
