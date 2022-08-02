namespace ConvertDatabase.WinApp.Forms
{
    partial class ColumnMapping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mappingDataGridView = new System.Windows.Forms.DataGridView();
            this.Origins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Targets = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbTableList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(699, 366);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(699, 332);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(699, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mappingDataGridView
            // 
            this.mappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origins,
            this.Targets,
            this.Method});
            this.mappingDataGridView.Location = new System.Drawing.Point(24, 55);
            this.mappingDataGridView.Name = "mappingDataGridView";
            this.mappingDataGridView.RowTemplate.Height = 25;
            this.mappingDataGridView.Size = new System.Drawing.Size(536, 383);
            this.mappingDataGridView.TabIndex = 8;
            // 
            // Origins
            // 
            this.Origins.HeaderText = "Origins";
            this.Origins.Name = "Origins";
            this.Origins.Width = 130;
            // 
            // Targets
            // 
            this.Targets.HeaderText = "Targets";
            this.Targets.Name = "Targets";
            this.Targets.Width = 130;
            // 
            // Method
            // 
            this.Method.HeaderText = "Method";
            this.Method.Name = "Method";
            this.Method.Width = 200;
            // 
            // cmbTableList
            // 
            this.cmbTableList.FormattingEnabled = true;
            this.cmbTableList.Location = new System.Drawing.Point(81, 12);
            this.cmbTableList.Name = "cmbTableList";
            this.cmbTableList.Size = new System.Drawing.Size(175, 23);
            this.cmbTableList.TabIndex = 9;
            this.cmbTableList.SelectedIndexChanged += new System.EventHandler(this.cmbTableList_SelectedIndexChanged);
            // 
            // ColumnMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTableList);
            this.Controls.Add(this.mappingDataGridView);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "ColumnMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Column Mapping";
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView mappingDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origins;
        private System.Windows.Forms.DataGridViewComboBoxColumn Targets;
        private System.Windows.Forms.DataGridViewComboBoxColumn Method;
        private System.Windows.Forms.ComboBox cmbTableList;
    }
}