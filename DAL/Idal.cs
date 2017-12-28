using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        void AddNanny(Nanny nanny);
        void RemoveNanny(int id);
        void UpdateNanny(Nanny nanny);

        void AddMother(Mother mother);
        void RemoveMother(int id);
        void UpdateMother(Mother mother);


        void AddChild(Child child);
        void RemoveChild(int id);
        void UpdateChild(Child chil);

        void AddContract(Contract contract);
        void RemoveContract(int id);
        void UpdateContract(Contract contract);

        IEnumerable<BE.Nanny> getNannyList(Func<Nanny, bool> predicate = null);
        IEnumerable<BE.Mother> getMotherList(Func<Mother, bool> predicate = null);
        IEnumerable<BE.Child> getChildList(Func<Child, bool> predicate = null);
        IEnumerable<BE.Contract> getContractList(Func<Contract, bool> predicate = null);
    }
}
