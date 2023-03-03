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
                    teamMember.ShowTeamMemberStats();
                }
                else
                {
                    creatingTeam = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine($" --- YOUR TEAM ({team.Count} MEMBERS) --- ");
            foreach (TeamMember member in team)
            {
                member.ShowTeamMemberStats();
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
                Console.WriteLine();
                Console.WriteLine(" --- CREATE A NEW TEAM MEMBER --- ");
                Console.WriteLine();
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
