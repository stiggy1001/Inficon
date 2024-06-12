using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;
using interview_console.Interface;

namespace interview_console.Models
{
    public class Table: ITable
    {
        public int Id { get; }
        public List<ETableTraits> Traits { get; set; } = new List<ETableTraits>();

        public Table(int TableId)
        {
            Id = TableId;
        }
    }
}
