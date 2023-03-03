using System;

namespace PlanYourHeist
{
    public class TeamMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public double CourageFactor { get; set; }

        public TeamMember(string name, int skillLevel, double courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }

        public void ShowTeamMemberStats()
        {
            Console.WriteLine();
            Console.WriteLine(Name);
            Console.WriteLine($" - Skill Level: {SkillLevel}");
            Console.WriteLine($" - Courage Factor: {CourageFactor}");
        }
    }
}
