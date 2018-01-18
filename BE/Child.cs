using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   /// <summary>
   /// Class that defines an object of each child
   /// </summary>
    public class Child
    {
        private int ID_;
        private int Mother_ID_;
        private string name_;
        private DateTime Birthdate_;
        private bool SpecialNeeds_;

        public int ID{ get { return ID_; }set{ID_ = value;}}
        public int Mother_ID { get { return Mother_ID_; } set { Mother_ID_ = value; } }
        public string name { get { return name_; } set{name_ = value;} }
        public DateTime Birthdate { get { return Birthdate_; } set { Birthdate_=value; } }
        public bool SpecialNeeds  { get { return SpecialNeeds_; } set { SpecialNeeds_=value; } }//-yes or no
                                              //Additional Info
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        public Child() {
            Birthdate = DateTime.Now;
        }
        public Child(string _id,string mother_id,string _name,DateTime? _birthdate,bool specialneeds)
        {
            int temp;
            if (!int.TryParse(_id, out temp))
                throw new Exception("ID of Child not valid!");
            ID = temp;
            if (!int.TryParse(mother_id,out temp))
                throw new Exception("ID of Mother not valid!");
            Mother_ID = temp;
            name = _name;
            Birthdate = Convert.ToDateTime(_birthdate);
            SpecialNeeds = specialneeds;
        }
    }
}
