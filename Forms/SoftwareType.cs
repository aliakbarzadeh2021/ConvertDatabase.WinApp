using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Forms;
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
    public partial class SoftwareType : Form
    {
        IConvertEngine Engine { get; set; }

        public SoftwareType(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public SoftwareType()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            if (radioSepidar.Checked)
            {
                Engine.SetSoftwareTypeEnum(SoftwareTypeEnum.Sepidar);
                isChecked = true;
            }
            else if (radioAfra.Checked)
            {
                Engine.SetSoftwareTypeEnum(SoftwareTypeEnum.Afra);
                isChecked = true;
            }
            else if (radioShahd.Checked)
            {
                Engine.SetSoftwareTypeEnum(SoftwareTypeEnum.Shahd);
                isChecked = true;
            }
            else if (radioOthers.Checked)
            {
                Engine.SetSoftwareTypeEnum(SoftwareTypeEnum.Others);
                isChecked = true;
            }

            if (isChecked)
            {
                Next();
            }
        }

        private void Next()
        {
            ImportSource form = new ImportSource(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ConvertType form = new ConvertType(Engine);
            form.Show();
            this.Hide();
        }
    }
}
