namespace ConvertDatabase.WinApp.Forms
{
    partial class ImportTarget
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
            this.label2 = new System.Windows.Forms.Label();
            this.radioSQLServer = new System.Windows.Forms.RadioButton();
            this.radioODBC = new System.Windows.Forms.RadioButton();
            this.radioAccess = new System.Windows.Forms.RadioButton();
            this.radioJson = new System.Windows.Forms.RadioButton();
            this.radioExcel = new System.Windows.Forms.RadioButton();
            this.radioPostgresql = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(504, 401);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(585, 401);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(678, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(81, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 37);
            this.label2.TabIndex = 17;
            this.label2.Text = "نوع خروجی را مشخص کنید";
            // 
            // radioSQLServer
            // 
            this.radioSQLServer.AutoSize = true;
            this.radioSQLServer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSQLServer.Location = new System.Drawing.Point(81, 242);
            this.radioSQLServer.Name = "radioSQLServer";
            this.radioSQLServer.Size = new System.Drawing.Size(224, 34);
            this.radioSQLServer.TabIndex = 22;
            this.radioSQLServer.TabStop = true;
            this.radioSQLServer.Text = "SQL Server Database";
            this.radioSQLServer.UseVisualStyleBackColor = true;
            // 
            // radioODBC
            // 
            this.radioODBC.AutoSize = true;
            this.radioODBC.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioODBC.Location = new System.Drawing.Point(81, 322);
            this.radioODBC.Name = "radioODBC";
            this.radioODBC.Size = new System.Drawing.Size(87, 34);
            this.radioODBC.TabIndex = 21;
            this.radioODBC.TabStop = true;
            this.radioODBC.Text = "ODBC";
            this.radioODBC.UseVisualStyleBackColor = true;
            this.radioODBC.Visible = false;
            // 
            // radioAccess
            // 
            this.radioAccess.AutoSize = true;
            this.radioAccess.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAccess.Location = new System.Drawing.Point(81, 202);
            this.radioAccess.Name = "radioAccess";
            this.radioAccess.Size = new System.Drawing.Size(223, 34);
            this.radioAccess.TabIndex = 20;
            this.radioAccess.TabStop = true;
            this.radioAccess.Text = "MS Access Database";
            this.radioAccess.UseVisualStyleBackColor = true;
            // 
            // radioJson
            // 
            this.radioJson.AutoSize = true;
            this.radioJson.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioJson.Location = new System.Drawing.Point(81, 164);
            this.radioJson.Name = "radioJson";
            this.radioJson.Size = new System.Drawing.Size(119, 34);
            this.radioJson.TabIndex = 19;
            this.radioJson.TabStop = true;
            this.radioJson.Text = "JSON File";
            this.radioJson.UseVisualStyleBackColor = true;
            // 
            // radioExcel
            // 
            this.radioExcel.AutoSize = true;
            this.radioExcel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioExcel.Location = new System.Drawing.Point(81, 124);
            this.radioExcel.Name = "radioExcel";
            this.radioExcel.Size = new System.Drawing.Size(112, 34);
            this.radioExcel.TabIndex = 18;
            this.radioExcel.TabStop = true;
            this.radioExcel.Text = "Excel file";
            this.radioExcel.UseVisualStyleBackColor = true;
            // 
            // radioPostgresql
            // 
            this.radioPostgresql.AutoSize = true;
            this.radioPostgresql.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioPostgresql.Location = new System.Drawing.Point(81, 282);
            this.radioPostgresql.Name = "radioPostgresql";
            this.radioPostgresql.Size = new System.Drawing.Size(230, 34);
            this.radioPostgresql.TabIndex = 23;
            this.radioPostgresql.TabStop = true;
            this.radioPostgresql.Text = "PostgreSQL Database";
            this.radioPostgresql.UseVisualStyleBackColor = true;
            // 
            // ImportTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioPostgresql);
            this.Controls.Add(this.radioSQLServer);
            this.Controls.Add(this.radioODBC);
            this.Controls.Add(this.radioAccess);
            this.Controls.Add(this.radioJson);
            this.Controls.Add(this.radioExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "ImportTarget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportTarget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioSQLServer;
        private System.Windows.Forms.RadioButton radioODBC;
        private System.Windows.Forms.RadioButton radioAccess;
        private System.Windows.Forms.RadioButton radioJson;
        private System.Windows.Forms.RadioButton radioExcel;
        private System.Windows.Forms.RadioButton radioPostgresql;
    }
}