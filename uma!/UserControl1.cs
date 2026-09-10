using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uma_
{
    public partial class horse_card : UserControl
    {
        private List<auto_uma.Horse> horses;
        private int currentIndex = 0;

        public horse_card()
        {
            InitializeComponent();
        }

        public void SetHorses(List<auto_uma.Horse> selectedHorses)
        {
            horses = selectedHorses;
            currentIndex = 0;
            ShowCurrentHorse();
        }

      
        private void ShowCurrentHorse()
        {
            if (horses == null || horses.Count == 0) return;

            var horse = horses[currentIndex];

            
            this.uma_name.Text = horse.Name;

           
            this.uma_st.Text = $"速度:{horse.Speed}  耐力:{horse.Stamina}\n爆發:{horse.Burst}  幸運:{horse.Luck}";


            string pathPng = Path.Combine(Application.StartupPath, "Resources", "Images", horse.Name + ".png");
            string pathJpg = Path.Combine(Application.StartupPath, "Resources", "Images", horse.Name + ".jpg");

           
            

            if (File.Exists(pathPng))
                this.pic_uma.Image = Image.FromFile(pathPng);
            else if (File.Exists(pathJpg))
                this.pic_uma.Image = Image.FromFile(pathJpg);
            else
                this.pic_uma.Image = null;

            this.pic_uma.SizeMode = PictureBoxSizeMode.Zoom;
        }

   
        private void back_Click(object sender, EventArgs e)
        {
            if (horses == null || horses.Count == 0) return;

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = horses.Count - 1;

            ShowCurrentHorse();
        }

        // 下面一位
        private void go_Click(object sender, EventArgs e)
        {
            if (horses == null || horses.Count == 0) return;

            currentIndex++;
            if (currentIndex >= horses.Count)
                currentIndex = 0;

            ShowCurrentHorse();
        }

        private void pic_uma_Click(object sender, EventArgs e)
        {

        }

        private void uma_name_Click(object sender, EventArgs e)
        {

        }

        private void uma_st_Click(object sender, EventArgs e)
        {

        }

        private void horse_card_Load(object sender, EventArgs e)
        {

        }
    }
}