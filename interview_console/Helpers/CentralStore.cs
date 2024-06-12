using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Interface;
using interview_console.Models;

namespace interview_console.Helpers
{
    public static class CentralStore
    {
        public static List<ITable> Tables { get; set; } = new List<ITable>();
        public static List<IParty> Parties { get; set; } = new List<IParty>();
    }
}
