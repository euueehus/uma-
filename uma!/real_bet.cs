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
    public partial class real_bet : Form
    {
        public real_bet()
        {
            InitializeComponent();
        }
        public List<auto_uma.Horse> SelectedHorses { get; set; }
        public List<auto_uma.Horse> allHorses { get; set; }
        
        //| 單勝  | 単勝  | 選 1 匹，必須第 1           |
        //| 複勝  | 複勝  | 選 1 匹，進前 3（5～7 匹則前 2） |
        //| 馬連  | 馬連  | 選 2 匹，第 1、2 不問順序      |
        //| 馬單  | 馬単  | 選 2 匹，第 1、2 順序要對      |
        //| 寬連  | ワイド | 選 2 匹，都進前 3（不問順序）     |
        //| 三連複 | 三連複 | 選 3 匹，前 3 不問順序        |
        //| 三連單 | 三連単 | 選 3 匹，前 3 順序要對        |

        public enum JraTicket
        {
            Tansho,    // 單勝
            Fukusho,   // 複勝
            Umaren,    // 馬連
            Umataan,   // 馬單
            Wide,      // 寬連
            Trio,      // 三連複
            Trifecta   // 三連單
        }

        public class Ticket
        {
            public JraTicket Type;
            public List<auto_uma.Horse> Picks;  // 1～3 匹，馬單／三連單有順序
            public int Units;                   // 幾票
            public int Stake { get { return Units * 100; } }


        }
        void AssignNinki(List<auto_uma.Horse> field, Random rng)
        {
            // 名字熱門度（印象，不是能力）
            int Fame(string n)
            {
                switch (n)
                {
                    case "特別周":
                    case "魯道夫象徵":
                    case "小栗帽":
                    case "東海帝皇":
                    case "無聲鈴鹿":
                        return 3;
                    case "黃金船":
                    case "北部玄駒":
                    case "杏目":
                    case "目白麥昆":
                        return 2;
                    case "春烏拉拉":
                    case "優秀素質":
                    case "雪之美人":
                        return 0;
                    default:
                        return 1;
                }
            }

            var order = field.OrderByDescending(h => Fame(h.Name) * 10 + rng.Next(0, 8)).ToList();
            for (int i = 0; i < order.Count; i++)
                order[i].Ninki = i + 1;   // 1 = 最熱門
        }
        bool Hit(Ticket t, List<auto_uma.Horse> order)
        {
            var a = order[0];
            var b = order.Count > 1 ? order[1] : null;
            var c = order.Count > 2 ? order[2] : null;
            int n = order.Count;
            int placeOk = n >= 8 ? 3 : 2;   // 複勝：8 匹以上前三

            switch (t.Type)
            {
                case JraTicket.Tansho:
                    return t.Picks[0] == a;

                case JraTicket.Fukusho:
                    return order.Take(placeOk).Contains(t.Picks[0]);

                case JraTicket.Umaren:
                    return t.Picks.Contains(a) && t.Picks.Contains(b);

                case JraTicket.Umataan:
                    return t.Picks[0] == a && t.Picks[1] == b;

                case JraTicket.Wide:
                    return order.Take(3).Contains(t.Picks[0])
                        && order.Take(3).Contains(t.Picks[1]);

                case JraTicket.Trio:
                    return t.Picks.Contains(a) && t.Picks.Contains(b) && t.Picks.Contains(c);

                case JraTicket.Trifecta:
                    return t.Picks[0] == a && t.Picks[1] == b && t.Picks[2] == c;

                default:
                    return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int need = cmbTicket.SelectedIndex == 2 ? 2 : 1;
            if (picks.Count != need)
            {
                lblHint.Text = "先選滿 " + need + " 匹";
                return;
            }

            var t = new Ticket();
            t.Type = cmbTicket.SelectedIndex == 0 ? JraTicket.Tansho
                   : cmbTicket.SelectedIndex == 1 ? JraTicket.Fukusho
                   : JraTicket.Umaren;
            t.Picks = picks.ToList();
            t.Units = (int)numUnits.Value;
            if (t.Stake > Money)
            {
                lblHint.Text = "資金不足";
                return;
            }

            Money -= t.Stake;
            slips.Add(t);
            lstSlips.Items.Add(cmbTicket.Text + "  " + string.Join("・", t.Picks.Select(x => x.Name)) + "  ×" + t.Units);
            lblMoney.Text = "資金  " + Money;
            picks.Clear();
            lblPicks.Text = "已選：";
        }
        public int Money = 10000;
        private List<Ticket> slips = new List<Ticket>();
        private List<auto_uma.Horse> picks = new List<auto_uma.Horse>();

        private void real_bet_Load(object sender, EventArgs e)
        {
            cmbTicket.Items.Clear();
            cmbTicket.Items.Add("單勝");
            cmbTicket.Items.Add("複勝");
            cmbTicket.Items.Add("馬連");
            cmbTicket.SelectedIndex = 0;

            if (SelectedHorses == null || SelectedHorses.Count == 0)
            {
                lblHint.Text = "沒有出馬名單";
                return;
            }

            AssignNinki(SelectedHorses, new Random());

            lvField.Columns.Clear();
            lvField.Columns.Add("馬號", 50);
            lvField.Columns.Add("名字", 120);
            lvField.Columns.Add("人氣", 50);
            lvField.Columns.Add("單勝", 60);

            FillField();
            lblMoney.Text = "資金  " + Money;
        }

        private void FillField()
        {
            lvField.Items.Clear();
            int i = 1;
            foreach (var h in SelectedHorses)
            {
                var it = new ListViewItem(i.ToString());
                it.SubItems.Add(h.Name);
                it.SubItems.Add(h.Ninki.ToString());
                it.SubItems.Add(OddsTansho(h).ToString("0.0"));
                it.Tag = h;
                lvField.Items.Add(it);
                i++;
            }
        }

        private int FakeUnits(auto_uma.Horse h)
        {
            return 20 + (SelectedHorses.Count - h.Ninki) * 15;
        }

        private double OddsTansho(auto_uma.Horse h)
        {
            double pool = SelectedHorses.Sum(x => FakeUnits(x)) * 100.0;
            double hit = FakeUnits(h) * 100.0;
            double odds = pool * 0.80 / hit;
            if (odds < 1.5) odds = 1.5;
            return Math.Round(odds, 1);
        }
        private double PayOdds(Ticket t, List<auto_uma.Horse> order)
        {
            if (t.Type == JraTicket.Tansho)
                return OddsTansho(t.Picks[0]);

            if (t.Type == JraTicket.Fukusho)
            {
                double o = OddsTansho(t.Picks[0]) * 0.35;
                if (o < 1.3) o = 1.3;
                return Math.Round(o, 1);
            }

            int u = FakeUnits(t.Picks[0]) + FakeUnits(t.Picks[1]);
            double pool = SelectedHorses.Sum(h => FakeUnits(h)) * 80.0;
            double odds = pool * 0.80 / (u * 40.0);
            if (odds < 2.0) odds = 2.0;
            if (odds > 80) odds = 80;
            return Math.Round(odds, 1);
        }
        private void lvField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvField_ItemActivate(object sender, EventArgs e)
        {
            if (lvField.SelectedItems.Count == 0) return;
            var h = lvField.SelectedItems[0].Tag as auto_uma.Horse;
            if (h == null) return;

            int need = cmbTicket.SelectedIndex == 2 ? 2 : 1; // 0單勝 1複勝 2馬連
            if (picks.Contains(h)) return;
            if (picks.Count >= need) picks.Clear();
            picks.Add(h);
            lblPicks.Text = "已選：" + string.Join("、", picks.Select(x => x.Name));
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0)
            {
                lblHint.Text = "沒有出馬";
                return;
            }
            if (slips.Count == 0)
            {
                lblHint.Text = "先買至少一張";
                return;
            }

            var r = new race();
            r.SelectedHorses = SelectedHorses;
            r.allHorses = allHorses;
            this.Hide();
            r.ShowDialog();
            

            if (r.ResultOrder == null || r.ResultOrder.Count == 0)
            {
                lblHint.Text = "比賽沒有名次";
                return;
            }

            int gain = 0;
            foreach (var t in slips)
            {
                if (!Hit(t, r.ResultOrder)) continue;
                gain += (int)(t.Stake * PayOdds(t, r.ResultOrder));
            }

            Money += gain;
            lblMoney.Text = "資金  " + Money;

            
            var lines = new List<string>();
            foreach (var t in slips)
            {
                string name = string.Join("・", t.Picks.Select(x => x.Name));
                if (!Hit(t, r.ResultOrder))
                {
                    lines.Add(name + "  沒中");
                    continue;
                }
                int pay = (int)(t.Stake * PayOdds(t, r.ResultOrder));
                gain += pay;
                lines.Add(name + "  +" + pay);
            }

            Money += gain;
            lblMoney.Text = "資金  " + Money;

            var board = new last();
            board.ResultOrder = r.ResultOrder;
            board.Gain = gain;
            board.PayLines = lines;
            board.ShowDialog();

            slips.Clear();
            lstSlips.Items.Clear();

            slips.Clear();
            lstSlips.Items.Clear();
        }
        private void lstSlips_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
