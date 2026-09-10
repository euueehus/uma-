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
            ((System.ComponentModel.ISupportInitialize)(this.pic_uma)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(634, 396);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(222, 33);
            this.back.TabIndex = 1;
            this.back.Text = "上面一位";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(634, 435);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(222, 37);
            this.go.TabIndex = 2;
            this.go.Text = "下面一位";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // uma_name
            // 
            this.uma_name.AutoSize = true;
            this.uma_name.Location = new System.Drawing.Point(669, 289);
            this.uma_name.Name = "uma_name";
            this.uma_name.Size = new System.Drawing.Size(30, 12);
            this.uma_name.TabIndex = 3;
            this.uma_name.Text = "name";
            this.uma_name.Click += new System.EventHandler(this.uma_name_Click);
            // 
            // uma_st
            // 
            this.uma_st.AutoSize = true;
            this.uma_st.Location = new System.Drawing.Point(669, 341);
            this.uma_st.Name = "uma_st";
            this.uma_st.Size = new System.Drawing.Size(29, 12);
            this.uma_st.TabIndex = 4;
            this.uma_st.Text = "數值";
            this.uma_st.Click += new System.EventHandler(this.uma_st_Click);
            // 
            // pic_uma
            // 
            this.pic_uma.Location = new System.Drawing.Point(667, 105);
            this.pic_uma.Name = "pic_uma";
            this.pic_uma.Size = new System.Drawing.Size(159, 152);
            this.pic_uma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_uma.TabIndex = 0;
            this.pic_uma.TabStop = false;
            this.pic_uma.Click += new System.EventHandler(this.pic_uma_Click);
            // 
            // horse_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uma_st);
            this.Controls.Add(this.uma_name);
            this.Controls.Add(this.go);
            this.Controls.Add(this.back);
            this.Controls.Add(this.pic_uma);
            this.Name = "horse_card";
            this.Size = new System.Drawing.Size(1507, 680);
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
    }
}
