using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public uint _ID { get ; set; }
        public uint Mother_ID { get; set; }
        public string name { get; set; }
        public string Birthdate { get; set; }
        public bool SpecialNeeds { get; set; }//-yes or no
            //Additional Info
            //string Tostring() 
        public override string ToString() { return  ""; }
        public Child(uint _id, uint _mother_id,string _name,string _birthdate,bool _specialneeds)
        {
            _ID = _id;
            Mother_ID = _mother_id;
            name = _name;
            Birthdate = _birthdate;
            SpecialNeeds = _specialneeds;
        }

    }
}
