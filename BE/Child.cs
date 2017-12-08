using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public int _ID { get; set; }
        public int Mother_ID { get; set; }
        public string name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool SpecialNeeds { get; set; }//-yes or no
                                              //Additional Info
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        public Child(int _id,int mother_id,string _name,DateTime _birthdate,bool specialneeds)
        {
            _ID = _id;
            Mother_ID = mother_id;
            name = _name;
            Birthdate = _birthdate;
            SpecialNeeds = specialneeds;
        }
    }
}
