namespace ConvertDatabase.WinApp
{
    partial class SoftwareType
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
            this.radioShahd = new System.Windows.Forms.RadioButton();
            this.radioAfra = new System.Windows.Forms.RadioButton();
            this.radioSepidar = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioOthers = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(518, 399);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(599, 399);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(692, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radioShahd
            // 
            this.radioShahd.AutoSize = true;
            this.radioShahd.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioShahd.Location = new System.Drawing.Point(119, 195);
            this.radioShahd.Name = "radioShahd";
            this.radioShahd.Size = new System.Drawing.Size(71, 34);
            this.radioShahd.TabIndex = 14;
            this.radioShahd.TabStop = true;
            this.radioShahd.Text = "شهد";
            this.radioShahd.UseVisualStyleBackColor = true;
            // 
            // radioAfra
            // 
            this.radioAfra.AutoSize = true;
            this.radioAfra.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAfra.Location = new System.Drawing.Point(119, 159);
            this.radioAfra.Name = "radioAfra";
            this.radioAfra.Size = new System.Drawing.Size(59, 34);
            this.radioAfra.TabIndex = 13;
            this.radioAfra.TabStop = true;
            this.radioAfra.Text = "افرا";
            this.radioAfra.UseVisualStyleBackColor = true;
            // 
            // radioSepidar
            // 
            this.radioSepidar.AutoSize = true;
            this.radioSepidar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSepidar.Location = new System.Drawing.Point(119, 124);
            this.radioSepidar.Name = "radioSepidar";
            this.radioSepidar.Size = new System.Drawing.Size(88, 34);
            this.radioSepidar.TabIndex = 12;
            this.radioSepidar.TabStop = true;
            this.radioSepidar.Text = "سپیدار";
            this.radioSepidar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(74, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "پروفایل خود را مشخص کنید";
            // 
            // radioOthers
            // 
            this.radioOthers.AutoSize = true;
            this.radioOthers.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioOthers.Location = new System.Drawing.Point(119, 235);
            this.radioOthers.Name = "radioOthers";
            this.radioOthers.Size = new System.Drawing.Size(140, 34);
            this.radioOthers.TabIndex = 15;
            this.radioOthers.TabStop = true;
            this.radioOthers.Text = "پروفایل جدید";
            this.radioOthers.UseVisualStyleBackColor = true;
            // 
            // SoftwareType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioOthers);
            this.Controls.Add(this.radioShahd);
            this.Controls.Add(this.radioAfra);
            this.Controls.Add(this.radioSepidar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Name = "SoftwareType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftwareType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioShahd;
        private System.Windows.Forms.RadioButton radioAfra;
        private System.Windows.Forms.RadioButton radioSepidar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioOthers;
    }
}