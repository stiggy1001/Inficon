using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;
using interview_console.Interface;
using interview_console.Models;

namespace interview_console.Helpers
{
    public static class PartyManager
    {
        //Used to clear all parties for new scenario
        public static void ClearParties()
        {
            CentralStore.Parties.Clear();
        }

        //Used to add party on the fly, can also be called from a dbase load method to load into mem
        public static IParty CreateParty(int id, List<EPartyTraits> traits)
        {
            Party P = new Party(id);
            P.Traits.AddRange(traits);
            CentralStore.Parties.Add(P);
            return P;
        }
    }
}
