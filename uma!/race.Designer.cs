namespace uma_
{
    partial class race
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnX1 = new System.Windows.Forms.Button();
            this.btnX4 = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(626, 166);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 59);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(599, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(602, 373);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(599, 636);
            this.txtReport.Margin = new System.Windows.Forms.Padding(2);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(613, 177);
            this.txtReport.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTitle.Location = new System.Drawing.Point(613, 140);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(45, 16);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "label1";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTime.Location = new System.Drawing.Point(1058, 140);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(45, 16);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "label1";
            // 
            // btnX1
            // 
            this.btnX1.Location = new System.Drawing.Point(774, 166);
            this.btnX1.Name = "btnX1";
            this.btnX1.Size = new System.Drawing.Size(85, 59);
            this.btnX1.TabIndex = 6;
            this.btnX1.Text = "1 倍速";
            this.btnX1.UseVisualStyleBackColor = true;
            this.btnX1.Click += new System.EventHandler(this.btnX1_Click_1);
            // 
            // btnX4
            // 
            this.btnX4.Location = new System.Drawing.Point(945, 166);
            this.btnX4.Name = "btnX4";
            this.btnX4.Size = new System.Drawing.Size(85, 59);
            this.btnX4.TabIndex = 7;
            this.btnX4.Text = "4 倍速";
            this.btnX4.UseVisualStyleBackColor = true;
            this.btnX4.Click += new System.EventHandler(this.btnX4_Click_1);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(1098, 166);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(85, 59);
            this.btnResult.TabIndex = 8;
            this.btnResult.Text = "成績";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // race
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::uma_.Properties.Resources.東京競馬場___panoramio__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1819, 847);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnX4);
            this.Controls.Add(this.btnX1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnStart);
            this.Name = "race";
            this.Load += new System.EventHandler(this.race_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnX1;
        private System.Windows.Forms.Button btnX4;
        private System.Windows.Forms.Button btnResult;
    }
}