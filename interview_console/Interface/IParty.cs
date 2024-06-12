using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;

namespace interview_console.Interface
{
    public interface IParty
    {
        //int BarWeight { get; }
        //int KitchenWeight { get; }
        //int UsBarWeight { get; }
        //bool DoorAllowed { get; }
        //int BetweenWeight { get; }
        int Id { get;}
        string Name { get; set; }
        List<EPartyTraits> Traits { get; set; }
        ITable AssignedTable { get; set; }
    }
}
