namespace uma_
{
    partial class horse_card
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.back = new System.Windows.Forms.Button();
            this.go = new System.Windows.Forms.Button();
            this.uma_name = new System.Windows.Forms.Label();
            this.uma_st = new System.Windows.Forms.Label();
            this.pic_uma = new System.Windows.Forms.PictureBox();
            this.uma_sk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_uma)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(951, 624);
            this.back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(333, 50);
            this.back.TabIndex = 1;
            this.back.Text = "上面一位";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(951, 682);
            this.go.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(333, 56);
            this.go.TabIndex = 2;
            this.go.Text = "下面一位";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // uma_name
            // 
            this.uma_name.AutoSize = true;
            this.uma_name.Location = new System.Drawing.Point(1004, 470);
            this.uma_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uma_name.Name = "uma_name";
            this.uma_name.Size = new System.Drawing.Size(45, 18);
            this.uma_name.TabIndex = 3;
            this.uma_name.Text = "name";
            this.uma_name.Click += new System.EventHandler(this.uma_name_Click);
            // 
            // uma_st
            // 
            this.uma_st.AutoSize = true;
            this.uma_st.Location = new System.Drawing.Point(1004, 552);
            this.uma_st.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uma_st.Name = "uma_st";
            this.uma_st.Size = new System.Drawing.Size(44, 18);
            this.uma_st.TabIndex = 4;
            this.uma_st.Text = "數值";
            this.uma_st.Click += new System.EventHandler(this.uma_st_Click);
            // 
            // pic_uma
            // 
            this.pic_uma.Location = new System.Drawing.Point(1000, 27);
            this.pic_uma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pic_uma.Name = "pic_uma";
            this.pic_uma.Size = new System.Drawing.Size(238, 358);
            this.pic_uma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_uma.TabIndex = 0;
            this.pic_uma.TabStop = false;
            this.pic_uma.Click += new System.EventHandler(this.pic_uma_Click);
            // 
            // uma_sk
            // 
            this.uma_sk.AutoSize = true;
            this.uma_sk.Location = new System.Drawing.Point(999, 389);
            this.uma_sk.Name = "uma_sk";
            this.uma_sk.Size = new System.Drawing.Size(50, 18);
            this.uma_sk.TabIndex = 5;
            this.uma_sk.Text = "label1";
            this.uma_sk.Click += new System.EventHandler(this.uma_sk_Click);
            // 
            // horse_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uma_sk);
            this.Controls.Add(this.uma_st);
            this.Controls.Add(this.uma_name);
            this.Controls.Add(this.go);
            this.Controls.Add(this.back);
            this.Controls.Add(this.pic_uma);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "horse_card";
            this.Size = new System.Drawing.Size(2260, 1020);
            this.Load += new System.EventHandler(this.horse_card_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_uma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_uma;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Label uma_name;
        private System.Windows.Forms.Label uma_st;
        private System.Windows.Forms.Label uma_sk;
    }
}
