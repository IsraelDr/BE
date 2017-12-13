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
        void UpdateMother(int id);


        void AddChild(Child child);
        void RemoveChild(int id);
        void UpdateChild(Child chil);

        void AddContract(Contract contract);
        void RemoveContract(int id);
        void UpdateContract(int id);

        List<BE.Nanny> getNannyList();
        List<BE.Mother> getMotherList();
        List<BE.Child> getChildList();
        List<BE.Contract> getContractList();
    }
}
