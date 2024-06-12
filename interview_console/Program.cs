using System;
using System.Linq;
using interview_console.Helpers;

namespace interview_console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            MainHelper MH = new MainHelper();

            while (!done)
            {
                Console.WriteLine("Please select desired result");
                Console.WriteLine("1 > Total Possible Table Assignments");
                Console.WriteLine("2 > Total Feasible Table Assignments");
                Console.WriteLine("3 > Feasible Table Assignments Ordered Best to Worst");
                Console.WriteLine("4 > Extra Credit aka All Hell Broke Loose");
                Console.WriteLine("5 > Exit");

                ConsoleKeyInfo CKI = Console.ReadKey();

                switch (CKI.Key)
                {
                    #region 1 Key
                    case ConsoleKey.D1:
                    {
                        MH.TotalPossibleAssignments();
                        break;
                    }
                    case ConsoleKey.NumPad1:
                    {
                        MH.TotalPossibleAssignments();
                        break;
                    }
                    #endregion
                    #region 2 Key
                    case ConsoleKey.D2:
                    {
                        MH.TotalFeasibleAssignments();
                        break;
                    }
                    case ConsoleKey.NumPad2:
                    {
                        MH.TotalFeasibleAssignments();
                        break;
                    }
                    #endregion
                    #region 3 Key
                    case ConsoleKey.D3:
                    {
                        MH.FeasibleAssignmentsRanked();
                        break;
                    }
                    case ConsoleKey.NumPad3:
                    {
                        MH.FeasibleAssignmentsRanked();
                        break;
                    }
                    #endregion
                    #region 4 Key
                    case ConsoleKey.D4:
                    {
                        MH.AllHellBrokeLoose();
                        break;
                    }
                    case ConsoleKey.NumPad4:
                    {
                        MH.AllHellBrokeLoose();
                        break;
                    }
                    #endregion
                    #region 5 Key
                    //Exit
                    case ConsoleKey.D5:
                    {
                        done = true;
                        break;
                    }
                    case ConsoleKey.NumPad5:
                    {
                        done = true;
                        break;
                    }
                    #endregion
                }
                Console.Clear();
            }
        }
    }
}
