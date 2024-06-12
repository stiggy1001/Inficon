using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Interface;

namespace interview_console.Models
{
    public class Combo
    {
        public IParty Party { get; set; }
        public ITable Table { get; set; }
        public int Weighting { get; set; }
        public string Group { get; set; }
    }
}
