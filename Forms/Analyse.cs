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
    public partial class Analyse : Form
    {
        IConvertEngine Engine { get; set; }

        public Analyse(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public Analyse()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            IDataAnalysis dataAnalysis = new DataAnalysis();
            var result = dataAnalysis.Run();

            if (result.IsSuccess)
                Next();
        }

        private void Next()
        {
            Start form = new Start(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ColumnMapping form = new ColumnMapping(Engine);
            form.Show();
            this.Hide();
        }
    }
}
