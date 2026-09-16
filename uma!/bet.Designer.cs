namespace uma_
{
    partial class bet
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
            this.horse_card1 = new uma_.horse_card();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // horse_card1
            // 
            this.horse_card1.Location = new System.Drawing.Point(-824, -1);
            this.horse_card1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horse_card1.Name = "horse_card1";
            this.horse_card1.Size = new System.Drawing.Size(1339, 1180);
            this.horse_card1.TabIndex = 0;
            this.horse_card1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(279, 73);
            this.button1.TabIndex = 1;
            this.button1.Text = "顯示賽馬名單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 897);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(279, 73);
            this.button2.TabIndex = 2;
            this.button2.Text = "看完了";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::uma_.Properties.Resources.i_img1200x820_17680379191206uw951;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.horse_card1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "bet";
            this.Text = "bet";
            this.Load += new System.EventHandler(this.bet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private horse_card horse_card1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}