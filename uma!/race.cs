using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace uma_
{
    public partial class race : Form
    {
        public List<auto_uma.Horse> SelectedHorses { get; set; }
        public List<auto_uma.Horse> allHorses { get; set; }
        public List<auto_uma.Horse> ResultOrder { get; set; }
        public List<real_bet.Ticket> Slips { get; set; }
        public int Gain { get; set; }
        public List<string> PayLines { get; set; }

        public RaceSim sim;

        
        private bool reportedMid;
        private bool reportedLate;
        private bool reportedLast200;
        private HashSet<string> stalled = new HashSet<string>();
        private HashSet<string> finishedNames = new HashSet<string>();
        private Dictionary<string, int> lastRank = new Dictionary<string, int>();
        private string lastLeader;
        
        private bool reportedStretch;
        
        private double lastTalkTime;

        private double lastOvertakeTime;

        public race()
        {
            InitializeComponent();
        }

        private void race_Load(object sender, EventArgs e)
        {
            SetupBoard();
            if (lblTitle != null) lblTitle.Text = "東京競馬場　草地　1600m　右";
            if (lblTime != null) lblTime.Text = "0.0\"";
            if (txtReport != null)
            {
                txtReport.ReadOnly = true;
                txtReport.ScrollBars = ScrollBars.Vertical;
            }
            timer1.Interval = 50;
            btnResult.Enabled = false;
        }

        private void SetupBoard()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = false;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.OwnerDraw = false;
            listView1.Columns.Clear();
            listView1.Columns.Add("", 44);
            listView1.Columns.Add("", 150);
            listView1.Columns.Add("", 56);
            listView1.Columns.Add("", 100);
            listView1.Columns.Add("", 72);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (SelectedHorses == null || SelectedHorses.Count == 0)
            {
                MessageBox.Show("沒有這一場的馬。開 race 前請設定 SelectedHorses。");
                return;
            }

            lastLeader = null;
            reportedMid = reportedLate = reportedLast200 = reportedStretch = false;
            stalled.Clear();
            finishedNames.Clear();
            lastRank.Clear();
            lastTalkTime = -10;
            if (txtReport != null) txtReport.Clear();
            sim = new RaceSim(SelectedHorses, 1600);
            Report("起跑了");
            Report("各個賽馬娘都為了比賽帶來了漂亮的開場呢");
            RefreshBoard();

            timer1.Interval = 50;
            timer1.Start();
        }

        private void btnX1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void btnX4_Click(object sender, EventArgs e)
        {
            timer1.Interval = 12;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sim == null) return;

            bool done = sim.Tick();
            CheckEvents();
            RefreshBoard();

            if (done)
            {
                timer1.Stop();
               
                ResultOrder = sim.Standings().Select(x => x.Horse).ToList();
                var win = sim.Standings()[0];
                Report(win.Horse.Name + " 抵達終點！");
                if (btnResult != null) btnResult.Enabled = true;

            }
        }

        private void RefreshBoard()
        {
            if (sim == null) return;
            if (listView1.Columns.Count != 5) SetupBoard();

            var board = sim.Standings();
            double lead = board.Count == 0 ? 0 : board[0].Position;

            listView1.BeginUpdate();
            listView1.Items.Clear();

            int i = 1;
            foreach (var r in board)
            {
                string gap;
                if (r.Finished)
                {
                    gap = "GOAL";
                }
                else if (i == 1)
                {
                    gap = "先頭";
                }
                else
                {
                    double meters = lead - r.Position;
                    if (meters < 0) meters = 0;
                    double len = meters / 2.5;

                    if (len < 0.2) gap = "接頭";
                    else if (len > 30) gap = "大差";
                    else gap = len.ToString("0.1") + "馬身";
                }

                string state;
                if (r.Finished) state = "GOAL";
                else if (r.Hp <= 0) state = "失速";
                else if (r.Position >= sim.Distance * 2.0 / 3.0) state = "終盤";
                else if (r.Position < sim.Distance / 6.0) state = "序盤";
                else state = "中盤";

                var item = new ListViewItem(ToRoman(i));
                item.SubItems.Add(r.Horse.Name);
                item.SubItems.Add(RaceSim.StyleText(r.Style));
                item.SubItems.Add(gap);
                item.SubItems.Add(state);

                if (i == 1) item.ForeColor = Color.FromArgb(180, 40, 40);
                else if (r.Hp <= 0) item.ForeColor = Color.Gray;
                else if (r.Finished) item.ForeColor = Color.FromArgb(20, 120, 60);

                listView1.Items.Add(item);
                i++;
            }

            listView1.EndUpdate();
            SetTimeText(sim.Time.ToString("0.0") + "\"");
        }

        private void CheckEvents()
        {
            if (sim == null) return;

            if (sim.SkillLog != null && sim.SkillLog.Count > 0)
            {
                foreach (var line in sim.SkillLog)
                    Report(line);
                sim.SkillLog.Clear();
            }

            var board = sim.Standings();
            if (board.Count == 0) return;

            double dist = sim.Distance;
            var lead = board[0];
            string leader = lead.Horse.Name;

            if (!reportedMid && lead.Position >= dist / 6.0)
            {
                reportedMid = true;
                Report("位子的爭奪看起來相當的激烈呢");
                Report("好，通過序盤。領先眾人的是" + leader + "她可以繼續保持這個優勢嗎?");
            }

            if (!reportedLate && lead.Position >= dist * 2.0 / 3.0)
            {
                reportedLate = true;
                Report("");
            }

            if (!reportedLast200 && lead.Position >= dist - 200)
            {
                reportedLast200 = true;
                Report("只剩下兩百公尺!");

            }

            if (!reportedStretch && lead.Position >= dist - 80)
            {
                reportedStretch = true;
                Report("最終直線——看誰先伸頭！");
                Report(leader + "腳程不見疲態");
            }

            if (lastLeader != null && lastLeader != leader && CanTalk(1.2))
            {
                var old = board.FirstOrDefault(x => x.Horse.Name == lastLeader);
                string extra = "";
                if (old != null)
                {
                    double len = (lead.Position - old.Position) / 2.5;
                    if (len >= 0.4) extra = "拉開" + len.ToString("0.1") + "馬身。";
                }
                Report(leader + " 超上了" + lastLeader + "！" + extra);
            }
            lastLeader = leader;

            if (board.Count >= 2 && CanTalk(3.0))
            {
                double toSecond = (board[0].Position - board[1].Position) / 2.5;
                if (toSecond < 0.35)
                    Report(board[1].Horse.Name + " 咬住先頭" + leader + "！");
               
                

            }

            for (int i = 0; i < board.Count; i++)
            {
                var r = board[i];
                string name = r.Horse.Name;
                int rank = i + 1;

                if (r.Hp <= 0 && stalled.Add(name))
                    Report(name + " 失速了……腳步重了。");

                if (r.Finished && finishedNames.Add(name))
                {
                    if (rank == 1) Report(name + "、率先衝線！！");
                    else if (rank == 2) Report(name + " 第二個抵達。");
                    else if (rank == 3) Report(name + " 第三個抵達。");
                    else Report(name + " 第" + rank + "個通過終點。");
                }

                int prev;
                if (lastRank.TryGetValue(name, out prev) && prev - rank >= 2 && CanTalk(1.8))
                    Report(name + " 一口氣超了" + (prev - rank) + "匹！");
                lastRank[name] = rank;
            }
        }

        private bool CanTalk(double gap)
        {
            if (sim.Time - lastTalkTime < gap) return false;
            lastTalkTime = sim.Time;
            return true;
        }

        private void Report(string line)
        {
            if (txtReport == null) return;
            string t = sim == null ? "0.0" : sim.Time.ToString("0.0");
            txtReport.AppendText(t + "\"  " + line + Environment.NewLine);
            txtReport.SelectionStart = txtReport.Text.Length;
            txtReport.ScrollToCaret();
        }

        private void SetTimeText(string s)
        {
            if (lblTime != null) lblTime.Text = s;
            else this.Text = s;
        }

        private static string ToRoman(int n)
        {
            string[] r =
            {
                "Ⅰ","Ⅱ","Ⅲ","Ⅳ","Ⅴ","Ⅵ","Ⅶ","Ⅷ","Ⅸ","Ⅹ",
                "Ⅺ","Ⅻ","13","14","15","16","17","18"
            };
            return (n >= 1 && n <= r.Length) ? r[n - 1] : n.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnX4_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 12;
        }

        private void btnX1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {

            last lastForm = new last();
            this.Close();
        }
    }
}