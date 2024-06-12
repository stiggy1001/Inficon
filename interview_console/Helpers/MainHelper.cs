using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Models;

namespace interview_console.Helpers
{
    public class MainHelper
    {
        public List<Combo> TotalPossibleAssignments(bool Display = true)
        {
            //Setup
            int numberOfTables = 4;
            int numberOfParties = 4;
            TableManager.ClearTables();
            PartyManager.ClearParties();

            Utils.GenerateTables(numberOfTables);
            Utils.GenerateParties(numberOfParties);
            Utils.AssignTraits();

            //Get Combinations
            int grouping = 0;
            //returns sets by table
            var combinations =
                CentralStore.Tables.Where(x => x != null)
                    .SelectMany(g => CentralStore.Parties.Where(c => c != null)
                        .Select(c => new Combo {Table = g, Party = c})
                    ).ToList();

            if (Display)
            {
                Console.Clear();
                foreach (var combination in combinations)
                {
                        Console.WriteLine("Table " + combination.Table.Id + " has " + combination.Party.Name + "(" +
                                          combination.Party.Id + ") > group=" + combination.Group);
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }

            return combinations.ToList();
        }

        public List<Combo> TotalFeasibleAssignments(bool Display = true)
        {
            List<Combo> AllAssignments = TotalPossibleAssignments(false);
            Utils.SetAssignmentWeighting(ref AllAssignments);

            if (Display)
            {
                Console.Clear();
                foreach (var combination in AllAssignments)
                {
                    if (combination.Weighting <= -500)
                    {
                        continue;
                    }
                    Console.WriteLine("Table " + combination.Table.Id + " has " + combination.Party.Name + "(" +
                                      combination.Party.Id + ") with weight " + combination.Weighting);
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }

            return AllAssignments;
        }

        public void FeasibleAssignmentsRanked(bool Display = true)
        {
            List<Combo> AllAssignments = TotalFeasibleAssignments(false).OrderByDescending(x=>x.Weighting).ToList();

            if (Display)
            {
                Console.Clear();
                foreach (var combination in AllAssignments)
                {
                    if (combination.Weighting <= -500)
                    {
                        continue;
                    }

                    Console.WriteLine("Table " + combination.Table.Id + " has " + combination.Party.Name + "(" +
                                      combination.Party.Id + ") with weight " + combination.Weighting);
                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
        }

        public void AllHellBrokeLoose(bool Display = true)
        {
            List<Combo> AllAssignments = TotalFeasibleAssignments(false).ToList();
            
            AllAssignments = AllAssignments.Where(x =>
            {
                //removed table 4 from consideration
                if (x.Table.Id == 4)
                {
                    return false;
                }

                //Update us to switch with Mates
                if (x.Table.Id == 2 && x.Party.Id == 1)
                {
                    x.Weighting += 500;
                }
                return true;
            }).ToList().OrderByDescending(x => x.Weighting).ToList(); ;


            if (Display)
            {
                Console.Clear();
                foreach (var combination in AllAssignments)
                {
                    if (combination.Weighting <= -500)
                    {
                        continue;
                    }

                    Console.WriteLine("Table " + combination.Table.Id + " has " + combination.Party.Name + "(" +
                                      combination.Party.Id + ") with weight " + combination.Weighting);
                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
        }
    }
}
