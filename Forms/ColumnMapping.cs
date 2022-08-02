using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Models;
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
    public partial class ColumnMapping : Form
    {
        IConvertEngine Engine { get; set; }
       

        public ColumnMapping(IConvertEngine engine)
        {
            Engine = engine;                      
            InitializeComponent();
            Initial();
        }

        public ColumnMapping()
        {
            InitializeComponent();
            Initial();
        }

        public void Initial()
        {
            

            cmbTableList.Items.Add("Journal");
            cmbTableList.Items.Add("JournalItem");
            cmbTableList.Items.Add("FiscalPeriod");
            cmbTableList.Items.Add("AccountCategories");
            cmbTableList.Items.Add("GeneralLedgerAccount");
            cmbTableList.Items.Add("SubsidiaryLedgerAccount");
            cmbTableList.Items.Add("DetailAccount");
            cmbTableList.Text = "Journal";

            LoadColumnMapping("Journal");
        }

        private void LoadColumnMapping(string typeName)
        {
            List<string> SourceColumns = new List<string>();
            List<string> TargetColumns = new List<string>();
            mappingDataGridView.Rows.Clear();
            var type = Type.GetType("ConvertDatabase.WinApp.Models."+typeName);
            foreach (var item in type.GetProperties())
            {
                SourceColumns.Add(item.Name);
                TargetColumns.Add(item.Name);
            }

            foreach (var col in SourceColumns)
            {
                var row = new DataGridViewRow();

                //First Cell
                var textbox = new DataGridViewTextBoxCell();
                textbox.Value = col;
                row.Cells.Add(textbox);

                //Second Cell
                var comboCell = new DataGridViewComboBoxCell();
                foreach (var colTarget in TargetColumns)
                {
                    comboCell.Items.Add(colTarget);
                }

                if (TargetColumns.Exists(i => i == col))
                {
                    comboCell.Value = col;
                }
                else
                {
                    comboCell.Items.Add("...");
                    comboCell.Value = "...";
                }

                row.Cells.Add(comboCell);
                                
                // Third Cell
                var methodComboCell = new DataGridViewComboBoxCell();
                methodComboCell.Items.Add("Normal");
                methodComboCell.Items.Add("NewGuid()");
                methodComboCell.Items.Add("ToString()");
                methodComboCell.Items.Add("ConvertToShamsi()");
                methodComboCell.Items.Add("ConvertToMiladi()");
                methodComboCell.Items.Add("double.Parse()");
                methodComboCell.Value = "Normal";
                row.Cells.Add(methodComboCell);

                mappingDataGridView.Rows.Add(row);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var mappColumns = GetMappColumns(mappingDataGridView);
            Engine.SetMappingColumns(mappColumns);
            Next();
        }

        private List<MapColumn> GetMappColumns(DataGridView mappingDataGridView)
        {
            List<MapColumn> maps = new List<MapColumn>();
            foreach (DataGridViewRow Row in mappingDataGridView.Rows)
            {
                if (Row.Cells[0].Value == null || Row.Cells[1].Value == null || Row.Cells[2].Value == null)
                {
                    continue;
                }
                var map = new MapColumn();
                map.SourceValue = Row.Cells[0].Value.ToString();
                map.TargetValue = Row.Cells[1].Value.ToString();
                map.Method = Row.Cells[2].Value.ToString();
                maps.Add(map);
            }
            return maps;
        }

        private void Next()
        {
            Analyse form = new Analyse(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TableMapping form = new TableMapping(Engine);
            form.Show();
            this.Hide();
        }

        private void cmbTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedItem = cmbTableList.SelectedItem.ToString();
            LoadColumnMapping(SelectedItem);
        }
    }
}
