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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.horse_card1 = new uma_.horse_card();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(1117, 273);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(65, 12);
            this.lblMoney.TabIndex = 0;
            this.lblMoney.Text = "資金  10000";
            // 
            // cmbTicket
            // 
            this.cmbTicket.FormattingEnabled = true;
            this.cmbTicket.Location = new System.Drawing.Point(693, 351);
            this.cmbTicket.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTicket.Name = "cmbTicket";
            this.cmbTicket.Size = new System.Drawing.Size(435, 20);
            this.cmbTicket.TabIndex = 1;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(1157, 351);
            this.lblHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(65, 12);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "請點選 1 匹";
            // 
            // lvField
            // 
            this.lvField.HideSelection = false;
            this.lvField.Location = new System.Drawing.Point(693, 372);
            this.lvField.Margin = new System.Windows.Forms.Padding(2);
            this.lvField.Name = "lvField";
            this.lvField.Size = new System.Drawing.Size(432, 155);
            this.lvField.TabIndex = 3;
            this.lvField.UseCompatibleStateImageBehavior = false;
            this.lvField.ItemActivate += new System.EventHandler(this.lvField_ItemActivate);
            this.lvField.SelectedIndexChanged += new System.EventHandler(this.lvField_SelectedIndexChanged);
            // 
            // lblPicks
            // 
            this.lblPicks.AutoSize = true;
            this.lblPicks.Location = new System.Drawing.Point(694, 531);
            this.lblPicks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPicks.Name = "lblPicks";
            this.lblPicks.Size = new System.Drawing.Size(41, 12);
            this.lblPicks.TabIndex = 4;
            this.lblPicks.Text = "已選：";
            // 
            // numUnits
            // 
            this.numUnits.Location = new System.Drawing.Point(696, 561);
            this.numUnits.Margin = new System.Windows.Forms.Padding(2);
            this.numUnits.Name = "numUnits";
            this.numUnits.Size = new System.Drawing.Size(135, 22);
            this.numUnits.TabIndex = 5;
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(1079, 616);
            this.r.Margin = new System.Windows.Forms.Padding(2);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(144, 19);
            this.r.TabIndex = 7;
            this.r.Text = "取消此票";
            this.r.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(729, 682);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(271, 25);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "下注確定";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1079, 559);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 19);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "加入投票";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSlips
            // 
            this.lstSlips.FormattingEnabled = true;
            this.lstSlips.ItemHeight = 12;
            this.lstSlips.Location = new System.Drawing.Point(693, 616);
            this.lstSlips.Margin = new System.Windows.Forms.Padding(2);
            this.lstSlips.Name = "lstSlips";
            this.lstSlips.Size = new System.Drawing.Size(231, 28);
            this.lstSlips.TabIndex = 10;
            this.lstSlips.SelectedIndexChanged += new System.EventHandler(this.lstSlips_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 69);
            this.button1.TabIndex = 12;
            this.button1.Text = "顯示賽馬名單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 763);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(273, 69);
            this.button2.TabIndex = 13;
            this.button2.Text = "看完!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // horse_card1
            // 
            this.horse_card1.Location = new System.Drawing.Point(-531, 3);
            this.horse_card1.Name = "horse_card1";
            this.horse_card1.Size = new System.Drawing.Size(1116, 977);
            this.horse_card1.TabIndex = 11;
            this.horse_card1.Visible = false;
            this.horse_card1.Load += new System.EventHandler(this.horse_card1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(1325, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // real_bet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::uma_.Properties.Resources._727519527_1530810065338729_8497146049453339656_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1805, 844);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.horse_card1);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "real_bet";
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
        private horse_card horse_card1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}