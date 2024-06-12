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
    public static class TableManager
    {
        //Used to clear all tables for new scenario
        public static void ClearTables()
        {
            CentralStore.Tables.Clear();
        }

        //Used to add table on the fly, can also be called from a dbase load method to load into mem
        public static ITable CreateTable(int id, List<ETableTraits> traits)
        {
            Table T = new Table(id);
            T.Traits.AddRange(traits);
            CentralStore.Tables.Add(T);
            return T;
        }

    }
}
