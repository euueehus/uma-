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
    public partial class bet : Form
    {
        public bet()
        {
            InitializeComponent();
        }
        public List<auto_uma.Horse> SelectedHorses { get; set; }

        private void bet_Load(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0) return;

            horse_card1.SetHorses(SelectedHorses);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            horse_card1.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            horse_card1.Visible = false;
            button2.Visible = false;
            button1.Visible=true;
        }

        }
    }

