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
    public partial class UploadSource : Form
    {
        IConvertEngine Engine { get; set; }

        public UploadSource(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public UploadSource()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var journalFilesPath = new JournalFilesPath();
            journalFilesPath.AccountCategoryFilePath = txtCategoryFilePath.Text;
            journalFilesPath.GeneralLedgerAccountFilePath = txtGeneralFilePath.Text;
            journalFilesPath.SubsidiaryLedgerAccountFilePath = txtSubsidaryFilePath.Text;
            journalFilesPath.DetailAccountsFilePath = txtDetailFilePath.Text;
            journalFilesPath.FiscalPeriodFilePath = txtFiscalFilePath.Text;
            journalFilesPath.JournalFilePath = txtJournalsFilePath.Text;
            journalFilesPath.JournalItemFilePath = txtJournalLinesFilePath.Text;

            Engine.SetImportSourcePath(journalFilesPath);
            Next();
        }

        private void Next()
        {
            ImportTarget form = new ImportTarget(Engine);
            form.Show();
            this.Hide();
        }

        private void btnOpenCategory_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtCategoryFilePath.Text = filePath;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ImportSource form = new ImportSource(Engine);
            form.Show();
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

        private void btnOpenFiscal_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtFiscalFilePath.Text = filePath;
            }
        }

        private void btnOpenJournals_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtJournalsFilePath.Text = filePath;
            }
        }

        private void btnOpenJournalLines_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtJournalLinesFilePath.Text = filePath;
            }
        }
    }
}
