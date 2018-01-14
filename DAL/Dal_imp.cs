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
        #region Nanny
        public void AddNanny(Nanny nanny)
        {
            DAL_XML_Imp b = new DAL_XML_Imp();
            //Nanny nann = GetNanny(nanny.ID);
            Nanny nann=b.GetNanny(nanny.ID);
            if (nann != null)
                throw new Exception("Nanny with the same id already exists...");
            //DataSource.NannyList.Add(nanny);
            b.AddNanny(nanny);

        }
        public Nanny GetNanny(int id)
        {
            DAL_XML_Imp b = new DAL_XML_Imp();
            return b.GetNanny(id);
            //return DataSource.NannyList.FirstOrDefault(n => n.ID == id);
        }

        public void RemoveNanny(int id)
        {
            DAL_XML_Imp b = new DAL_XML_Imp();
            //Nanny nann = GetNanny(id);
            Nanny nann = b.GetNanny(id);
            if (nann == null)
                throw new Exception("Nanny with the same id not found...");
            b.RemoveNanny(id);
            //DataSource.NannyList.RemoveAll(n => n.ID == id);

            //DataSource.NannyList.Remove(nann);
            //IEnumerable<Contract> contractsofNanny = getContractList(x => x.Nanny_ID == id);
            //foreach (Contract contr in contractsofNanny.ToList())
            //{
            //    RemoveContract(contr.Contract_ID);
            //}

        }

        public void UpdateNanny(Nanny nanny)
        {
            DAL_XML_Imp b = new DAL_XML_Imp();
            b.UpdateNanny(nanny);
            //DataSource.NannyList.RemoveAll(n => n.ID == nanny.ID);
            //DataSource.NannyList.Add(nanny);
        }
        public IEnumerable<BE.Nanny> getNannyList(Func<Nanny, bool> predicate = null)
        {
            /*if(predicate==null)
                return DataSource.NannyList.AsEnumerable();
            return DataSource.NannyList.Where(predicate);*/
            DAL_XML_Imp b = new DAL_XML_Imp();
            if (predicate == null)
                return b.getNannyList().AsEnumerable();
            return b.getNannyList().Where(predicate);
        }
        #endregion Nanny

        #region Mother
        public void AddMother(Mother mother)
        {
            DAL_XML_Imp a = new DAL_XML_Imp();
            Mother mom = a.GetMother(mother.ID);
            if (mom != null)
                throw new Exception("Mother with the same id already exists...");
            a.AddMother(mother);
            //Mother mom = GetMother(mother.ID);
            //if (mom != null)
            //    throw new Exception("Mother with the same id already exists...");
            //DataSource.MotherList.Add(mother);
        }
        public Mother GetMother(int id)
        {
            DAL_XML_Imp a = new DAL_XML_Imp();

            return a.GetMother(id);
            //return DataSource.MotherList.FirstOrDefault(n => n.ID == id);
        }
        

        
        public void RemoveMother(int id)
        {
            DAL_XML_Imp a = new DAL_XML_Imp();
            a.RemoveMother(id);
            //Mother moth = GetMother(id);
            //if (moth == null)
            //    throw new Exception("Mother with the same id not found...");

            //DataSource.MotherList.RemoveAll(n => n.ID == id);

            //DataSource.MotherList.Remove(moth);
            //IEnumerable<Child> children = getChildList(x => x.Mother_ID == id);
            //foreach (Child child in children.ToList())
            //{
            //    RemoveChild(child.ID);
            //}
        }
        public void UpdateMother(Mother mother)
        {
            DAL_XML_Imp a = new DAL_XML_Imp();
            a.UpdateMother(mother);
            //DataSource.MotherList.RemoveAll(n => n.ID == mother.ID);
            //DataSource.MotherList.Add(mother);
        }
        public IEnumerable<BE.Mother> getMotherList(Func<Mother, bool> predicate = null)
        {
            /*if(predicate==null)
                return DataSource.MotherList.AsEnumerable();
            return DataSource.MotherList.Where(predicate);*/

            DAL_XML_Imp b = new DAL_XML_Imp();
            if (predicate == null)
                return b.getMotherList().AsEnumerable();
            return b.getMotherList().Where(predicate);
        }
        #endregion Mother

        #region Child
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
            IEnumerable<Contract> contractsofChild = getContractList(x => x.Child_ID == id);
            foreach (Contract contr in contractsofChild.ToList())
            {
                RemoveContract(contr.Contract_ID);
            }
        }
        public void UpdateChild(Child chil)
        {
            DataSource.ChildList.RemoveAll(n => n.ID == chil.ID);
            DataSource.ChildList.Add(chil);

        }
        public IEnumerable<BE.Child> getChildList(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.ChildList.AsEnumerable();
            return DataSource.ChildList.Where(predicate);
        }
        #endregion Child

        #region Contract
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

            DataSource.ContractList.RemoveAll(n => n.Contract_ID == id);

            DataSource.ContractList.Remove(contr);
        }
        public void UpdateContract(Contract contract)
        {
            DataSource.ContractList.RemoveAll(n => n.Contract_ID == contract.Contract_ID);
            DataSource.ContractList.Add(contract);
        }

        
        
        public IEnumerable<BE.Contract> getContractList (Func<Contract, bool> predicate = null) {
            if(predicate==null)
                return DataSource.ContractList.AsEnumerable();
            return DataSource.ContractList.Where(predicate);
        }
        #endregion Contract
    }
}
