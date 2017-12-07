using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
    public uint ID;
    public uint _ID { get ; set; }
    public uint Mother_ID { get; set; }
    public string name { get; set; }
    public string Birthdate { get; set; }
    public bool SpecialNeeds { get; set; }//-yes or no
                                             //Additional Info
    public override string ToString()
    {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
    }
    

    }
}
