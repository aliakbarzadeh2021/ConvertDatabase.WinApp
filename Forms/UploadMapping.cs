using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp.Forms
{
    public partial class UploadMapping : Form
    {
        IConvertEngine Engine { get; set; }

        public UploadMapping(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public UploadMapping()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var mappingFiles = new MappingFilesPath();
            mappingFiles.DetailEquivalent = txtDetailFilePath.Text;
            mappingFiles.GeneralEquivalent = txtGeneralFilePath.Text;
            mappingFiles.SubsidaryEquivalent = txtSubsidaryFilePath.Text;
            Engine.SetMappingFilesPath(mappingFiles);
            Next();
        }

        private void Next()
        {
            TableMapping form = new TableMapping(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Engine.HasDatabaseTarget())
            {
                DatabaseTarget form = new DatabaseTarget(Engine);
                form.Show();
            }
            else
            {
                UploadTarget form = new UploadTarget(Engine);
                form.Show();
            }
            this.Hide();
        }

        private void btnOpenGeneral_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtGeneralFilePath.Text = filePath;
            }
        }
                

        private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtDetailFilePath.Text = filePath;
            }
        }

        private void btnOpenSubsidary_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtSubsidaryFilePath.Text = filePath;
            }
        }
    }
}
