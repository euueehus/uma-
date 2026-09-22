namespace uma_
{
    partial class real_bet
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
            this.lblMoney = new System.Windows.Forms.Label();
            this.cmbTicket = new System.Windows.Forms.ComboBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.lvField = new System.Windows.Forms.ListView();
            this.lblPicks = new System.Windows.Forms.Label();
            this.numUnits = new System.Windows.Forms.NumericUpDown();
            this.r = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstSlips = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(683, 73);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(94, 18);
            this.lblMoney.TabIndex = 0;
            this.lblMoney.Text = "資金  10000";
            // 
            // cmbTicket
            // 
            this.cmbTicket.FormattingEnabled = true;
            this.cmbTicket.Location = new System.Drawing.Point(46, 190);
            this.cmbTicket.Name = "cmbTicket";
            this.cmbTicket.Size = new System.Drawing.Size(651, 26);
            this.cmbTicket.TabIndex = 1;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(743, 190);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(98, 18);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "請點選 1 匹";
            // 
            // lvField
            // 
            this.lvField.HideSelection = false;
            this.lvField.Location = new System.Drawing.Point(46, 222);
            this.lvField.Name = "lvField";
            this.lvField.Size = new System.Drawing.Size(646, 230);
            this.lvField.TabIndex = 3;
            this.lvField.UseCompatibleStateImageBehavior = false;
            this.lvField.ItemActivate += new System.EventHandler(this.lvField_ItemActivate);
            this.lvField.SelectedIndexChanged += new System.EventHandler(this.lvField_SelectedIndexChanged);
            // 
            // lblPicks
            // 
            this.lblPicks.AutoSize = true;
            this.lblPicks.Location = new System.Drawing.Point(48, 461);
            this.lblPicks.Name = "lblPicks";
            this.lblPicks.Size = new System.Drawing.Size(62, 18);
            this.lblPicks.TabIndex = 4;
            this.lblPicks.Text = "已選：";
            // 
            // numUnits
            // 
            this.numUnits.Location = new System.Drawing.Point(51, 506);
            this.numUnits.Name = "numUnits";
            this.numUnits.Size = new System.Drawing.Size(202, 29);
            this.numUnits.TabIndex = 5;
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(625, 588);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(216, 29);
            this.r.TabIndex = 7;
            this.r.Text = "取消此票";
            this.r.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(100, 687);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(406, 38);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "下注確定";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(625, 503);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(216, 29);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "加入投票";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSlips
            // 
            this.lstSlips.FormattingEnabled = true;
            this.lstSlips.ItemHeight = 18;
            this.lstSlips.Location = new System.Drawing.Point(46, 588);
            this.lstSlips.Name = "lstSlips";
            this.lstSlips.Size = new System.Drawing.Size(345, 40);
            this.lstSlips.TabIndex = 10;
            this.lstSlips.SelectedIndexChanged += new System.EventHandler(this.lstSlips_SelectedIndexChanged);
            // 
            // real_bet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1819, 818);
            this.Controls.Add(this.lstSlips);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.r);
            this.Controls.Add(this.numUnits);
            this.Controls.Add(this.lblPicks);
            this.Controls.Add(this.lvField);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.cmbTicket);
            this.Controls.Add(this.lblMoney);
            this.Name = "real_bet";
            this.Text = "real_bet";
            this.Load += new System.EventHandler(this.real_bet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.ComboBox cmbTicket;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ListView lvField;
        private System.Windows.Forms.Label lblPicks;
        private System.Windows.Forms.NumericUpDown numUnits;
        private System.Windows.Forms.Button r;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstSlips;
    }
}