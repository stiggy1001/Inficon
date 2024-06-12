using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;
using interview_console.Models;

namespace interview_console.Helpers
{
    public static class Utils
    {
        //public static int SitHereWeight(Table table)
        //{
        //    int weight = 0;

        //    if (table.NearDoor && !table.Party.DoorAllowed)
        //    {
        //        return -100;
        //    }

        //    if (table.NearKitchen && table.Party.KitchenWeight < 0)
        //    {
        //        weight += table.Party.KitchenWeight;
        //    }

        //    if (table.Party.BetweenWeight > 0)
        //    {
        //        if (table.TableNeighbours.Count > 1)
        //        {
        //            bool any = table.TableNeighbours.Any(x =>
        //            {
        //                if (x.Party.Id == 2 || x.Party.Id == 4)
        //                    return true;
        //                return false;
        //            });
        //            if (any)
        //            {
        //                weight += table.Party.BetweenWeight;
        //            }

        //        }
        //    }


        //    return weight;
        //}
        
        //used to generate data at runtime, could use a dbase to load this
        public static void GenerateTables(int numOfTables, Dictionary<int,ETableTraits> traitAssignments = null)
        {
            if(traitAssignments == null)
            { traitAssignments = new Dictionary<int, ETableTraits>();}
            for (int i = 0; i < numOfTables; i++)
            {
                List<ETableTraits> TraitsToAdd = traitAssignments.Where(x => x.Key == i).Select(x => x.Value).ToList();
                TableManager.CreateTable(i+1, TraitsToAdd);
            }
        }

        //used to generate data at runtime, could use a dbase to load this
        public static void GenerateParties(int numOfParties, Dictionary<int, EPartyTraits> traitAssignments = null)
        {
            if (traitAssignments == null)
            { traitAssignments = new Dictionary<int, EPartyTraits>(); }

            for (int i = 0; i < numOfParties; i++)
            {
                List<EPartyTraits> TraitsToAdd = traitAssignments.Where(x => x.Key == i).Select(x => x.Value).ToList();
                PartyManager.CreateParty(i+1, TraitsToAdd);
            }
        }

        public static void AssignTraits()
        {
            //Table1 is by door
            CentralStore.Tables[0].Traits.Add(ETableTraits.ByDoor);
            //Table3 is by the kitchen
            CentralStore.Tables[2].Traits.Add(ETableTraits.ByKitchen);
            //Table 4 is by the bar
            CentralStore.Tables[3].Traits.Add(ETableTraits.ByBar);

            //Us
            CentralStore.Parties[0].Name = "Us";
            //My Parents
            CentralStore.Parties[1].Name = "My Parents";
            CentralStore.Parties[1].Traits.Add(EPartyTraits.NoDoor);
            //Her Parents
            CentralStore.Parties[2].Name = "Her Parents";
            CentralStore.Parties[2].Traits.Add(EPartyTraits.NoKitchen);
            //My Mates
            CentralStore.Parties[3].Name = "My Mates";
            CentralStore.Parties[3].Traits.Add(EPartyTraits.NoBar);
        }

        public static void SetAssignmentWeighting(ref List<Combo> Combos)
        {
            foreach (Combo combo in Combos)
            {
                int weight = 0;
                if (combo.Table.Traits.Contains(ETableTraits.ByDoor))
                {
                    if (combo.Party.Traits.Contains(EPartyTraits.NoDoor))
                    {
                        weight += -1000;
                    }
                }

                if (combo.Table.Traits.Contains(ETableTraits.ByKitchen))
                {
                    if (combo.Party.Traits.Contains(EPartyTraits.NoKitchen))
                    {
                        weight += -50;
                    }
                }

                if (combo.Table.Traits.Contains(ETableTraits.ByBar))
                {
                    if (combo.Party.Traits.Contains(EPartyTraits.NoBar))
                    {
                        weight += -50;
                    }
                }

                if (combo.Table.Id == 2 && combo.Party.Id == 4)
                {
                    weight += 50;
                }

                if ((combo.Table.Id == 1 || combo.Table.Id == 3) && (combo.Party.Id == 4 || combo.Party.Id == 1))
                {
                    weight += -50;
                }
                combo.Weighting = weight;
            }
        }
    }
}

//table order 1,2,3,4
