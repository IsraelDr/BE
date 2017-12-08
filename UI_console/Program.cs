using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace UI_console
{
    class Program
    {
        static MyBL bl = new MyBL();
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("Input any number: 0-exit,1-add child,2-addMother,3-addNanny,4-addCOntract");
            input = int.Parse(Console.ReadLine());
            while (input != 0)
            {
                try
                {
                    switch (input)
                    {
                        case 1:
                            bl.AddChild(new Child(1, 3, "Test", new DateTime(1994, 05, 12), true));
                            break;
                        case 2:
                            bl.AddMother(new Mother(1, "first", "last", 0798512565, "adress", "surrounding", new bool[] { true, false }, new int[,] { { 1, 3 }, { 2, 4 } }, "comment"));
                            break;
                        case 3:
                            bl.AddNanny(new Nanny(1, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false }, new int[,] { { 1, 2 }, { 2, 5 } }, false, "recommend", 15));
                            break;
                        case 4:
                            bl.AddContract(new Contract(1,4, true, false,17,485,true, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17)));
                            break;
                        default:
                            break;
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Input any number: 0-exit,1-add child,2-addMother,3-addNanny,4-addCOntract");
                input = int.Parse(Console.ReadLine());
            }

        }
    }
}
