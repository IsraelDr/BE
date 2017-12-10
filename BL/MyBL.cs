using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class MyBL:IBL
    {
        static Dal_imp dal = new Dal_imp();

        public void AddChild(Child child)
        {
            dal.AddChild(child);//need to add logic
        }

        public void AddContract(Contract contract)
        {
            DateTime temporary = DateTime.Now.AddMonths(-3);
            if (dal.GetChild(contract.Child_ID).Birthdate.CompareTo(temporary) > 0&&contract.contract_signed)
                throw new Exception("Cannot sign contract for child under 3 month!!");//cant sign contract if younger then 3 month
            dal.AddContract(contract);
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
            throw new NotImplementedException();
        }

        public List<Contract> getContractList()
        {
            throw new NotImplementedException();
        }

        public List<Mother> getMotherList()
        {
            throw new NotImplementedException();
        }

        public List<Nanny> getNannyList()
        {
            throw new NotImplementedException();
        }

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

        public void UpdateChild(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(int id)
        {
            throw new NotImplementedException();
            //if (dal.GetChild(contract.Child_ID).Birthdate.CompareTo(temporary) > 0)
            //    throw new Exception("Cannot sign contract for child under 3 month!!");//cant sign contract if younger then 3 month
        }

        public void UpdateMother(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNanny(int id)
        {
            throw new NotImplementedException();
        }
    }
    

}

