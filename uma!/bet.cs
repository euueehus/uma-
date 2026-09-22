using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        public List<auto_uma.Horse> allHorses  { get; set; }
        
        private void bet_Load(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0) return;

            horse_card1.SetHorses(SelectedHorses);
            if (allHorses == null || allHorses.Count == 0)
                return;

        }
        private List<auto_uma.Horse> pick;

        private void PickTwo()
        {
            if (SelectedHorses == null || SelectedHorses.Count < 2)
                return;

            Random rand = new Random();
            pick = SelectedHorses
                .OrderBy(h => rand.Next())
                .Take(2)
                .ToList();

            auto_uma.Horse a = pick[0];
            auto_uma.Horse b = pick[1];

            label1.Text = a.Name;
            label2.Text = $"速度:{a.RaceSpeed}  耐力:{a.RaceStamina}  爆發:{a.RaceBurst}";

            label3.Text = b.Name;
            label4.Text = $"速度:{b.RaceSpeed}  耐力:{b.RaceStamina}  爆發:{b.RaceBurst}";
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
        

        private void button3_Click(object sender, EventArgs e)
        {

            
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            PickTwo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            real_bet real_bet = new real_bet();
            real_bet.SelectedHorses = SelectedHorses;
            real_bet.allHorses = allHorses;
            this.Hide();  //要用hideeeeeeee         
            real_bet.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            race race = new race();
            race.SelectedHorses = SelectedHorses;
            race.allHorses = allHorses;
            this.Hide();  //要用hideeeeeeee         
            race.ShowDialog();
            foreach (Form f in Application.OpenForms)
            {
                if (f is list)
                {
                    f.Show();
                    f.BringToFront();
                    return;
                }
            }
        }
    }
    }

