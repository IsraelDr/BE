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

        public void UpdateNanny(int id) { }

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
        public void RemoveMother(int id) { }
        public void UpdateMother(int id) { }


        public void AddChild(Child child)
        {
            Child chil = GetChild(child._ID);
            if (chil != null)
                throw new Exception("Child with the same id already exists...");
            DataSource.ChildList.Add(child);
        }
        public Child GetChild(int id)
        {
            return DataSource.ChildList.FirstOrDefault(n => n._ID == id);
        }
        public void RemoveChild(int id) { }
        public void UpdateChild(int id) { }

        public void AddContract(Contract contract) { }
        public void RemoveContract(int id) { }
        public void UpdateContract(int id) { }

        public List<BE.Nanny> getNannyList() { return DataSource.NannyList; }
        public List<BE.Mother> getMotherList() { return DataSource.MotherList; }
        public List<BE.Child> getChildList() { return DataSource.ChildList; }
        public List<BE.Contract> getContractList() { return DataSource.ContractList; }
    }
}
