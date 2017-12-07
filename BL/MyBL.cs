using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class MyBL
    {
        static Dal_imp dal = new Dal_imp();
        public void addChild(Child child)
        {
            dal.AddChild(child);//need to add logic
        }
        public void addMother(Mother mother)
        {
            dal.AddMother(mother);//need to add logic
        }

    }
    

}

