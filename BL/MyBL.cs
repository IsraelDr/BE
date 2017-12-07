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
            throw new NotImplementedException();
        }

        public void addChild(Child child)
        {
            dal.AddChild(child);//need to add logic
        }

        public void AddContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void addMother(Mother mother)
        {
            dal.AddMother(mother);//need to add logic
        }

        public void AddMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        public void AddNanny(Nanny nanny)
        {
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
            throw new NotImplementedException();
        }

        public void RemoveContract(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMother(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveNanny(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateChild(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(int id)
        {
            throw new NotImplementedException();
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

