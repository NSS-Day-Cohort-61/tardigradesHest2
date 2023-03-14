﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist_II
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<string> specialties = new List<string>()
            // {
            //     "Lock Specialist",

            // }

            List<IRobber> rolodex = new List<IRobber>()
            {
                new LockSpecialist("Jeff", 88, 25),
                new LockSpecialist("Freynk", 78, 65),
                new Muscle("Karen", 55, 35),
                new Muscle("Butch", 23, 65),
                new Muscle("Douglas", 50, 43),
                new Hacker("Zuck", 99, 99)
            };
            Console.WriteLine($"Number of crew members: {rolodex.Count}");
            // Prompt user to enter name for new crew member
            string newCrewName = "";

            do
            {
                Console.Write($"Please enter name for new crew member: ");
                newCrewName = Console.ReadLine();

                if (newCrewName.Length > 0)
                {
                    Console.Write(
                        @"Choose a specialty for this crew member:
                1. Lock Specialist
                2. Muscle
                3. Hacker
                : "
                    );
                    int newCrewSpecialty = int.Parse(Console.ReadLine());

                    // once specialty has been entered prompt to enter crew members skill level as int between 1-100
                    Console.Write("Please enter crew member skill level from 1-100: ");
                    int newCrewSkillLevel = int.Parse(Console.ReadLine());

                    // then prompt user to enter percentage of cut for each mission
                    Console.Write("Please enter percentage of cut for each mission: ");
                    int newCrewPercentage = int.Parse(Console.ReadLine());

                    // once user entered all 3 make instance of appropriate class for that crew member and add to rolodex
                    switch (newCrewSpecialty)
                    {
                        case 1:
                            rolodex.Add(
                                new LockSpecialist(
                                    newCrewName,
                                    newCrewSkillLevel,
                                    newCrewPercentage
                                )
                            );
                            break;
                        case 2:
                            rolodex.Add(
                                new Muscle(newCrewName, newCrewSkillLevel, newCrewPercentage)
                            );
                            break;
                        case 3:
                            rolodex.Add(
                                new Hacker(newCrewName, newCrewSkillLevel, newCrewPercentage)
                            );
                            break;
                    }
                }
            } while (newCrewName.Length > 0);

            /*
                Let's do a little recon next. Print out a Recon Report to the user.
                This should tell the user what the bank's most secure system is, and what its least secure system is
                (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault
            */
            Bank bank = new Bank();
            /*
                we need to see the value and the name of each property
                somehow need to get this ordered
                but that means we need some way
            */
            Dictionary<string, int> bankProps = new Dictionary<string, int>();
            // add the bank props to the dict
            // order the dictionary keys by value
            // display the max and min
            bankProps["Alarm"] = bank.AlarmScore;
            bankProps["Guards"] = bank.SecurityGuardScore;
            bankProps["Vault"] = bank.VaultScore;

            var sortedBankProps =
                from entry in bankProps
                orderby entry.Value ascending
                select entry;

            // rather than hardcode, get the first and last keys of the sorted the IOrderedEnumerable
            List<KeyValuePair<string, int>> sortedBankPropsList = sortedBankProps.ToList();
            Console.WriteLine();
            Console.WriteLine(" --- RECON REPORT --- ");
            Console.WriteLine($"Most secure: {sortedBankPropsList[0].Key}");
            Console.WriteLine(
                $"Least secure: {sortedBankPropsList[sortedBankPropsList.Count - 1].Key}"
            );

            // loop over the list of crew and display a report about each team member
            Console.WriteLine();
            Console.WriteLine(" --- ROLODEX --- ");
            foreach (Robber crewMember in rolodex)
            {
                Console.WriteLine();
                crewMember.DisplayCrewMemberReport();
            }
        }
    }
}
