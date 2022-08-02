using ConvertDatabase.WinApp.Engine;
using ConvertDatabase.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp.Forms
{
    public partial class TableMapping : Form
    {
        IConvertEngine Engine { get; set; }
        List<string> SourceColumns = new List<string>();
        List<string> TargetColumns = new List<string>();

        public TableMapping(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
            Initial();
        }

        public TableMapping()
        {
            InitializeComponent();
            Initial();
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
                if (Row.Cells[0].Value == null || Row.Cells[1].Value == null)
                {
                    continue;
                }

                var map = new MapColumn();
                map.SourceValue = Row.Cells[0].Value.ToString();
                map.TargetValue = Row.Cells[1].Value.ToString();
                maps.Add(map);
            }
            return maps;
        }

        public void Initial()
        {
            SourceColumns.Add("Journal");
            SourceColumns.Add("JournalLines");
            SourceColumns.Add("FiscalPeriod");
            SourceColumns.Add("AccuntCategory");
            SourceColumns.Add("GeneralLederAccount");
            SourceColumns.Add("SubsidaryLederAccount");
            SourceColumns.Add("DetailAccount");
            LoadTableMapping();
        }

        private void LoadTableMapping()
        {
            foreach (var col in SourceColumns)
            {
                var row = new DataGridViewRow();

                //First Cell
                var textbox = new DataGridViewTextBoxCell();
                textbox.Value = col;
                row.Cells.Add(textbox);

                //Second Cell
                var comboCell = new DataGridViewComboBoxCell();
                foreach (var colTarget in SourceColumns)
                {
                    comboCell.Items.Add(colTarget);
                }

                if (SourceColumns.Exists(i => i == col))
                {
                    comboCell.Value = col;
                }
                else
                {
                    comboCell.Items.Add("...");
                    comboCell.Value = "...";
                }

                row.Cells.Add(comboCell);

                mappingDataGridView.Rows.Add(row);
            }
        }

        private void Next()
        {
            ColumnMapping form = new ColumnMapping(Engine);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UploadMapping form = new UploadMapping(Engine);
            form.Show();
            this.Hide();
        }
    }
}
