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

        public RaceSim sim;

        
        private bool reportedMid;
        private bool reportedLate;
        private bool reportedLast200;
        private HashSet<string> stalled = new HashSet<string>();
        private HashSet<string> finishedNames = new HashSet<string>();
        private Dictionary<string, int> lastRank = new Dictionary<string, int>();
        private string lastLeader;
        
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
            reportedLate = false;
            reportedMid = false;
            stalled.Clear();
            finishedNames.Clear();
            if (txtReport != null) txtReport.Clear();

            sim = new RaceSim(SelectedHorses, 1600);
            Report("出閘！");
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
                var win = sim.Standings()[0];
                Report(win.Horse.Name + " 抵達終點！");
                SetTimeText(sim.Time.ToString("0.0") + "\"  完賽");
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
            var board = sim.Standings();
            if (board.Count == 0) return;

            double dist = sim.Distance;
            var lead = board[0];

            if (!reportedMid && lead.Position >= dist / 6.0)
            {
                reportedMid = true;
                Report("通過序盤，進入中盤。先頭是" + lead.Horse.Name + "。");
            }

            if (!reportedLate && lead.Position >= dist * 2.0 / 3.0)
            {
                reportedLate = true;
                Report("終盤戰開始！");
            }

            if (!reportedLast200 && lead.Position >= dist - 200)
            {
                reportedLast200 = true;
                Report("剩下兩百公尺！");
            }

            string leader = lead.Horse.Name;
            if (lastLeader != null && lastLeader != leader)
            {
                double gap = 0;
                var old = board.FirstOrDefault(x => x.Horse.Name == lastLeader);
                if (old != null) gap = (lead.Position - old.Position) / 2.5;
                Report(leader + " 超上了 " + lastLeader + "！"
                     + (gap >= 0.3 ? "領先" + gap.ToString("0.1") + "馬身。" : ""));
            }
            lastLeader = leader;

            if (board.Count >= 2)
            {
                double toSecond = (board[0].Position - board[1].Position) / 2.5;
                if (toSecond < 0.3 && sim.Time - lastOvertakeTime > 3)
                {
                    lastOvertakeTime = sim.Time;
                    Report(board[1].Horse.Name + " 咬住先頭" + lead.Horse.Name + "！");
                }
            }

            for (int i = 0; i < board.Count; i++)
            {
                var r = board[i];
                string name = r.Horse.Name;
                int rank = i + 1;

                if (r.Hp <= 0 && stalled.Add(name))
                    Report(name + " 失速了……");

                if (r.Finished && finishedNames.Add(name))
                {
                    if (rank == 1) Report(name + "、第一個衝線！");
                    else Report(name + " 第" + rank + "個抵達。");
                }

                int prev;
                if (lastRank.TryGetValue(name, out prev))
                {
                    if (prev - rank >= 2 && sim.Time - lastOvertakeTime > 1.5)
                    {
                        lastOvertakeTime = sim.Time;
                        Report(name + " 一口氣超了" + (prev - rank) + "匹！");
                    }
                }
                lastRank[name] = rank;
            }
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
    }
}