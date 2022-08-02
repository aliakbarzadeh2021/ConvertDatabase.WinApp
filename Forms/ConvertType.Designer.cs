namespace ConvertDatabase.WinApp
{
    partial class ConvertType
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioJournals = new System.Windows.Forms.RadioButton();
            this.radioTreasury = new System.Windows.Forms.RadioButton();
            this.radioPromissory = new System.Windows.Forms.RadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(89, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "نوع اطلاعات کانورت را مشخص کنید";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(522, 402);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(603, 402);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(696, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radioJournals
            // 
            this.radioJournals.AutoSize = true;
            this.radioJournals.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioJournals.Location = new System.Drawing.Point(134, 113);
            this.radioJournals.Name = "radioJournals";
            this.radioJournals.Size = new System.Drawing.Size(154, 34);
            this.radioJournals.TabIndex = 8;
            this.radioJournals.TabStop = true;
            this.radioJournals.Text = "سند حسابداری";
            this.radioJournals.UseVisualStyleBackColor = true;
            // 
            // radioTreasury
            // 
            this.radioTreasury.AutoSize = true;
            this.radioTreasury.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioTreasury.Location = new System.Drawing.Point(134, 148);
            this.radioTreasury.Name = "radioTreasury";
            this.radioTreasury.Size = new System.Drawing.Size(62, 34);
            this.radioTreasury.TabIndex = 9;
            this.radioTreasury.TabStop = true;
            this.radioTreasury.Text = "چک";
            this.radioTreasury.UseVisualStyleBackColor = true;
            // 
            // radioPromissory
            // 
            this.radioPromissory.AutoSize = true;
            this.radioPromissory.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioPromissory.Location = new System.Drawing.Point(134, 184);
            this.radioPromissory.Name = "radioPromissory";
            this.radioPromissory.Size = new System.Drawing.Size(78, 34);
            this.radioPromissory.TabIndex = 10;
            this.radioPromissory.TabStop = true;
            this.radioPromissory.Text = "سفته";
            this.radioPromissory.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(65, 379);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 25);
            this.lblMessage.TabIndex = 11;
            // 
            // ConvertType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.radioPromissory);
            this.Controls.Add(this.radioTreasury);
            this.Controls.Add(this.radioJournals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "ConvertType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConvertType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioJournals;
        private System.Windows.Forms.RadioButton radioTreasury;
        private System.Windows.Forms.RadioButton radioPromissory;
        private System.Windows.Forms.Label lblMessage;
    }
}