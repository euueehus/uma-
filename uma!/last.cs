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
    public partial class last : Form
    {
        public List<auto_uma.Horse> ResultOrder { get; set; }
        public int Gain { get; set; }
        public List<string> PayLines { get; set; }

        public last()
        {
            InitializeComponent();
        }

       

        
        private void lvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void last_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lvResult.View = View.Details;
            lvResult.FullRowSelect = true;
            if (lvResult.Columns.Count == 0)
            {
                lvResult.Columns.Add("名次", 50);
                lvResult.Columns.Add("名字", 140);
            }

            lvResult.Items.Clear();
            if (ResultOrder != null)
            {
                int i = 1;
                foreach (var h in ResultOrder)
                {
                    var it = new ListViewItem(i.ToString());
                    it.SubItems.Add(h.Name);
                    lvResult.Items.Add(it);
                    i++;
                }
            }

            lstPay.Items.Clear();
            if (PayLines != null)
                foreach (var s in PayLines)
                    lstPay.Items.Add(s);

            lblGain.Text = Gain > 0 ? "派彩 +" + Gain : "沒中  +0";
        }

        private void lstPay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

