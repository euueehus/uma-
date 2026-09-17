namespace uma_
{
    partial class show
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
            this.button1 = new System.Windows.Forms.Button();
            this.horse_card1 = new horse_card();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(941, -30);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(737, 122);
            this.button1.TabIndex = 1;
            this.button1.Text = "前往查看今日下注及場地狀態預估";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // horse_card1
            // 
            this.horse_card1.Location = new System.Drawing.Point(-519, -30);
            this.horse_card1.Margin = new System.Windows.Forms.Padding(6);
            this.horse_card1.Name = "horse_card1";
            this.horse_card1.Size = new System.Drawing.Size(1423, 960);
            this.horse_card1.TabIndex = 0;
            // 
            // show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::uma_.Properties.Resources.oguri_cap_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1855, 837);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.horse_card1);
            this.Name = "show";
            this.Text = "show";
            this.Load += new System.EventHandler(this.show_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private horse_card horse_card1;
        private System.Windows.Forms.Button button1;
    }
}