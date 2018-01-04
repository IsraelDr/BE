using System;
using System.Collections.Generic;
using System.Linq;
//using Google.Api.Maps.Service;
using BE;
using DAL;


using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;
using System.Runtime;
using System.Runtime.InteropServices;
namespace BL
{
    public class BL_imp : IBL
    {
        public Idal dal = FactoryDAL.IdalInstance;

        //Function

        public static int calculateDistance(string source, string destination)
        {
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = TravelMode.Driving,
                    Origin = source,
                    //Destination = "kfar ivri ,10, Jerusalem,israel"
                    Destination = destination,
                };
                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                Leg leg = route.Legs.First();
                return leg.Distance.Value/1000;
            }
            catch (Exception e)
            {
                throw e;
            };

        }/**********new Google Maps ******/
        public int PrioritiesMach(Mother m, Nanny n)
        {
            int mcheCount = 0, daysCheck = 0, startHoursCheck = 0, endHoursCheck = 0;
            for (int i = 0; i < 6; i++)
            {
                if (n.Working_days[i] == true && m.nanny_required[i] == true)
                    daysCheck++;//6 checks
                if (n.Daily_Working_hours[i, 0].TotalHours <= m.daily_Nanny_required[i][0].TotalHours)
                    startHoursCheck++;//6 checks
                if (n.Daily_Working_hours[i, 1].TotalHours >= m.daily_Nanny_required[i][1].TotalHours)
                    endHoursCheck++;//6 checks
            }
            mcheCount = daysCheck + startHoursCheck + endHoursCheck;//18 is match
            return mcheCount;
        }
        public bool isPrioritiesMach(Mother m, Nanny n)
        { if (PrioritiesMach(m, n) == 18)//there if 18 cheacs "days Check" + "start Hours Check" , "end Hours Check"
                return true;
            else
                return false;
        }
        public List<Nanny> motherPriorities(Mother mother)// return list of Nnany's that fit to the mother Priorities 
        {

            List<Nanny> matcheList = new List<Nanny>();
            foreach (Nanny nanny in dal.getNannyList())
            {
                if (isPrioritiesMach(mother, nanny))
                    matcheList.Add(nanny);
            }
            if (matcheList.Count == 0)//retur 5 closes mother Priorities 
            {
                IEnumerable<Nanny> ienum = dal.getNannyList();
                List<Nanny> temp = ienum.ToList<Nanny>();
                //sorting by Priorities Mache from 1 to 18 scale
                temp.Sort((x, y) => PrioritiesMach(mother, x).CompareTo(PrioritiesMach(mother, y)));
                for (int i = temp.Count - 1; i > (temp.Count - 1) - 5; i--)
                {
                    matcheList.Add(temp[i]);
                }
            }
            return matcheList;
        }
        /**********new close Nanny List using Google Maps &  Thread ******/ //return the Nanny list that the close to mother
        public List<Nanny> closeNannyList(Mother mom, int radius)
        {
            return closeNannyList(mom, mom.Adress, radius);
        }
        public List<Nanny> closeNannyList(Mother mom, string source, int radius)
        {
            if (mom == null) { return null; }
            if (source == null)
                source = mom.Adress;
            List<Nanny> closesNannyList = new List<Nanny>();
            List<Nanny> temp = new List<Nanny>();
            //temp = dal.getNannyList();

            // check temp not null

            Dictionary<Nanny, int> nnn = new Dictionary<Nanny, int>(); // check Nanny,int

            List<System.Threading.Thread> thds = new List<System.Threading.Thread>();
            foreach (Nanny n in temp)
            {
                System.Threading.Thread t = new System.Threading.Thread(() =>
                    {
                        try
                        {
                            int d = calculateDistance(mom.Adress, n.address);
                            if (d <= radius && d >= 0)
                            {
                                nnn.Add(n, d);
                            }
                        }
                        catch (Exception e)
                        {
                            // fix Nanny?
                            int a = 5;
                        }
                    });
                t.Start();
                //t.Join();
                thds.Add(t);
            }
            foreach (System.Threading.Thread t in thds)
            {
                t.Join();
            }
            closesNannyList = nnn.OrderBy(x => x.Value).Select(x => x.Key).ToList<Nanny>();
            return closesNannyList;
            /******old*********/
            ////foreach (int nan in )
            //{
            //}
            ////temp.Sort((x, y) => calculateDistance(mom.Adress, x.address).CompareTo(calculateDistance(mom.Adress, y.address)));
            //foreach (Nanny n in temp)
            //{
            //    if (calculateDistance(mom.Adress, n.address) <= radius)
            //        closesNannyList.Add(n);
            //}
            //return closesNannyList;
        }
        public List<Child> childWithOutNunnyList()//return list of all children with out Nanny
        {
            List<Child> children = new List<Child>();
            foreach (Child kide in dal.getChildList())
            {
                bool flag = true;
                foreach (Contract c in dal.getContractList())
                {
                    if (c.Child_ID == kide.ID)
                        flag = false;
                }
                if (flag)
                    children.Add(kide);
            }
            if (children == null)
                throw new Exception("To all childeren thre is Nanny!");
            return children;
        }
        public List<Nanny> NannyByViction()
        {
            List<Nanny> ByViction = new List<Nanny>();
            foreach (Nanny nan in dal.getNannyList())
            {
                if (nan.Vacation_days == MyEnum.Vacation.tamat)
                    ByViction.Add(nan);
            }
            if (ByViction != null)
                return ByViction;
            else
                throw new Exception("Ther is't Nanny with Tamat Viction days");
        }
        public class InternetAvailability
        {
            [DllImport("wininet.dll")]
            private extern static bool InternetGetConnectedState(out int description, int reservedValue);

            public static bool IsInternetAvailable()
            {
                int description;
                return InternetGetConnectedState(out description, 0);
            }
        }

        public List<PriorityNanny> PriorityNannyList(Mother m)
        {
            List<PriorityNanny> p = new List<PriorityNanny>();


            List<System.Threading.Thread> thds = new List<System.Threading.Thread>();
            foreach (Nanny nan in motherPriorities(m))
            {
                PriorityNanny temp = new PriorityNanny(nan);
                temp.Salary = calculateSalary(nan, m);
                if (!InternetAvailability.IsInternetAvailable())
                {
                    throw new Exception("No internet connection");
                }
                System.Threading.Thread t = new System.Threading.Thread(() =>
                {
                    try
                    {

                        temp.Distance = calculateDistance(m.Adress, nan.address);
                        p.Add(temp);

                    }
                    catch (Exception)
                    {

                    }
                });
                t.Start();
                //t.Join();
                thds.Add(t);
            }
            foreach (System.Threading.Thread t in thds)
            {
                t.Join();
            }
            p.Sort((x, y) => x.Distance.CompareTo(y.Distance));
            return p;
        }
        

        public List<Contract> GetAllContractWithCondition(contractCondition condition)
        {
            List<Contract> contractCondtionList = new List<Contract>();
            foreach (Contract c in dal.getContractList())
            {
                if (condition(c))
                    contractCondtionList.Add(c);
            }
            if (contractCondtionList.Count > 0)
                return contractCondtionList;
            else throw new Exception("Contract with serch condition not found");
        }
        //dalegate condition 
        public bool contractConditionDistanceGreatThen10(Contract c) { return (c.distance > 10); }
        public bool contractConditionDistanceSmallThenEqoul10(Contract c) { return (c.distance <= 10); }
        public bool contractConditionDistanceNannyHaveMoreThen2Children(Contract c) { return (GetNannyById(c.Nanny_ID).kidsCount > 2); }
        public bool contractsEnd(Contract c) { return (DateTime.Now >c.enddate); }
        public bool contractStart2018(Contract c) { return (  c.enddate.Year==2018); }
        public bool contractStartBefore2018(Contract c) { return (c.enddate.Year < 2018); }
        public bool contractStartAfter2018(Contract c) { return (c.startdate.Year > 2018); }
        public bool contractWithDiscount(Contract c) { return c.discount; }
        
        //Console.WriteLine(" Number Of contracts Distance Great Then 10 KM: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceGreatThen10));
        //Console.WriteLine(" Number Of contracts Nanny Have More Then 2 Children: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceNannyHaveMoreThen2Children));
        //Console.WriteLine(" Number Of contracts Distance Small Then or Eqoul 10 KM: " + " " + bl.GetNumberOfContractWithCondition(bl.contractConditionDistanceSmallThenEqoul10));
        //Console.WriteLine(" Number Of contracts End: " + " " + bl.GetNumberOfContractWithCondition(bl.contractsEnd));
        //Console.WriteLine(" Number Of contracts Start at 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStart2018));
        //Console.WriteLine(" Number Of contractS Start After 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStartAfter2018));
        //Console.WriteLine(" Number Of contract Start Before 2018: " + " " + bl.GetNumberOfContractWithCondition(bl.contractStartBefore2018));

        /*Get Number Of Contract With Condition*/
        public delegate bool contractCondition(Contract c);
        public int GetNumberOfContractWithCondition(contractCondition condition)
        {
            List<Contract> contractCondtionList = new List<Contract>();
            int numberOfContract = 0;
            foreach (Contract c in dal.getContractList())
            {
                if (condition(c))
                    numberOfContract++;
            }

            return numberOfContract;

        }




        //Groping
        public IEnumerable<IGrouping<string, Nanny>> nannysByChildrenAge(bool orderByMaxAge = false)
        {
            if(!orderByMaxAge)
            {
                return from nanny in getNannyList()
                       orderby 3 * (nanny.Min_age / 3)
                       group nanny by (3 * (nanny.Min_age / 3)).ToString()+"-"+ (3 * (nanny.Min_age / 3)+3).ToString();

                //nangroup = getNannyList().GroupBy(x => 3 * (x.Min_age / 3));
            }
           else
            {
                return from item in getNannyList()
                       let nanny = item
                       orderby 3 * (nanny.Max_age / 3)
                       group nanny by (3 * (nanny.Max_age / 3)).ToString() + "-" + (3 * (nanny.Min_age / 3) + 3).ToString();
                //nangroup = getNannyList().GroupBy(x => 3 * (x.Min_age / 3));
            }
        }
        public IEnumerable<IGrouping<double, Contract>> ContractsByNannyDistance()
        {
            return from contract in getContractList()
                   orderby 10 * (contract.distance/ 10)
                   group contract by 10 * (contract.distance / 10);
        }


            //ID
            public Child GetChildById(int id)
        {
            return dal.GetChild(id);
        }
        public Nanny GetNannyById(int id)
        {
            return dal.GetNanny(id);
        }
        public Mother GetMotherById(int id)
        {
            return dal.GetMother(id);
        }
        public Contract GetContractById(int id)
        {
            return dal.GetContract(id);
        }
        //functions
        public bool cheackForDiscount(Nanny nan, Mother m)
        {
            bool flag = false;
            foreach (Contract c in dal.getContractList())
            {
                if (c.Nanny_ID == nan.ID && dal.GetChild(c.Child_ID).Mother_ID == m.ID)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public double calculateSalary(Nanny nan, Mother m)
        {
            double salary = 0;
            if (m.Paymentmethode == MyEnum.Paymentmethode.hourly)
            {

                double week_payment = 0;

                for (int i = 0; i <= 6; i++)//6 days hours X Hourly_payment= week 
                {

                    week_payment += nan.Hourly_rate * (nan.Daily_Working_hours[i, 1].TotalHours - nan.Daily_Working_hours[i, 0].TotalHours);
                }
                salary = week_payment * 4;//week hours X 4 =month salary
            }
            else salary = nan.Monthly_rate;
            if (cheackForDiscount(nan, m))
            {
                return (int)(salary * 0.98);
            }
            else { return (int)salary; }
        }

        //add
        public void AddChild(Child child)
        {
            if (GetMotherById(child.Mother_ID) == null)
                throw new Exception("A mother with this ID doesn't exist");
            dal.AddChild(child);//need to add logic
        }
        

        public void AddContract(Contract contract)
        {

               DateTime temporary = DateTime.Now.AddMonths(-3);
               if (dal.GetChild(contract.Child_ID).Birthdate.CompareTo(temporary) > 0&&contract.contract_signed)
               throw new Exception("Cannot sign contract for child under 3 month!!");//cant sign contract if younger then 3 month
              
            if (dal.GetMother(contract.Child_ID).Paymentmethode == MyEnum.Paymentmethode.hourly)
            {
                contract.Paymentmethode = MyEnum.Paymentmethode.hourly;
                double week_payment = 0;
                Nanny n = dal.GetNanny(contract.Nanny_ID);
                for (int i = 0; i <= 6; i++)//6 days hours X Hourly_payment= week 
                {
                   
                     week_payment += contract.Hourly_payment  * (n.Daily_Working_hours[i, 1].TotalHours - n.Daily_Working_hours[i, 0].TotalHours);
                }
                contract.salary = week_payment * 4;//week hours X 4 =month salary
            }
            else contract.salary = contract.Monthly_payment;

                bool flag = false;
                Child kide = dal.GetChild(contract.Child_ID);
                if (dal.getContractList().ToList().Count>0)
                foreach (Contract c  in dal.getContractList())//check brathers for 2% discount
            	{
                            if (kide.Mother_ID==dal.GetChild(c.Child_ID).Mother_ID&& contract.Nanny_ID == c.Nanny_ID)
                            {
                             flag=true;
                             break;
                            }
            	}   
                if (flag)
                {
                contract.Monthly_payment =contract.Monthly_payment*0.98 ;
                }

            if (dal.GetNanny(contract.Nanny_ID).Max_number_kids <= dal.GetNanny(contract.Nanny_ID).kidsCount)
                throw new Exception("Cannot sign contract nanny over the maximum kids !!!");//cant sign contract over the maximum kids lavel
            else dal.GetNanny(contract.Nanny_ID).kidsCount++;//if contract sign so Nanny.kidsCount++ 
            contract.discount = cheackForDiscount(GetNannyById(contract.Nanny_ID), GetMotherById(dal.GetChild(contract.Child_ID).Mother_ID));
            dal.AddContract(contract);
        }
        public void AddMother(Mother mother)
        {
            dal.AddMother(mother);//need to add logic
        }
        public void AddNanny(Nanny nanny)
        {
            //Text = "{Binding phoneNumber, Converter={StaticResource NoValueConverter}}
           

            DateTime temporary = nanny.Birthdate;
            temporary= temporary.AddYears(18);
            if(temporary.CompareTo(DateTime.Now)>0)
                throw new Exception("The nanny must be over 18 years old");
            dal.AddNanny(nanny);//need to add logic
        }
        //GET LIST
        public IEnumerable<Child> getChildList()
        {
            return dal.getChildList();
        }

        public IEnumerable<Contract> getContractList()
        {
            return dal.getContractList();
        }

        public IEnumerable<Mother> getMotherList()
        {
            return dal.getMotherList();
        }

        public IEnumerable<Nanny> getNannyList()
        {
            return dal.getNannyList();
        }
        /**********Remove******/
        public void RemoveChild(int id)
        {
           
            dal.RemoveChild(id);
        }

        public void RemoveContract(int id)
        {
            dal.RemoveContract(id);
        }

        public void RemoveMother(int id)
        {
            dal.RemoveMother(id);
        }

        public void RemoveNanny(int id)
        {
            dal.RemoveNanny(id);
        }

        /**********Update******/
        public void UpdateChild(Child chil)
        {
            if (GetMotherById(chil.Mother_ID) == null)
                throw new Exception("A mother with this ID doesn't exist");
            if (GetChildById(chil.ID) == null)
                throw new Exception("A child with this ID doesn't exist");
            dal.UpdateChild(chil);
        }

        public void UpdateContract(Contract contract)
        {
            dal.UpdateContract(contract);
            //if (dal.GetChild(contract.Child_ID).Birthdate.CompareTo(temporary) > 0)
            //    throw new Exception("Cannot sign contract for child under 3 month!!");//cant sign contract if younger then 3 month
        }

        public void UpdateMother(Mother mother)
        {
            dal.UpdateMother(mother);
        }

        public void UpdateNanny(Nanny nanny)
        {
            DateTime temporary = nanny.Birthdate;
            temporary = temporary.AddYears(18);
            if (temporary.CompareTo(DateTime.Now) > 0)
                throw new Exception("The nanny must be over 18 years old");
            dal.UpdateNanny(nanny);
        }
    }
    

}

