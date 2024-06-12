using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_console.Enum;

namespace interview_console.Interface
{
    public interface ITable
    {
        int Id { get; }
        List<ETableTraits> Traits { get; set; }
    }
}
