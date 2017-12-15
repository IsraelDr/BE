using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Api.Maps.Service;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;

using BE;//
using DAL;
using GoogleMapsApi;
using System.Reflection;

namespace BL
{
    public class BL_imp : IBL
    {
        static Dal_imp dal = new Dal_imp();
        /**********new******/
        public static int calculateDistance(string source, string destination)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                //Destination = "kfar ivri ,10, Jerusalem,israel"
                Destination = destination,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;

        }
        /**********new******/
        public int PrioritiesMach(Mother m,Nanny  n)
        {
            int mcheCount = 0, daysCheck=0,startHoursCheck = 0, endHoursCheck = 0; 
            for (int i = 0; i < 6; i++)
                {
                if (n.Working_days[i] == true && m.nanny_required[i] == true)
                    daysCheck++;//6 checks
                if (n.Daily_Working_hours[i, 0].TotalHours <= m.daily_Nanny_required[i, 0].TotalHours)
                    startHoursCheck++;//6 checks
                if (n.Daily_Working_hours[i, 1].TotalHours >= m.daily_Nanny_required[i, 1].TotalHours)
                    endHoursCheck++;//6 checks
            }
            mcheCount = daysCheck + startHoursCheck + endHoursCheck;//18 is match
            return mcheCount;
        }
        /**********new******/
        public bool isPrioritiesMach(Mother m, Nanny n)
        { if (PrioritiesMach(m, n) == 18)//there if 18 cheacs "days Check" + "start Hours Check" , "end Hours Check"
                return true;
            else
                return false;
        }
        /**********new******/
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
                List<Nanny> temp = new List<Nanny>();
                temp = dal.getNannyList();
                //sorting by Priorities Mache from 1 to 18 scale
                temp.Sort((x, y) => PrioritiesMach(mother, x).CompareTo(PrioritiesMach(mother,y)));
                for (int i=temp.Count-1 ; i > (temp.Count - 1)-5; i--)
                {
                    matcheList.Add(temp[i]);
                }
            }
            return matcheList;
        }
        /**********new******/ //return the Nanny list that the close to mother
        public List<Nanny> closeNannyList(Mother mom,string source,int radius  )
        {
            if (source == null)
                source = mom.Adress;
            List<Nanny> closesNannyList = new List<Nanny>();
            List<Nanny> temp = new List<Nanny>();
            temp = dal.getNannyList();
            temp.Sort((x, y) => calculateDistance(mom.Adress, x.address).CompareTo(calculateDistance(mom.Adress, y.address)));
            foreach (Nanny n in temp)
            {
                if (calculateDistance(mom.Adress, n.address) <= radius)
                    closesNannyList.Add(n);
            }
            return closesNannyList;
        }
        /**********new******/
        public void AddChild(Child child)
        {
            dal.AddChild(child);//need to add logic
        }
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
        public void AddContract(Contract contract)
        {
               DateTime temporary = DateTime.Now.AddMonths(-3);
               if (dal.GetChild(contract.Child_ID).Birthdate.CompareTo(temporary) > 0&&contract.contract_signed)
               throw new Exception("Cannot sign contract for child under 3 month!!");//cant sign contract if younger then 3 month

            if (dal.GetMother(contract.Child_ID).Paymentmethode == MyEnum.Paymentmethode.houerly)
            {
                contract.Paymentmethode = MyEnum.Paymentmethode.houerly;
                double week_payment = 0;
                for (int i = 0; i < 6; i++)//6 days hours X Hourly_payment= week 
                {
                    week_payment += contract.Hourly_payment  * (dal.GetNanny(contract.Nanny_ID).Daily_Working_hours[i, 0].TotalHours - dal.GetNanny(contract.Nanny_ID).Daily_Working_hours[i, 1].TotalHours);
                }
                contract.salary = week_payment * 4;//week hours X 4 =month salary
            }
            else contract.salary = contract.Monthly_payment;

                bool flag = false; 
                if(dal.getContractList().Count>0)
                foreach (Contract c  in dal.getContractList())//check brathers for 2% discount
            	{            
                            if(dal.GetMother(contract.Child_ID)==dal.GetMother(c.Child_ID))
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
            dal.AddContract(contract);
        }
        /**********new******/
        public List<Child> childWithOutNunnyList()//return list of all children with out Nanny
        {
            List<Child> children = new List<Child>();
            foreach (Child kide in dal.getChildList())  
            { bool flag = true;
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
        public void AddMother(Mother mother)
        {
            dal.AddMother(mother);//need to add logic
        }

        public void AddNanny(Nanny nanny)
        {
            DateTime temporary = nanny.Birthdate;
            temporary= temporary.AddYears(18);
            if(temporary.CompareTo(DateTime.Now)>0)
                throw new Exception("The nanny must be over 18 years old");
            dal.AddNanny(nanny);//need to add logic
        }

        public List<Child> getChildList()
        {
            return dal.getChildList();
        }

        public List<Contract> getContractList()
        {
            return dal.getContractList();
        }

        public List<Mother> getMotherList()
        {
            return dal.getMotherList();
        }

        public List<Nanny> getNannyList()
        {
            return dal.getNannyList();
        }
        /**********new******/
        public void RemoveChild(int id)
        {
            #region check if child  has open contracts
            
            RemoveContract( (dal.getContractList().FirstOrDefault(n => n.Child_ID == id)).Contract_number);
            int openContractCount =
                    (from contr in dal.getContractList()
                     where contr.Child_ID == id/*&& contr.contractFinalized == true*/ && ((DateTime.Today - contr.enddate).Days < 0)
                     select contr).Count();
            if (openContractCount >= 0)
                RemoveContract((dal.getContractList().FirstOrDefault(n => n.Child_ID == id)).Contract_number);
           
            #endregion
            dal.RemoveChild(id);
        }

        public void RemoveContract(int id)
        {
            dal.RemoveContract(id);
        }

        public void RemoveMother(int id)
        {
            foreach (Contract c in dal.getContractList())
            {
                if (dal.GetChild(c.Child_ID).Mother_ID == id)
                    dal.RemoveContract(c.Contract_number);
            }
            dal.RemoveMother(id);

        }

        public void RemoveNanny(int id)
        {
            dal.RemoveNanny(id);
        }

        public void UpdateChild(Child chil)
        {
            dal.UpdateChild(chil);
        }

        public void UpdateContract(int id)
        {
            throw new NotImplementedException();
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

