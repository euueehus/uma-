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
    public partial class auto_uma : Form
    {
        
        private List<Horse> selectedHorses = new List<Horse>();

        public auto_uma()
        {
            InitializeComponent();
        }

        public class Horse
        {
            public string Name;
            public int Speed;
            public int Stamina;
            public int Burst;
            public int Luck;

            public Horse(string name, int speed, int stamina, int burst, int luck)
            {
                Name = name;
                Speed = speed;
                Stamina = stamina;
                Burst = burst;
                Luck = luck;
            }
        }

        List<Horse> allHorses = new List<Horse>()
        {
            new Horse("特別周", 88, 85, 82, 80),
            new Horse("無聲鈴鹿", 95, 70, 90, 75),
            new Horse("東海帝皇", 92, 78, 95, 85),
            new Horse("小栗帽", 90, 88, 85, 82),
            new Horse("黃金船", 78, 92, 88, 90),
            new Horse("米浴", 75, 90, 70, 70),
            new Horse("伏特加", 91, 76, 93, 78),
            new Horse("大和赤驥", 89, 80, 91, 80),
            new Horse("草上飛", 86, 89, 80, 88),
            new Horse("神鷹", 93, 75, 89, 76),
            new Horse("氣槽", 84, 87, 78, 83),
            new Horse("北部玄駒", 87, 93, 84, 85),
            new Horse("目白麥昆", 82, 95, 75, 79),
            new Horse("帝王光環", 90, 88, 86, 87),
            new Horse("成田白仁", 94, 82, 92, 74),
            new Horse("美浦波旁", 88, 84, 87, 81),
            new Horse("春烏拉拉", 55, 60, 50, 95),
            new Horse("優秀素質", 72, 85, 68, 86),
            new Horse("曼城茶座", 80, 91, 72, 72),
            new Horse("里見光鑽", 85, 90, 80, 84),
            new Horse("醒目飛鷹", 83, 70, 95, 77),
            new Horse("丸善斯基", 96, 72, 94, 80),
            new Horse("菱亞馬遜", 86, 86, 83, 82),
            new Horse("超級小溪", 79, 94, 76, 78),
            new Horse("萊茵實力", 81, 88, 79, 85),
            new Horse("待兼福來", 70, 78, 88, 92),
            new Horse("微光飛駒", 94, 68, 96, 75),
            new Horse("愛麗速子", 92, 75, 97, 70),
            new Horse("青雲天空", 77, 92, 70, 88),
            new Horse("玉藻十字", 85, 83, 81, 83),
            new Horse("魯道夫象徵", 91, 89, 84, 82),
            new Horse("成田大進", 86, 80, 88, 79),
            new Horse("愛慕織姬", 84, 82, 90, 81),
            new Horse("雪之美人", 78, 85, 76, 88),
            new Horse("青竹回憶", 89, 74, 92, 77),
            new Horse("勝利獎券", 83, 87, 80, 84),
            new Horse("目白善信", 80, 86, 79, 85),
            new Horse("菱曙", 76, 90, 75, 83),
            new Horse("真機伶", 87, 78, 91, 80),
            new Horse("富士奇蹟", 90, 84, 86, 82),
            new Horse("大鳴大放", 89, 86, 88, 84),
        };

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int uma_count_value = rand.Next(5, 18);   

            selectedHorses = allHorses.OrderBy(x => rand.Next()).Take(uma_count_value).ToList();

            label2.Text = string.Join("\n", selectedHorses.Select(h => h.Name));
            label2.Visible = true;
            
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            show showForm = new show();
            showForm.SelectedHorses = selectedHorses;   
            this.Hide();
            showForm.ShowDialog();
        }
    }
}