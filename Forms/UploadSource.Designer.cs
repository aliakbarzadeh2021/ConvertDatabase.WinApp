namespace ConvertDatabase.WinApp.Forms
{
    partial class UploadSource
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
            this.txtCategoryFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenCategory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenGeneral = new System.Windows.Forms.Button();
            this.txtGeneralFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenSubsidary = new System.Windows.Forms.Button();
            this.txtSubsidaryFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpenJournals = new System.Windows.Forms.Button();
            this.txtJournalsFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenFiscal = new System.Windows.Forms.Button();
            this.txtFiscalFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenDetail = new System.Windows.Forms.Button();
            this.txtDetailFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOpenJournalLines = new System.Windows.Forms.Button();
            this.txtJournalLinesFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(511, 631);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(592, 631);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(685, 631);
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
            this.label2.Location = new System.Drawing.Point(75, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 37);
            this.label2.TabIndex = 12;
            this.label2.Text = "فایل های ورودی را بارگزاری کنید";
            // 
            // txtCategoryFilePath
            // 
            this.txtCategoryFilePath.Location = new System.Drawing.Point(126, 88);
            this.txtCategoryFilePath.Name = "txtCategoryFilePath";
            this.txtCategoryFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtCategoryFilePath.TabIndex = 13;
            // 
            // btnOpenCategory
            // 
            this.btnOpenCategory.Location = new System.Drawing.Point(685, 88);
            this.btnOpenCategory.Name = "btnOpenCategory";
            this.btnOpenCategory.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCategory.TabIndex = 14;
            this.btnOpenCategory.Text = "...";
            this.btnOpenCategory.UseVisualStyleBackColor = true;
            this.btnOpenCategory.Click += new System.EventHandler(this.btnOpenCategory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(459, 54);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(301, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "فایل دسته بندی حساب ها Account Category";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(459, 136);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(307, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "فایل حساب های کل General Ledger Account";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenGeneral
            // 
            this.btnOpenGeneral.Location = new System.Drawing.Point(685, 170);
            this.btnOpenGeneral.Name = "btnOpenGeneral";
            this.btnOpenGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnOpenGeneral.TabIndex = 17;
            this.btnOpenGeneral.Text = "...";
            this.btnOpenGeneral.UseVisualStyleBackColor = true;
            this.btnOpenGeneral.Click += new System.EventHandler(this.btnOpenGeneral_Click);
            // 
            // txtGeneralFilePath
            // 
            this.txtGeneralFilePath.Location = new System.Drawing.Point(126, 170);
            this.txtGeneralFilePath.Name = "txtGeneralFilePath";
            this.txtGeneralFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtGeneralFilePath.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(432, 213);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(328, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "فایل حساب های معین Subsidary Leger Account";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenSubsidary
            // 
            this.btnOpenSubsidary.Location = new System.Drawing.Point(685, 247);
            this.btnOpenSubsidary.Name = "btnOpenSubsidary";
            this.btnOpenSubsidary.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSubsidary.TabIndex = 20;
            this.btnOpenSubsidary.Text = "...";
            this.btnOpenSubsidary.UseVisualStyleBackColor = true;
            this.btnOpenSubsidary.Click += new System.EventHandler(this.btnOpenSubsidary_Click);
            // 
            // txtSubsidaryFilePath
            // 
            this.txtSubsidaryFilePath.Location = new System.Drawing.Point(126, 247);
            this.txtSubsidaryFilePath.Name = "txtSubsidaryFilePath";
            this.txtSubsidaryFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtSubsidaryFilePath.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(557, 453);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(203, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "فایل اسناد حسابداری Journals";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenJournals
            // 
            this.btnOpenJournals.Location = new System.Drawing.Point(685, 489);
            this.btnOpenJournals.Name = "btnOpenJournals";
            this.btnOpenJournals.Size = new System.Drawing.Size(75, 23);
            this.btnOpenJournals.TabIndex = 29;
            this.btnOpenJournals.Text = "...";
            this.btnOpenJournals.UseVisualStyleBackColor = true;
            this.btnOpenJournals.Click += new System.EventHandler(this.btnOpenJournals_Click);
            // 
            // txtJournalsFilePath
            // 
            this.txtJournalsFilePath.Location = new System.Drawing.Point(126, 489);
            this.txtJournalsFilePath.Name = "txtJournalsFilePath";
            this.txtJournalsFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtJournalsFilePath.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Location = new System.Drawing.Point(565, 378);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(195, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "فایل سال مالی Fiscal Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenFiscal
            // 
            this.btnOpenFiscal.Location = new System.Drawing.Point(685, 412);
            this.btnOpenFiscal.Name = "btnOpenFiscal";
            this.btnOpenFiscal.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFiscal.TabIndex = 26;
            this.btnOpenFiscal.Text = "...";
            this.btnOpenFiscal.UseVisualStyleBackColor = true;
            this.btnOpenFiscal.Click += new System.EventHandler(this.btnOpenFiscal_Click);
            // 
            // txtFiscalFilePath
            // 
            this.txtFiscalFilePath.Location = new System.Drawing.Point(126, 412);
            this.txtFiscalFilePath.Name = "txtFiscalFilePath";
            this.txtFiscalFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtFiscalFilePath.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(486, 296);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(274, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "فایل حساب های تفضیل Detail Accounts";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenDetail
            // 
            this.btnOpenDetail.Location = new System.Drawing.Point(685, 330);
            this.btnOpenDetail.Name = "btnOpenDetail";
            this.btnOpenDetail.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDetail.TabIndex = 23;
            this.btnOpenDetail.Text = "...";
            this.btnOpenDetail.UseVisualStyleBackColor = true;
            this.btnOpenDetail.Click += new System.EventHandler(this.btnOpenDetail_Click);
            // 
            // txtDetailFilePath
            // 
            this.txtDetailFilePath.Location = new System.Drawing.Point(126, 330);
            this.txtDetailFilePath.Name = "txtDetailFilePath";
            this.txtDetailFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtDetailFilePath.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(476, 538);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(284, 21);
            this.label8.TabIndex = 33;
            this.label8.Text = "فایل جزئیات اسناد حسابداری Journal Lines";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenJournalLines
            // 
            this.btnOpenJournalLines.Location = new System.Drawing.Point(685, 577);
            this.btnOpenJournalLines.Name = "btnOpenJournalLines";
            this.btnOpenJournalLines.Size = new System.Drawing.Size(75, 23);
            this.btnOpenJournalLines.TabIndex = 32;
            this.btnOpenJournalLines.Text = "...";
            this.btnOpenJournalLines.UseVisualStyleBackColor = true;
            this.btnOpenJournalLines.Click += new System.EventHandler(this.btnOpenJournalLines_Click);
            // 
            // txtJournalLinesFilePath
            // 
            this.txtJournalLinesFilePath.Location = new System.Drawing.Point(126, 577);
            this.txtJournalLinesFilePath.Name = "txtJournalLinesFilePath";
            this.txtJournalLinesFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtJournalLinesFilePath.TabIndex = 31;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 673);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOpenJournalLines);
            this.Controls.Add(this.txtJournalLinesFilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOpenJournals);
            this.Controls.Add(this.txtJournalsFilePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpenFiscal);
            this.Controls.Add(this.txtFiscalFilePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOpenDetail);
            this.Controls.Add(this.txtDetailFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenSubsidary);
            this.Controls.Add(this.txtSubsidaryFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenGeneral);
            this.Controls.Add(this.txtGeneralFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenCategory);
            this.Controls.Add(this.txtCategoryFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "UploadSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UploadSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoryFilePath;
        private System.Windows.Forms.Button btnOpenCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenGeneral;
        private System.Windows.Forms.TextBox txtGeneralFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenSubsidary;
        private System.Windows.Forms.TextBox txtSubsidaryFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenJournals;
        private System.Windows.Forms.TextBox txtJournalsFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenFiscal;
        private System.Windows.Forms.TextBox txtFiscalFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenDetail;
        private System.Windows.Forms.TextBox txtDetailFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOpenJournalLines;
        private System.Windows.Forms.TextBox txtJournalLinesFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}