using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Child
    {
        uint ID { get; set; }
        uint Mother_ID { get; set; }
        string name { get; set; }
        string Birthdate { get; set; }
        bool SpecialNeeds { get; set; }//-yes or no
        //Additional Info
        //string Tostring() 
      Child() { }

    }
}
