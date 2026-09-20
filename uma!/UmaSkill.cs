using System;

namespace uma_
{
    public enum SkillWhen
    {
        Start,
        Early,
        Mid,
        Late,
        Last200
    }

    public enum SkillWhat
    {
        TargetUp,
        Accel,
        Heal,
        SpeedUp
    }

    public class UmaSkill
    {
        public string Name;
        public SkillWhen When;
        public SkillWhat What;
        public double Value;
        public double Duration;
        public bool Used;

        public UmaSkill(string name, SkillWhen when, SkillWhat what, double value, double duration = 3)
        {
            Name = name;
            When = when;
            What = what;
            Value = value;
            Duration = duration;
        }

        public UmaSkill Clone()
        {
            return new UmaSkill(Name, When, What, Value, Duration);
        }

        public string ShortText()
        {
            return Name;
        }
    }
}