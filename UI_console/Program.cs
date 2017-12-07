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
            Console.WriteLine("Input any number: 0-exit,1-add child,2-addMother,3-addNanny");
            input = int.Parse(Console.ReadLine());
            do
            {
                try
                {
                    switch (input)
                    {
                        case 1:
                            bl.addChild(new Child(1, 3, "Test", "12/05/1994", true));
                            break;
                        case 2:
                            bl.addMother(new Mother(1,"first","last",0798512565,"adress","surrounding",true,new int[,] { { 1,3}, { 2,4} },"comment"));
                            break;
                        case 3:
                            bl.AddNanny(new Nanny(1, "first", "last", "12/05/1994", 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] {true, false},new int[,]{ {1,2 }, { 2,5} },false,"recommend",15));
                            break;
                        default:
                            break;
                    };
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                    break;
                }
                Console.WriteLine("Input any number: 0-exit,1-add child");
                input = int.Parse(Console.ReadLine());
            } while (input != 0);

        }
    }
}
