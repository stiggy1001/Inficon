using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;
using interview_console.Interface;

namespace interview_console.Models
{
    public class Party: IParty
    {
        public int Id { get; }
        public string Name { get; set; }
        public List<EPartyTraits> Traits { get; set; } = new List<EPartyTraits>();
        public ITable AssignedTable { get; set; } // not used for this test

        public Party(int PartyId)
        {
            Id = PartyId;
        }
    }
}
