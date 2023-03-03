using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            // collect team members until the name input is blank string
            List<TeamMember> team = new List<TeamMember>();
            bool creatingTeam = true;
            while (creatingTeam)
            {
                TeamMember teamMember = CreateNewTeamMember();
                if (teamMember != null)
                {
                    team.Add(teamMember);
                }
                else
                {
                    creatingTeam = false;
                }
            }

            Console.WriteLine($"\nYour team has {team.Count} members.");

            Random rnd = new Random();

            int luckValue = rnd.Next(-10, 10);
            int bankDifficulty = 100 + luckValue;

            int sumOfSkillLevels = 0;
            foreach (TeamMember member in team)
            {
                sumOfSkillLevels += member.SkillLevel;
            }

            Console.WriteLine("\n--- HEIST REPORT ---");
            Console.WriteLine($"Team Skill Level: {sumOfSkillLevels}");
            Console.WriteLine($"Bank Difficulty: {bankDifficulty}");

            if (sumOfSkillLevels >= bankDifficulty)
            {
                Console.WriteLine("\nSuccess! You pulled off the heist!");
            }
            else
            {
                Console.WriteLine("\nBusted! You're gonna rot in prison!");
            }

            TeamMember CreateNewTeamMember()
            /*
                Prompt the user to enter a team member's name and save that name.
                Prompt the user to enter a team member's skill level and save that skill level with the name
                    The skill level should be a positive integer.
                Prompt the user to enter a team member's courage factor and save that courage factor with the name.
                    The courage factor should be a decimal between 0.0 and 2.0
            */
            {
                Console.WriteLine("\n--- CREATE A NEW TEAM MEMBER ---\n");
                Console.Write($"Team member name: ");
                string name = Console.ReadLine().Trim();

                if (name == "")
                {
                    return null;
                }

                int skillLevel;
                while (true)
                {
                    Console.WriteLine();
                    Console.Write($"Enter {name}'s skill level: ");
                    string answer = Console.ReadLine();
                    bool isInteger = int.TryParse(answer, out skillLevel);
                    if (isInteger && skillLevel > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter a positive integer for skill level");
                    }
                }

                double courageFactor;
                while (true)
                {
                    Console.WriteLine();
                    Console.Write($"Enter a courage factor for {name}: ");
                    string answer = Console.ReadLine();
                    bool isDouble = double.TryParse(answer, out courageFactor);
                    if (isDouble && courageFactor > 0.0 && courageFactor <= 2.0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "Please enter a value between 0.0 and 2.0 for courage factor."
                        );
                    }
                }

                return new TeamMember(name, skillLevel, courageFactor);
            }
        }
    }
}
