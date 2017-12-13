using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        private int ID_;
        private int Mother_ID_;
        private string name_;
        private DateTime Birthdate_;
        private bool SpecialNeeds_;

        public int ID            { get { return ID_; } set { ID_=value; } }
        public int Mother_ID      { get { return Mother_ID_; } set { Mother_ID_=value; } }
        public string name        { get { return name_; } set { name_=value; } }
        public DateTime Birthdate { get { return Birthdate_; } set { Birthdate_=value; } }
        public bool SpecialNeeds  { get { return SpecialNeeds_; } set { SpecialNeeds_=value; } }//-yes or no
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
