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
            


        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void show_Load_1(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0) return;

            horse_card1.SetHorses(SelectedHorses);   
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}