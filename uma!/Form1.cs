using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uma_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Image img = pictureBox1.Image;
            Rectangle destRect = pictureBox1.ClientRectangle;

            
            float imgRatio = (float)img.Width / img.Height;
            float boxRatio = (float)destRect.Width / destRect.Height;

            Rectangle srcRect;

            if (imgRatio > boxRatio)
            {
                
                int newWidth = (int)(img.Height * boxRatio);
                int x = (img.Width - newWidth) / 2;
                srcRect = new Rectangle(x, 0, newWidth, img.Height);
            }
            else
            {
                
                int newHeight = (int)(img.Width / boxRatio);
                int y = (img.Height - newHeight) / 2;
                srcRect = new Rectangle(0, y, img.Width, newHeight);
            }

            e.Graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            MessageBox.Show("本作品的時間線與現實並不同 請勿較真");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list list = new list();
            this.Hide();  //要用hideeeeeeee         
            list.ShowDialog();

        }
    }
}
    