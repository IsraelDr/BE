using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;
namespace DAL
{
    public class Dal_imp:Idal
    {
        public void AddNanny(Nanny nanny)
        {
            Nanny nann = GetNanny(nanny.ID);
            if (nann != null)
                throw new Exception("Nanny with the same id already exists...");
            DataSource.NannyList.Add(nanny);

        }
        public Nanny GetNanny(int id)
        {
            return DataSource.NannyList.FirstOrDefault(n => n.ID == id);
        }

        public void RemoveNanny(int id)
        {
            Nanny nann = GetNanny(id);
            if (nann == null)
                throw new Exception("Nanny with the same id not found...");

            DataSource.NannyList.RemoveAll(n => n.ID == id);

            DataSource.NannyList.Remove(nann);
        }

        public void UpdateNanny(Nanny nanny)
        {
            DataSource.NannyList.RemoveAll(n => n.ID == nanny.ID);
            DataSource.NannyList.Add(nanny);
        }

        public void AddMother(Mother mother)
        {
            Mother mom = GetMother(mother.ID);
            if (mom != null)
                throw new Exception("Mother with the same id already exists...");
            DataSource.MotherList.Add(mother);
        }
        public Mother GetMother(int id)
        {
            return DataSource.MotherList.FirstOrDefault(n => n.ID == id);
        }
        public void RemoveMother(int id)
        {
            Mother moth = GetMother(id);
            if (moth == null)
                throw new Exception("Mother with the same id not found...");

            DataSource.MotherList.RemoveAll(n => n.ID == id);

            DataSource.MotherList.Remove(moth);
        }
        public void UpdateMother(Mother mother)
        {
            DataSource.MotherList.RemoveAll(n => n.ID == mother.ID);
            DataSource.MotherList.Add(mother);
        }


        public void AddChild(Child child)
        {
            Child chil = GetChild(child.ID);
            if (chil != null)
                throw new Exception("Child with the same id already exists...");
            DataSource.ChildList.Add(child);
        }
        public Child GetChild(int id)
        {
            return DataSource.ChildList.FirstOrDefault(n => n.ID == id);
        }
        public void RemoveChild(int id)
        {
            Child chil = GetChild(id);
            if (chil == null)
                throw new Exception("Child with the same id not found...");

            DataSource.ChildList.RemoveAll(n => n.ID == id);

            DataSource.ChildList.Remove(chil);
        }
        public void UpdateChild(Child chil)
        {
            DataSource.ChildList.RemoveAll(n => n.ID == chil.ID);
            DataSource.ChildList.Add(chil);

        }

        public void AddContract(Contract contract)
        {
            Contract contr = GetContract(contract.Contract_ID);
            if (contr != null)
                throw new Exception("Contract with the same id already exists...");
             
               
            DataSource.ContractList.Add(contract);
        }
        public Contract GetContract(int id)
        {
            return DataSource.ContractList.FirstOrDefault(n => n.Contract_ID == id);
        }
        public void RemoveContract(int id)
        {
            Contract contr = GetContract(id);
            if (contr == null)
                throw new Exception("Contract with the same id not found...");

            DataSource.ContractList.RemoveAll(n => n.Contract_number == id);

            DataSource.ContractList.Remove(contr);
        }
        public void UpdateContract(int id) { }

        public List<BE.Nanny> getNannyList() { return DataSource.NannyList; }
        public List<BE.Mother> getMotherList() { return DataSource.MotherList; }
        public List<BE.Child> getChildList() { return DataSource.ChildList; }
        public List<BE.Contract> getContractList() { return DataSource.ContractList; }
    }
}
