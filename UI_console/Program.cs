using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsAPI;
using BE;
using BL;

namespace UI_console
{

    class Program
    {

        static BL.BL_imp bl = new BL.BL_imp();

        static void Main(string[] args)
        {
            bl.AddNanny(new Nanny(1, "Li", "Ben Saken", new DateTime(1994, 05, 17), 0798516858, "bern", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 1));
            bl.AddNanny(new Nanny(7, "Sara", "Rachamim", new DateTime(1994, 05, 17), 0798516858, "tel aviv", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 34));
            bl.AddNanny(new Nanny(90, "Keshet", "Gur", new DateTime(1994, 05, 17), 0798516858, "jerusalem", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 4));
            bl.AddNanny(new Nanny(4, "Efrat", "Milikowski", new DateTime(1994, 05, 17), 0798516858, "ashdod", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15, 3));
            bl.AddNanny(new Nanny(6, "Ilana", "Levy", new DateTime(1994, 05, 17), 0798516858, "bnei brak", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15, 5));
            Console.WriteLine("GetNumberOfContractWithConditioncontractConditionDistanceGreatThen10 "+" " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceGreatThen10));
            bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceSmallThenEqoul10);
            bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceNannyHaveMoreThen2Children);
            bl.GetNumberOfContractWithCondition(bl.contractsEnd);
            bl.GetNumberOfContractWithCondition(bl.contractStart2018);
            bl.GetNumberOfContractWithCondition(bl.contractStartAfter2018);
            bl.GetNumberOfContractWithCondition(bl.contractStartBefore2018);
            Console.WriteLine((BL.BL_imp.calculateDistance("jerusalem", "tel-aviv")/1000).ToString());

            #region test case

        
            
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
                            bl.AddChild(new Child("1", "3", "Test", new DateTime(1994, 05, 12), true));
                            break;
                        case 2:
                            bl.AddMother(new Mother(1, "first", "last", "0798512565", "Tel Aviv", "surrounding", new bool[] { true, false }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, "comment", MyEnum.Paymentmethode.monthly));
                            //bl.AddMother(new Mother(1, "first", "last", "0798512565", "adress", "surrounding", new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, MyEnum.Paymentmethode.houerly), "Comment");
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
