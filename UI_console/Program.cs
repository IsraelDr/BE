using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GoogleMapsAPI;
using BE;
using BL;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;
using GoogleMapsApi;

namespace UI_console
{

    class Program
    {

        static BL.BL_imp bl = new BL.BL_imp();

        public static List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            PlaceAutocompleteRequest request = new PlaceAutocompleteRequest();
            request.ApiKey = "AIzaSyA9DLA9vL6ARd0UGd5sZnwI0-Jocz9MBXQ";
            request.Input = str;
            var response = GoogleMaps.PlaceAutocomplete.Query(request);
            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }
            return result;
        }

        static void Main(string[] args)
        {

            Console.Write("input a string");
            string s = Console.ReadLine();
            List<string> bb = GetPlaceAutoComplete(s);
            //bl.AddMother(new Mother(1, "Dana", "Anilewitch", "0798512565", "jerusalem", "jerusalem", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            //bl.AddMother(new Mother(2, "Rona", "Gurewitch", "0798512565", "tel aviv", "tel aviv", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(15, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            //bl.AddMother(new Mother(3, "Tal", "Ben Atia", "0798512565", "basel", "basel", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            //bl.AddMother(new Mother(4, "Lea", "Yosefof", "0798512565", "tiberias", "tiberias", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, "comment", MyEnum.Paymentmethode.hourly));
            //                                                                                                                                                                                                                                         start******************end*****                    start******************end*****                   start******************end*****                     start******************end*****                    start******************end*****                    start******************end*****             start******************end*****                                                                                                                                                                                                                                            start******************end*****
            bl.AddNanny(new Nanny(1, "Li", "Ben Saken", new DateTime(1994, 05, 17), "0798516858", "bern", true, 6, 5, 12, 1, 2, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 1));
            bl.AddNanny(new Nanny(7, "Sara", "Rachamim", new DateTime(1994, 05, 17), "0798516858", "tel aviv", true, 6, 5, 12, 5, 3, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 34));
            bl.AddNanny(new Nanny(90, "Keshet", "Gur", new DateTime(1994, 05, 17), "0798516858", "jerusalem", true, 6, 5, 12, 7, 15, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15, 4));
            bl.AddNanny(new Nanny(4, "Efrat", "Milikowski", new DateTime(1994, 05, 17), "0798516858", "ashdod", true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15, 3));
            bl.AddNanny(new Nanny(6, "Ilana", "Levy", new DateTime(1994, 05, 17), "0798516858", "bnei brak", true, 6, 5, 12, 8, 12, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15, 5));

            bl.AddChild(new Child("1", "3", "Jankel", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child("2", "1", "Shloime", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child("3", "3", "Jossi", new DateTime(1994, 05, 12), true));
            bl.AddChild(new Child("4", "2", "Avi", new DateTime(1994, 05, 12), true));

            bl.AddContract(new Contract(4, 1, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17), 19.15, 35, false));
            bl.AddContract(new Contract(4, 2, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17), 15.14, 4, false));
            bl.AddContract(new Contract(4, 3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2020, 05, 17), 751.5, 0, false));
            bl.AddContract(new Contract(4, 4, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 14000.50, 14, false));
            bl.AddContract(new Contract(4, 1, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 19.15, 35, false));
            bl.AddContract(new Contract(4, 2, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 15.14, 4, false));
            bl.AddContract(new Contract(4, 3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2019, 05, 17), new DateTime(2020, 05, 17), 751.5, 0, false));
            bl.AddContract(new Contract(4, 4, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2019, 05, 17), new DateTime(2020, 05, 17), 14000.50, 14, false));
            bl.AddContract(new Contract(4, 1, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 19.15, 35, false));
            bl.AddContract(new Contract(4, 2, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 15.14, 4, false));
            bl.AddContract(new Contract(4, 3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2019, 05, 17), new DateTime(2020, 05, 17), 751.5, 0, false));
            bl.AddContract(new Contract(4, 4, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2019, 05, 17), new DateTime(2020, 05, 17), 14000.50, 14, false));

            Console.WriteLine(" Number Of contracts Distance Great Then 10 KM: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceGreatThen10));
            Console.WriteLine(" Number Of contracts Nanny Have More Then 2 Children: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceNannyHaveMoreThen2Children));
            Console.WriteLine(" Number Of contracts Distance Small Then or Eqoul 10 KM: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceSmallThenEqoul10));
            Console.WriteLine(" Number Of contracts End: " + " " + bl.GetNumberOfContractWithCondition(bl.contractsEnd));
            Console.WriteLine(" Number Of contracts Start at 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStart2018));
            Console.WriteLine(" Number Of contractS Start After 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStartAfter2018));
            Console.WriteLine(" Number Of contract Start Before 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStartBefore2018));

            Console.WriteLine("calculate Distance jerusalem, tel - aviv:"+(BL.BL_imp.calculateDistance("jerusalem", "tel-aviv")/1000).ToString());

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
                            //bl.AddMother(new Mother(1, "first", "last", "0798512565", "Tel Aviv", "surrounding", new bool[] { true, false }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, "comment", MyEnum.Paymentmethode.monthly));
                            //bl.AddMother(new Mother(1, "first", "last", "0798512565", "Address", "surrounding", new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, MyEnum.Paymentmethode.houerly), "Comment");
                            break;
                        case 3:
                            bl.AddNanny(new Nanny(1, "first", "last", new DateTime(1994, 05, 17), 0798516858, "Address", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false }, new int[,] { { 1, 2 }, { 2, 5 } }, false, "recommend", 15));
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
