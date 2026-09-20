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
    }

    public class RaceSim
    {
        public List<RunnerState> Runners { get; private set; }
        public double Distance { get; private set; }
        public double Time { get; private set; }
        public bool Done { get; private set; }

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
            RunStyle style;
            if (h.RaceBurst >= h.RaceStamina + 8) style = RunStyle.Oikomi;
            else if (h.RaceSpeed >= h.RaceStamina + 5) style = RunStyle.Nige;
            else if (h.RaceStamina >= h.RaceSpeed) style = RunStyle.Senko;
            else style = RunStyle.Sashi;

            double hp = 80 + h.RaceStamina * 1.2;
            return new RunnerState
            {
                Horse = h,
                Style = style,
                Position = 0,
                Speed = 14,
                Hp = hp,
                MaxHp = hp
            };
        }

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
                double target = TargetSpeed(r, phase);
                double acc = 0.22 + r.Horse.RaceBurst / 400.0;

                if (r.Speed < target) r.Speed = Math.Min(target, r.Speed + acc * Dt);
                else r.Speed = Math.Max(target, r.Speed - acc * 0.7 * Dt);

                double drain = 0.22 + (r.Speed - 16) * 0.04;
                if (phase == 2) drain *= 1.20;
                if (r.Hp > 0) r.Hp -= drain * Dt;
                else r.Speed *= 0.985;

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
            double baseV = 16.2 + r.Horse.RaceSpeed / 80.0;

            double styleMul;
            if (r.Style == RunStyle.Nige)
                styleMul = phase == 0 ? 1.025 : phase == 1 ? 1.000 : 0.990;
            else if (r.Style == RunStyle.Senko)
                styleMul = phase == 0 ? 1.010 : phase == 1 ? 1.000 : 0.998;
            else if (r.Style == RunStyle.Sashi)
                styleMul = phase == 0 ? 0.985 : phase == 1 ? 1.000 : 1.020;
            else
                styleMul = phase == 0 ? 0.975 : phase == 1 ? 0.995 : 1.035;

            if (r.Horse.Form == auto_uma.UmaForm.Peak) styleMul += 0.012;
            else if (r.Horse.Form == auto_uma.UmaForm.Good) styleMul += 0.006;
            else if (r.Horse.Form == auto_uma.UmaForm.Slump) styleMul -= 0.010;

            double pack = 0;
            foreach (var x in Runners) pack += x.Position;
            pack /= Runners.Count;

            double off = r.Position - pack;
            if (off > 6) styleMul -= Math.Min(0.05, (off - 6) * 0.004);
            else if (off < -6) styleMul += Math.Min(0.05, (-6 - off) * 0.004);

            int rank = CurrentRank(r);
            if (r.Style == RunStyle.Nige && rank > 2 && phase == 0)
                styleMul += 0.012;
            if (r.Style == RunStyle.Oikomi && phase < 2 && rank <= 3)
                styleMul -= 0.012;

            return baseV * styleMul;
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
    }
}