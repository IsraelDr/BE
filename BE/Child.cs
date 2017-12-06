using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
    protected uint ID;
    protected uint _ID { get ; set; }
    protected uint Mother_ID { get; set; }
    protected string name { get; set; }
    protected string Birthdate { get; set; }
    protected bool SpecialNeeds { get; set; }//-yes or no
                                             //Additional Info
    public override string ToString()
    {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
    }
    

    }
}
