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

        static BL_imp bl = new BL_imp();
        static void Main(string[] args)
        {
            #region test case
            /*
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            bl.AddMother(new Mother(1, "first", "last", 0798512565, "Tel Aviv", "surrounding", new bool[] { true, false }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, "comment", MyEnum.Paymentmethode.houerly));
            bl.AddNanny(new Nanny(1, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(11, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(111, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(1111, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(11111, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(111111, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(1111111, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(12, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(122, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(1222, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Jerusalem", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 1));
            bl.AddNanny(new Nanny(7, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Bat Yam", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 34));
            bl.AddNanny(new Nanny(90, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Hulon", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 4));
            bl.AddNanny(new Nanny(4, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Haspin", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 3));
            bl.AddNanny(new Nanny(6, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Modiin", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15, 5));
            bl.AddChild(new Child(1, 3, "Test", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child(2, 3, "Test", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child(3, 3, "Test", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child(4, 3, "Test", new DateTime(1994, 05, 12), true));
            
            //int x= BL.BL_imp.("Tel Aviv", "Jerusalem");

            //new System.Threading.Thread(() =>
            //{
            bl.closeNannyList(bl.GetMotherById(1), 50000);
            //}).Start();

            //Console.WriteLine(x.ToString());
            Console.WriteLine(sw.ElapsedMilliseconds);

            //System.Threading.Thread.W

            return;
            */
            #endregion
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
