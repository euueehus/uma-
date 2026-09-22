namespace uma_
{
    partial class last
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
            this.lvResult = new System.Windows.Forms.ListView();
            this.lstPay = new System.Windows.Forms.ListBox();
            this.lblGain = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvResult
            // 
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(550, 209);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(489, 351);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.SelectedIndexChanged += new System.EventHandler(this.lvResult_SelectedIndexChanged);
            // 
            // lstPay
            // 
            this.lstPay.FormattingEnabled = true;
            this.lstPay.ItemHeight = 18;
            this.lstPay.Location = new System.Drawing.Point(272, 109);
            this.lstPay.Name = "lstPay";
            this.lstPay.Size = new System.Drawing.Size(283, 94);
            this.lstPay.TabIndex = 1;
            this.lstPay.SelectedIndexChanged += new System.EventHandler(this.lstPay_SelectedIndexChanged);
            // 
            // lblGain
            // 
            this.lblGain.AutoSize = true;
            this.lblGain.Location = new System.Drawing.Point(579, 72);
            this.lblGain.Name = "lblGain";
            this.lblGain.Size = new System.Drawing.Size(50, 18);
            this.lblGain.TabIndex = 2;
            this.lblGain.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(633, 593);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(300, 66);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "確認";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // last
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 754);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblGain);
            this.Controls.Add(this.lstPay);
            this.Controls.Add(this.lvResult);
            this.Name = "last";
            this.Text = "last";
            this.Load += new System.EventHandler(this.last_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.ListBox lstPay;
        private System.Windows.Forms.Label lblGain;
        private System.Windows.Forms.Button btnBack;
    }
}