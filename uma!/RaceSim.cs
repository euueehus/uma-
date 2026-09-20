using System;
using System.Collections.Generic;
using System.Linq;

namespace uma_
{
    public enum RunStyle
    {
        Nige,
        Senko,
        Sashi,
        Oikomi
    }

    public class RunnerState
    {
        public auto_uma.Horse Horse;
        public RunStyle Style;
        public double Position;
        public double Speed;
        public double Hp;
        public double MaxHp;
        public bool Finished;
        public double FinishTime;

        public List<UmaSkill> Skills;
        public double ExtraTarget;
        public double ExtraAcc;
        public double SkillTimer;
    }

    public class RaceSim
    {
        public List<RunnerState> Runners { get; private set; }
        public double Distance { get; private set; }
        public double Time { get; private set; }
        public bool Done { get; private set; }

        public List<string> SkillLog = new List<string>();
        private Random rng = new Random();
        private const double Dt = 0.1;

        public RaceSim(List<auto_uma.Horse> horses, double distanceMeters)
        {
            Distance = distanceMeters;
            Time = 0;
            Done = false;
            Runners = horses.Select(h => CreateRunner(h)).ToList();
        }


        private RunnerState CreateRunner(auto_uma.Horse h)
        {
            RunStyle style = PickStyle(h.Name, h);

            double hp = 80 + h.RaceStamina * 1.2;
            return new RunnerState
            {
                Horse = h,
                Style = style,
                Position = 0,
                Speed = 14,
                Hp = hp,
                MaxHp = hp,
                Skills = h.Skills == null
                    ? new List<UmaSkill>()
                    : h.Skills.Select(s => s.Clone()).ToList(),
                ExtraTarget = 0,
                ExtraAcc = 0,
                SkillTimer = 0
            };
        }
        private static RunStyle PickStyle(string name, auto_uma.Horse h)
        {
            switch (name)
            {
                case "無聲鈴鹿":
                case "美浦波旁":
                case "丸善斯基":
                case "微光飛駒":
                case "真機伶":
                case "青雲天空":
                    return RunStyle.Nige;

                case "特別周":
                case "東海帝皇":
                case "小栗帽":
                case "伏特加":
                case "大和赤驥":
                case "草上飛":
                case "神鷹":
                case "氣槽":
                case "目白麥昆":
                case "帝王光環":
                case "魯道夫象徵":
                case "里見光鑽":
                case "富士奇蹟":
                case "大鳴大放":
                case "杏目":
                case "菱亞馬遜":
                case "玉藻十字":
                case "愛慕織姬":
                    return RunStyle.Senko;

                case "北部玄駒":
                case "成田白仁":
                case "優秀素質":
                case "曼城茶座":
                case "待兼福來":
                case "愛麗速子":
                case "成田大進":
                case "雪之美人":
                case "勝利獎券":
                case "目白善信":
                case "萊茵實力":
                case "超級小溪":
                    return RunStyle.Sashi;

                case "黃金船":
                case "米浴":
                case "春烏拉拉":
                case "醒目飛鷹":
                case "青竹回憶":
                case "菱曙":
                    return RunStyle.Oikomi;

                default:
                    if (h.RaceBurst >= h.RaceStamina + 8) return RunStyle.Oikomi;
                    if (h.RaceSpeed >= h.RaceStamina + 5) return RunStyle.Nige;
                    if (h.RaceStamina >= h.RaceSpeed) return RunStyle.Senko;
                    return RunStyle.Sashi;
            }
        }



        //public bool Tick()
        //{
        //    if (Done) return true;
        //    Time += Dt;

        //    double early = Distance / 6.0;
        //    double late = Distance * 2.0 / 3.0;

        //    foreach (var r in Runners)
        //    {
        //        if (r.Finished) continue;

        //        double phase = r.Position < early ? 0 : r.Position < late ? 1 : 2;
        //        UpdateSkills(r, phase);
        //        double target = TargetSpeed(r, phase) * (1.0 + r.ExtraTarget);
        //        double acc = 0.45 + r.Horse.RaceBurst / 280.0 + r.ExtraAcc;
        //        if (phase == 2) acc += 0.25;

        //        double drain = 0.20 + Math.Max(0, r.Speed - 16.2) * 0.05;
        //        if (r.Style == RunStyle.Nige) drain *= 1.08;
        //        if (phase == 2) drain *= 1.50;
        //        if (r.Hp > 0) r.Hp -= drain * Dt;
        //        else r.Speed *= 0.985;

        //        r.Position += r.Speed * Dt;

        //        if (r.Position >= Distance)
        //        {
        //            r.Position = Distance;
        //            r.Finished = true;
        //            r.FinishTime = Time;
        //        }
        //    }

        //    Done = Runners.All(x => x.Finished);
        //    return Done;
        //}
        public bool Tick()
        {
            if (Done) return true;
            Time += Dt;

            double early = Distance / 6.0;
            double late = Distance * 2.0 / 3.0;

            foreach (var r in Runners)
            {
                if (r.Finished) continue;

                double phase = r.Position < early ? 0 : r.Position < late ? 1 : 2;

                UpdateSkills(r, phase);

                double target = TargetSpeed(r, phase) * (1.0 + r.ExtraTarget);
                r.Speed += (target - r.Speed) * 0.35;
                if (r.Speed < 8) r.Speed = 8;

                double drain = 0.20 + Math.Max(0, r.Speed - 16) * 0.05;
                if (r.Style == RunStyle.Nige) drain *= 1.08;
                if (phase == 2) drain *= 1.50;

                if (r.Hp > 0) r.Hp -= drain * Dt;
                else r.Speed *= 0.98;

                r.Position += r.Speed * Dt;

                if (r.Position >= Distance)
                {
                    r.Position = Distance;
                    r.Finished = true;
                    r.FinishTime = Time;
                }
            }

            Done = Runners.All(x => x.Finished);
            return Done;
        }

        private double TargetSpeed(RunnerState r, double phase)
        {
            double v = 15.4 + r.Horse.RaceSpeed / 50.0;

            if (r.Style == RunStyle.Nige)
                v *= phase == 0 ? 1.05 : phase == 1 ? 1.01 : 0.97;
            else if (r.Style == RunStyle.Senko)
                v *= phase == 0 ? 1.02 : phase == 1 ? 1.01 : 1.01;
            else if (r.Style == RunStyle.Sashi)
                v *= phase == 0 ? 0.97 : phase == 1 ? 1.00 : 1.04;
            else
                v *= phase == 0 ? 0.95 : phase == 1 ? 0.99 : 1.07;

            if (r.Horse.Form == auto_uma.UmaForm.Peak) v *= 1.02;
            else if (r.Horse.Form == auto_uma.UmaForm.Good) v *= 1.01;
            else if (r.Horse.Form == auto_uma.UmaForm.Slump) v *= 0.98;

            if (phase == 0)
            {
                double pack = 0;
                foreach (var x in Runners) pack += x.Position;
                pack /= Runners.Count;
                double off = r.Position - pack;
                if (off > 20) v *= 0.99;
                else if (off < -20) v *= 1.01;
            }

            int rank = CurrentRank(r);

            if (phase == 2)
            {
                v += (r.Horse.RaceBurst - 82) / 600.0;

                if (rank >= 2)
                    v *= 1.00 + Math.Min(0.08, (rank - 1) * 0.012);

                if (r.Position >= Distance - 250)
                    v *= r.Style == RunStyle.Oikomi ? 1.06
                       : r.Style == RunStyle.Sashi ? 1.04
                       : 1.00;

                if (rank == 1 && r.Style == RunStyle.Nige)
                    v *= 0.97;

                if (r.Hp < r.MaxHp * 0.12) v *= 0.95;
            }

            return v;
        }

        public int CurrentRank(RunnerState me)
        {
            return Runners.Count(x => x.Position > me.Position) + 1;
        }

        public List<RunnerState> Standings()
        {
            return Runners
                .OrderBy(x => x.Finished ? 0 : 1)
                .ThenBy(x => x.FinishTime)
                .ThenByDescending(x => x.Position)
                .ToList();
        }

        public static string StyleText(RunStyle s)
        {
            switch (s)
            {
                case RunStyle.Nige: return "逃";
                case RunStyle.Senko: return "先行";
                case RunStyle.Sashi: return "差";
                default: return "追";
            }
        }
        private void UpdateSkills(RunnerState r, double phase)
        {
            if (r.SkillTimer > 0)
            {
                r.SkillTimer -= Dt;
                if (r.SkillTimer <= 0)
                {
                    r.ExtraTarget = 0;
                    r.ExtraAcc = 0;
                }
            }

            if (r.Finished || r.Skills == null) return;

            SkillWhen now;
            if (r.Position < 25) now = SkillWhen.Start;
            else if (phase == 0) now = SkillWhen.Early;
            else if (phase == 1) now = SkillWhen.Mid;
            else if (r.Position >= Distance - 200) now = SkillWhen.Last200;
            else now = SkillWhen.Late;

            foreach (var s in r.Skills)
            {
                if (s.Used) continue;
                if (s.When != now) continue;

                int chance = 60 + r.Horse.Luck / 5;
                if (rng.Next(1, 101) > chance) { s.Used = true; continue; }

                s.Used = true;
                r.SkillTimer = s.Duration;
                ApplySkill(r, s);
                SkillLog.Add("『" + s.Name + "』  " + r.Horse.Name);
            }
        }

        private void ApplySkill(RunnerState r, UmaSkill s)
        {
            switch (s.What)
            {
                case SkillWhat.TargetUp: r.ExtraTarget += s.Value; break;
                case SkillWhat.Accel: r.ExtraAcc += s.Value; break;
                case SkillWhat.Heal: r.Hp = Math.Min(r.MaxHp, r.Hp + s.Value); break;
                case SkillWhat.SpeedUp: r.Speed += s.Value; break;
            }
        }
    }
}