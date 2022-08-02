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
    public partial class DatabaseTarget : Form
    {
        IConvertEngine Engine { get; set; }
        public DatabaseTarget()
        {
            InitializeComponent();
        }

        public DatabaseTarget(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ImportTarget form = new ImportTarget(Engine);
            form.Show();
            this.Hide();
        }

        private void Next()
        {
            UploadMapping form = new UploadMapping(Engine);
            form.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
