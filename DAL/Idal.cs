using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     class Idal
    {
        protected void addNanny() { }
         protected void deleteNanny() { }
        protected void editNanny() { }

        protected void addMother() { }
        protected void deleteMother() { }
        protected void editMother() { }


        protected void addChild() { }
        protected void deleteChild() { }
        protected void editChild() { }

        protected void addContract() { }
        protected void deleteContract() { }
        protected void editContract() { }

        protected List<BE.Nanny> getNannyList() { List < BE.Nanny > n= new List<BE.Nanny>(); return n; }
        protected List<BE.Mother> getMotherList() { List<BE.Mother> n = new List<BE.Mother>(); return n; }
        protected List<BE.Child> getChildList() { List<BE.Child> n = new List<BE.Child>(); return n; }
        protected List<BE.Contract> getContractList() { List<BE.Contract> n = new List<BE.Contract>(); return n; }
        
    }
}
