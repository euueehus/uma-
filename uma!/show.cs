using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace uma_
{
    public partial class show : Form
    {
        public List<auto_uma.Horse> SelectedHorses { get; set; }

        public show()
        {
            InitializeComponent();
        }

        private void show_Load(object sender, EventArgs e)
        {
            
            PictureBox[] picBoxes = new PictureBox[]
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                pictureBox16, pictureBox17, pictureBox18
            };

            
            Label[] labels = new Label[]
            {
                label1, label2, label3, label4, label5,
                label6, label7, label8, label9, label10,
                label11, label12, label13, label14, label15,
                label16, label17, label18
            };

            
            for (int i = 0; i < 18; i++)
            {
                picBoxes[i].Visible = false;
                labels[i].Visible = false;
                picBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                picBoxes[i].Image = null;
                labels[i].Text = "";
            }

            if (SelectedHorses == null || SelectedHorses.Count == 0)
                return;

            
            for (int i = 0; i < SelectedHorses.Count && i < 18; i++)
            {
                var horse = SelectedHorses[i];

                labels[i].Text = horse.Name;
                labels[i].Visible = true;

                picBoxes[i].Image = GetHorseImage(horse.Name);
                picBoxes[i].Visible = true;
            }
        }

        private Image GetHorseImage(string name)
        {
            try
            {
                
                string imagePath = Path.Combine(Application.StartupPath, "Images", name + ".png");

                if (File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }
                else
                {
                    
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }
    }
}