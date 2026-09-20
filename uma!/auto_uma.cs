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
            public System.Collections.Generic.List<UmaSkill> Skills =
            new System.Collections.Generic.List<UmaSkill>();

            public int RaceSpeed;
            public int RaceStamina;
            public int RaceBurst;
            public UmaForm Form;

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
            new Horse("杏目", 94, 88, 96, 86),
        };

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int uma_count_value = rand.Next(5, 18);   

            selectedHorses = allHorses.OrderBy(x => rand.Next()).Take(uma_count_value).ToList();
            RollRaceStats(selectedHorses);
            label2.Text = string.Join("\n", selectedHorses.Select(h => h.Name));
            label2.Visible = true;
            
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            show showForm = new show();
            showForm.SelectedHorses = selectedHorses;
            showForm.allHorses = allHorses;

            this.Hide();
            showForm.ShowDialog();
        }
        public enum UmaForm
        {
            Slump,   // 不調
            Normal,  // 普通
            Good,    // 好調
            Peak     // 絶好調
        }

        // 權重：數字愈大愈容易抽到
        private UmaForm RollForm(Random rand, int luck)
        {
            int luckBonus = Math.Max(0, luck - 70);   // 70 當「普通運」，再高的才加分

            int slumpW = Math.Max(4, 22 - luckBonus / 2);  // 運好 → 不調變少
            int normalW = 34;
            int goodW = 28 + luckBonus / 3;
            int peakW = 8 + luckBonus / 2;               // 運好 → 絶好調變多

            int total = slumpW + normalW + goodW + peakW;
            int roll = rand.Next(1, total + 1);             // 1 ~ total（含）

            if (roll <= slumpW) return UmaForm.Slump;
            roll -= slumpW;
            if (roll <= normalW) return UmaForm.Normal;
            roll -= normalW;
            if (roll <= goodW) return UmaForm.Good;
            return UmaForm.Peak;
        }

        private void GetFormOffset(UmaForm form, out int minOff, out int maxOff)
        {
            switch (form)
            {
                case UmaForm.Slump:
                    minOff = -16; maxOff = 1;
                    break;
                case UmaForm.Normal:
                    minOff = -5; maxOff = 6;
                    break;
                case UmaForm.Good:
                    minOff = 3; maxOff = 12;
                    break;
                default: 
                    minOff = 10; maxOff = 20;
                    break;
            }
        }

        private int RollStat(Random rand, int baseValue, UmaForm form)
        {
            int minOff, maxOff;
            GetFormOffset(form, out minOff, out maxOff);

            int formRoll = rand.Next(minOff, maxOff + 1);  // 狀態帶來的大方向
            int noise = rand.Next(-3, 4);                  // 這一圍自己的小波動 -3~+3

            int value = baseValue + formRoll + noise;

            if (value < 40) value = 40;
            if (value > 120) value = 120;
            return value;
        }

        private void RollRaceStats(List<Horse> raceHorses)
        {
            Random rand = new Random();  

            foreach (Horse horse in raceHorses)
            {
                horse.Form = RollForm(rand, horse.Luck);

                horse.RaceSpeed = RollStat(rand, horse.Speed, horse.Form);
                horse.RaceStamina = RollStat(rand, horse.Stamina, horse.Form);
                horse.RaceBurst = RollStat(rand, horse.Burst, horse.Form);
            }
        }
        private void AttachSkills()
        {
            foreach (var h in allHorses)
                GiveSkills(h);
        }

        private void GiveSkills(Horse h)
        {
            h.Skills.Clear();

            switch (h.Name)
            {
                case "特別周":
                    h.Skills.Add(new UmaSkill("流星衝刺", SkillWhen.Late, SkillWhat.Accel, 0.30, 4));
                    break;
                case "無聲鈴鹿":
                    h.Skills.Add(new UmaSkill("前方的風景絕不讓出", SkillWhen.Early, SkillWhat.TargetUp, 0.035, 6));
                    break;
                case "東海帝皇":
                    h.Skills.Add(new UmaSkill("帝王舞步", SkillWhen.Last200, SkillWhat.Accel, 0.36, 3));
                    break;
                case "小栗帽":
                    h.Skills.Add(new UmaSkill("不屈之心", SkillWhen.Late, SkillWhat.TargetUp, 0.038, 4));
                    break;
                case "黃金船":
                    h.Skills.Add(new UmaSkill("往痛處招呼", SkillWhen.Last200, SkillWhat.Accel, 0.40, 3));
                    break;
                case "米浴":
                    h.Skills.Add(new UmaSkill("藍薔薇", SkillWhen.Mid, SkillWhat.Heal, 16, 0));
                    break;
                case "伏特加":
                    h.Skills.Add(new UmaSkill("紅移", SkillWhen.Late, SkillWhat.TargetUp, 0.036, 4));
                    break;
                case "大和赤驥":
                    h.Skills.Add(new UmaSkill("紅色王牌", SkillWhen.Late, SkillWhat.TargetUp, 0.034, 4));
                    break;
                case "草上飛":
                    h.Skills.Add(new UmaSkill("貴顯的使命", SkillWhen.Late, SkillWhat.TargetUp, 0.033, 4));
                    break;
                case "神鷹":
                    h.Skills.Add(new UmaSkill("El Número 1", SkillWhen.Mid, SkillWhat.Accel, 0.28, 3));
                    break;
                case "氣槽":
                    h.Skills.Add(new UmaSkill("女帝的氣場", SkillWhen.Late, SkillWhat.TargetUp, 0.034, 4));
                    break;
                case "北部玄駒":
                    h.Skills.Add(new UmaSkill("沒有秘密", SkillWhen.Late, SkillWhat.TargetUp, 0.036, 4));
                    break;
                case "目白麥昆":
                    h.Skills.Add(new UmaSkill("高貴的使命", SkillWhen.Late, SkillWhat.TargetUp, 0.038, 4));
                    break;
                case "帝王光環":
                    h.Skills.Add(new UmaSkill("Pride of King", SkillWhen.Last200, SkillWhat.TargetUp, 0.04, 4));
                    break;
                case "成田白仁":
                    h.Skills.Add(new UmaSkill("Shadow Break", SkillWhen.Late, SkillWhat.Accel, 0.34, 3));
                    break;
                case "美浦波旁":
                    h.Skills.Add(new UmaSkill("G00 1st.F∞", SkillWhen.Last200, SkillWhat.TargetUp, 0.04, 4));
                    break;
                case "春烏拉拉":
                    h.Skills.Add(new UmaSkill("好厲害好厲害！", SkillWhen.Mid, SkillWhat.Heal, 20, 0));
                    break;
                case "優秀素質":
                    h.Skills.Add(new UmaSkill("略顯平凡的我", SkillWhen.Mid, SkillWhat.Heal, 14, 0));
                    break;
                case "曼城茶座":
                    h.Skills.Add(new UmaSkill("non-disclosure", SkillWhen.Mid, SkillWhat.TargetUp, 0.03, 4));
                    break;
                case "里見光鑽":
                    h.Skills.Add(new UmaSkill("賭上最強之名", SkillWhen.Last200, SkillWhat.TargetUp, 0.04, 4));
                    break;
                case "醒目飛鷹":
                    h.Skills.Add(new UmaSkill("キラキラ☆STARDOM", SkillWhen.Mid, SkillWhat.Accel, 0.30, 3));
                    break;
                case "丸善斯基":
                    h.Skills.Add(new UmaSkill("白色閃電給你看", SkillWhen.Early, SkillWhat.TargetUp, 0.035, 5));
                    break;
                case "菱亞馬遜":
                    h.Skills.Add(new UmaSkill("亞馬遜精神", SkillWhen.Late, SkillWhat.Accel, 0.28, 3));
                    break;
                case "超級小溪":
                    h.Skills.Add(new UmaSkill("清澈奔流", SkillWhen.Mid, SkillWhat.Heal, 15, 0));
                    break;
                case "萊茵實力":
                    h.Skills.Add(new UmaSkill("Fairy tale", SkillWhen.Late, SkillWhat.TargetUp, 0.032, 4));
                    break;
                case "待兼福來":
                    h.Skills.Add(new UmaSkill("幸運之星", SkillWhen.Mid, SkillWhat.Heal, 20, 0));
                    break;
                case "微光飛駒":
                    h.Skills.Add(new UmaSkill("燈火燦爛", SkillWhen.Early, SkillWhat.Accel, 0.30, 3));
                    break;
                case "愛麗速子":
                    h.Skills.Add(new UmaSkill("U=ma²", SkillWhen.Late, SkillWhat.TargetUp, 0.038, 3));
                    break;
                case "青雲天空":
                    h.Skills.Add(new UmaSkill("一寸先是……", SkillWhen.Early, SkillWhat.TargetUp, 0.03, 5));
                    break;
                case "玉藻十字":
                    h.Skills.Add(new UmaSkill("白色閃電、看招", SkillWhen.Late, SkillWhat.Accel, 0.30, 3));
                    break;
                case "魯道夫象徵":
                    h.Skills.Add(new UmaSkill("皇帝的驕傲", SkillWhen.Late, SkillWhat.TargetUp, 0.04, 4));
                    break;
                case "成田大進":
                    h.Skills.Add(new UmaSkill("Nemesis", SkillWhen.Late, SkillWhat.Accel, 0.32, 3));
                    break;
                case "愛慕織姬":
                    h.Skills.Add(new UmaSkill("斬斷命運", SkillWhen.Last200, SkillWhat.TargetUp, 0.038, 4));
                    break;
                case "雪之美人":
                    h.Skills.Add(new UmaSkill("千萬別忘記", SkillWhen.Mid, SkillWhat.Heal, 14, 0));
                    break;
                case "青竹回憶":
                    h.Skills.Add(new UmaSkill("燃燒吧青竹", SkillWhen.Late, SkillWhat.Accel, 0.30, 3));
                    break;
                case "勝利獎券":
                    h.Skills.Add(new UmaSkill("夢要高高掛起", SkillWhen.Last200, SkillWhat.Accel, 0.34, 3));
                    break;
                case "目白善信":
                    h.Skills.Add(new UmaSkill("爆走公路", SkillWhen.Mid, SkillWhat.Heal, 12, 0));
                    break;
                case "菱曙":
                    h.Skills.Add(new UmaSkill("大胃王衝刺", SkillWhen.Late, SkillWhat.TargetUp, 0.03, 4));
                    break;
                case "真機伶":
                    h.Skills.Add(new UmaSkill("一等星", SkillWhen.Early, SkillWhat.Accel, 0.28, 3));
                    break;
                case "富士奇蹟":
                    h.Skills.Add(new UmaSkill("華麗舞台", SkillWhen.Late, SkillWhat.TargetUp, 0.036, 4));
                    break;
                case "大鳴大放":
                    h.Skills.Add(new UmaSkill("最強之座", SkillWhen.Last200, SkillWhat.TargetUp, 0.04, 4));
                    break;
                case "杏目":
                    h.Skills.Add(new UmaSkill("放眼世界", SkillWhen.Late, SkillWhat.TargetUp, 0.042, 4));
                    break;
                default:
                    h.Skills.Add(new UmaSkill("全力奔馳", SkillWhen.Late, SkillWhat.TargetUp, 0.03, 3));
                    break;
            }

            // 補通用技
            if (h.Burst >= h.Stamina + 8)
                h.Skills.Add(new UmaSkill("追上她!", SkillWhen.Late, SkillWhat.Accel, 0.22, 3));
            else if (h.Speed >= h.Stamina + 5)
                h.Skills.Add(new UmaSkill("先頭維持", SkillWhen.Early, SkillWhat.TargetUp, 0.02, 3));
            else if (h.Stamina >= h.Speed)
                h.Skills.Add(new UmaSkill("深呼吸", SkillWhen.Mid, SkillWhat.Heal, 10, 0));
            else
                h.Skills.Add(new UmaSkill("中盤加速", SkillWhen.Mid, SkillWhat.Accel, 0.2, 3));
        }
        

        private void auto_uma_Load(object sender, EventArgs e)
        {
            AttachSkills();
        }
    }
}