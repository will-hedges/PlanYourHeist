using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            // allow the user to set the difficulty level
            int bankDifficulty = GetPositiveIntegerInput("Enter a value for the bank difficulty");

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

            Console.WriteLine($"\n\nYour team has {team.Count} members.");

            // allow the user to input the number of scenarios to run
            int numOfScenarios = GetPositiveIntegerInput(
                "How many heist simulations do you want to run?"
            );

            // count the number of successful and failed heists
            decimal successfulHeists = 0;
            decimal failedHeists = 0;

            foreach (int scenarioNum in Enumerable.Range(0, numOfScenarios))
            {
                bool successful = RunHeist(bankDifficulty, team, scenarioNum);
                if (successful)
                {
                    successfulHeists++;
                }
                else
                {
                    failedHeists++;
                }
            }

            decimal oddsOfSuccess = successfulHeists / numOfScenarios * 100;

            // display the number of successful and failed heists, as well as the odds of success
            Console.WriteLine("\n--- FINAL HEIST REPORT ---");
            Console.WriteLine($"Successful runs: {successfulHeists}");
            Console.WriteLine($"Failed runs: {failedHeists}");
            Console.WriteLine($"\nOdds of success = {oddsOfSuccess}%");

            int GetPositiveIntegerInput(string prompt)
            {
                while (true)
                {
                    Console.Write($"\n{prompt}: ");
                    string answer = Console.ReadLine();
                    int res;
                    bool isNumber = int.TryParse(answer, out res);
                    if (isNumber && res > 0)
                    {
                        return res;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a positive integer.");
                    }
                }
            }

            bool RunHeist(int difficultyLevel, List<TeamMember> team, int runNumber)
            {
                Random rnd = new Random();

                int luckValue = rnd.Next(-10, 10);
                difficultyLevel += luckValue;

                int sumOfSkillLevels = 0;
                foreach (TeamMember member in team)
                {
                    sumOfSkillLevels += member.SkillLevel;
                }

                Console.WriteLine($"\n--- HEIST REPORT ({runNumber + 1}) ---");
                Console.WriteLine($"Team Skill Level: {sumOfSkillLevels}");
                Console.WriteLine($"Bank Difficulty: {difficultyLevel}");

                if (sumOfSkillLevels >= difficultyLevel)
                {
                    Console.WriteLine("\nSuccess! You pulled off the heist!\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nBusted! You're gonna rot in prison!\n");
                    return false;
                }
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
                Console.WriteLine("\n\n--- CREATE A NEW TEAM MEMBER ---\n");
                Console.Write($"Team member name: ");
                string name = Console.ReadLine().Trim();

                if (name == "")
                {
                    return null;
                }

                int skillLevel = GetPositiveIntegerInput($"Enter a skill level for {name}");

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
                        Console.WriteLine("Please enter a value between 0.0 and 2.0");
                    }
                }

                return new TeamMember(name, skillLevel, courageFactor);
            }
        }
    }
}
