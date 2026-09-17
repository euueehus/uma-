using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace uma_
{
    public partial class race : Form
    {
        public race()
        {
            InitializeComponent();
        }
        public List<auto_uma.Horse> SelectedHorses { get; set; }
        public List<auto_uma.Horse> allHorses { get; set; }
        private void race_Load(object sender, EventArgs e)
        {

        }
        public   RaceSim sim;
        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0) return;

            sim = new RaceSim(SelectedHorses, 1600); // 東京英里當參考
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool done = sim.Tick();
            RefreshBoard();
            if (done) timer1.Stop();
        }
        private void RefreshBoard()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            int i = 1;
            foreach (var r in sim.Standings())
            {
                var item = new ListViewItem(i.ToString());
                item.SubItems.Add(r.Horse.Name);
                item.SubItems.Add(RaceSim.StyleText(r.Style));
                item.SubItems.Add(r.Position.ToString("0"));
                item.SubItems.Add(r.Speed.ToString("0.0"));
                item.SubItems.Add(r.Hp.ToString("0"));
                listView1.Items.Add(item);
                i++;
            }

            listView1.EndUpdate();
            this.Text = "比賽  " + sim.Time.ToString("0.0") + " 秒";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
