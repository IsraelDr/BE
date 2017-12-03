using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   
        interface Idal
        {
            void addNanny();
            void deleteNanny();
            void editNanny();

            void addMother();
            void deleteMother();
            void editMother();


            void addChild();
            void deleteChild();
            void editChild();

            void addContract();
            void deleteContract();
            void editContract();

            List<BE.Nanny> getNannyList();
            List<BE.Mother> getMotherList();
            List<BE.Child> getChildList();
            List<BE.Contract> getContractList();

        }
    
}
