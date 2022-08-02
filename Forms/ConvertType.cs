using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp
{
    public partial class ConvertType : Form
    {
        IConvertEngine Engine { get; set; }
        public ConvertType()
        {
            InitializeComponent();
        }

        public ConvertType(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            if (radioJournals.Checked)
            {
                Engine.SetConvertTypeEnum(ConvertTypeEnum.Journals);
                isChecked = true;
                Next();
            }
            else if (radioTreasury.Checked)
            {
                Engine.SetConvertTypeEnum(ConvertTypeEnum.Treasury);
                isChecked = true;
                lblMessage.Text = "بخش چک و سفته در حال آماده سازی است";
            }
            else if (radioPromissory.Checked)
            {
                Engine.SetConvertTypeEnum(ConvertTypeEnum.Promissory);
                isChecked = true;
                lblMessage.Text = "بخش چک و سفته در حال آماده سازی است";
            }
             
            
        }

        private void Next()
        {
            SoftwareType form = new SoftwareType(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
