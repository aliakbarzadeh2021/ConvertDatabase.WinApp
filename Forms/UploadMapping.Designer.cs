namespace ConvertDatabase.WinApp.Forms
{
    partial class UploadMapping
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenSubsidary = new System.Windows.Forms.Button();
            this.txtSubsidaryFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenDetail = new System.Windows.Forms.Button();
            this.txtDetailFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenGeneral = new System.Windows.Forms.Button();
            this.txtGeneralFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(510, 398);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(591, 398);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(684, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(329, 286);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(385, 21);
            this.label4.TabIndex = 52;
            this.label4.Text = "فایل معادل سازی حساب های معین Subsidary Equivalent";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenSubsidary
            // 
            this.btnOpenSubsidary.Location = new System.Drawing.Point(639, 321);
            this.btnOpenSubsidary.Name = "btnOpenSubsidary";
            this.btnOpenSubsidary.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSubsidary.TabIndex = 51;
            this.btnOpenSubsidary.Text = "...";
            this.btnOpenSubsidary.UseVisualStyleBackColor = true;
            this.btnOpenSubsidary.Click += new System.EventHandler(this.btnOpenSubsidary_Click);
            // 
            // txtSubsidaryFilePath
            // 
            this.txtSubsidaryFilePath.Location = new System.Drawing.Point(80, 321);
            this.txtSubsidaryFilePath.Name = "txtSubsidaryFilePath";
            this.txtSubsidaryFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtSubsidaryFilePath.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(347, 198);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(367, 21);
            this.label3.TabIndex = 49;
            this.label3.Text = "فایل معادل سازی حساب های تفضیل Detail Equivalent";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenDetail
            // 
            this.btnOpenDetail.Location = new System.Drawing.Point(639, 236);
            this.btnOpenDetail.Name = "btnOpenDetail";
            this.btnOpenDetail.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDetail.TabIndex = 48;
            this.btnOpenDetail.Text = "...";
            this.btnOpenDetail.UseVisualStyleBackColor = true;
            this.btnOpenDetail.Click += new System.EventHandler(this.btnOpenDetail_Click);
            // 
            // txtDetailFilePath
            // 
            this.txtDetailFilePath.Location = new System.Drawing.Point(80, 236);
            this.txtDetailFilePath.Name = "txtDetailFilePath";
            this.txtDetailFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtDetailFilePath.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(359, 118);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(355, 21);
            this.label1.TabIndex = 46;
            this.label1.Text = "فایل معادل سازی حساب های کل General Equivalent";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenGeneral
            // 
            this.btnOpenGeneral.Location = new System.Drawing.Point(639, 154);
            this.btnOpenGeneral.Name = "btnOpenGeneral";
            this.btnOpenGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnOpenGeneral.TabIndex = 45;
            this.btnOpenGeneral.Text = "...";
            this.btnOpenGeneral.UseVisualStyleBackColor = true;
            this.btnOpenGeneral.Click += new System.EventHandler(this.btnOpenGeneral_Click);
            // 
            // txtGeneralFilePath
            // 
            this.txtGeneralFilePath.Location = new System.Drawing.Point(80, 154);
            this.txtGeneralFilePath.Name = "txtGeneralFilePath";
            this.txtGeneralFilePath.Size = new System.Drawing.Size(536, 23);
            this.txtGeneralFilePath.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(65, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 37);
            this.label2.TabIndex = 43;
            this.label2.Text = "فایل های معادل سازی اطلاعات را بارگزاری کنید";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(274, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "الزامی";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenSubsidary);
            this.Controls.Add(this.txtSubsidaryFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenDetail);
            this.Controls.Add(this.txtDetailFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenGeneral);
            this.Controls.Add(this.txtGeneralFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "UploadMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UploadMapping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenSubsidary;
        private System.Windows.Forms.TextBox txtSubsidaryFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenDetail;
        private System.Windows.Forms.TextBox txtDetailFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenGeneral;
        private System.Windows.Forms.TextBox txtGeneralFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}