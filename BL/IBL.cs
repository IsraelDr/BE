using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
        void AddNanny(Nanny nanny);
        void RemoveNanny(int id);
        void UpdateNanny(Nanny nanny);
        Nanny GetNannyById(int id);

        void AddMother(Mother mother);
        void RemoveMother(int id);
        void UpdateMother(Mother mother);
        Mother GetMotherById(int id);


        void AddChild(Child child);
        void RemoveChild(int id);
        void UpdateChild(Child chil);
        Child GetChildById(int id);

        void AddContract(Contract contract);
        void RemoveContract(int id);
        void UpdateContract(Contract contract);
        Contract GetContractById(int id);

        IEnumerable<BE.Nanny> getNannyList();
        IEnumerable<BE.Mother> getMotherList();
        IEnumerable<BE.Child> getChildList();
        IEnumerable<BE.Contract> getContractList();

    }
}
