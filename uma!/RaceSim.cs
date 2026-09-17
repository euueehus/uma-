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
                double acc = 0.35 + r.Horse.RaceBurst / 250.0;

                if (r.Speed < target) r.Speed = Math.Min(target, r.Speed + acc * Dt);
                else r.Speed = Math.Max(target, r.Speed - acc * 0.7 * Dt);

                double drain = 0.35 + (r.Speed - 14) * 0.08;
                if (phase == 2) drain *= 1.35;
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
            double baseV = 14.5 + r.Horse.RaceSpeed / 22.0;
            double styleMul = 1.0;

            if (r.Style == RunStyle.Nige)
                styleMul = phase == 0 ? 1.06 : phase == 1 ? 1.00 : 0.97;
            else if (r.Style == RunStyle.Senko)
                styleMul = phase == 0 ? 1.02 : phase == 1 ? 1.01 : 0.99;
            else if (r.Style == RunStyle.Sashi)
                styleMul = phase == 0 ? 0.96 : phase == 1 ? 1.00 : 1.04;
            else
                styleMul = phase == 0 ? 0.93 : phase == 1 ? 0.98 : 1.07;

            if (r.Horse.Form == auto_uma.UmaForm.Peak) styleMul += 0.03;
            else if (r.Horse.Form == auto_uma.UmaForm.Good) styleMul += 0.015;
            else if (r.Horse.Form == auto_uma.UmaForm.Slump) styleMul -= 0.02;

            int rank = CurrentRank(r);
            if (r.Style == RunStyle.Nige && rank > 1) styleMul += 0.02;
            if (r.Style == RunStyle.Oikomi && phase < 2 && rank < 4) styleMul -= 0.02;

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