using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    /// <summary>
    /// Class that defines objects foreach mother
    /// </summary>
    public class Mother
    {
        private int ID_;
        private string Lastname_;
        private string Firstname_;
        private string Phonenumber_;
        private string Address_;//(psikim)
        private string surrounding_Address_;
        private bool[] nanny_required_;
        private TimeSpan[][] Daily_Nanny_required_;
        private string Comment_;
        private MyEnum.Paymentmethode Paymentmethode_;
        private int Max_Distance_;
        

        public int ID                               { get { return ID_; } set { ID_ = value; } }
        public string Lastname                      { get { return Lastname_; } set
            {
                Lastname_ = value;
            }
        }
        public string Firstname                     { get { return Firstname_; } set { Firstname_ = value; } }
        public string Phonenumber                      { get { return Phonenumber_; } set { Phonenumber_ = value; } }
        public string Address                        { get { return Address_; } set { Address_ = value; } }//(psikim)
        public string surrounding_Address            { get { return surrounding_Address_; } set { surrounding_Address_ = value; } }
        public bool[] nanny_required                { get { return nanny_required_; } set { nanny_required_ = value; } }
        public TimeSpan[][] daily_Nanny_required          { get { return Daily_Nanny_required_; } set { Daily_Nanny_required_ = value; } }
        public string Comment                       { get { return Comment_; } set { Comment_ = value; } }
        public MyEnum.Paymentmethode Paymentmethode { get { return Paymentmethode_; } set { Paymentmethode_ = value; } }
        public int Max_Distance                               { get { return Max_Distance_; } set { Max_Distance_ = value; } }
        //ctor
        public Mother( int ID,string Firstname,string Lastname, string Phonenumber,string Address,string surrounding_Address,bool[] nanny_required,TimeSpan[][] daily_Nanny_required,string Comment,MyEnum.Paymentmethode Paymentmethode, int max_Distance)
        {
            ID_ = ID;
            Lastname_ = Lastname;
            Firstname_ = Firstname;
            Phonenumber_ = Phonenumber;
            Address_ = Address;
            surrounding_Address_ = surrounding_Address;
            nanny_required_ = nanny_required;
            Daily_Nanny_required_ = daily_Nanny_required;
            Comment_ = Comment;
            Paymentmethode_ = Paymentmethode;
            Max_Distance_ = max_Distance;
        }//ctor
        public Mother()
        {
            nanny_required = new bool[7];
            Daily_Nanny_required_ = new TimeSpan[7][];
            for (int i = 0; i < Daily_Nanny_required_.Length; i++)
            {
                Daily_Nanny_required_[i] = new TimeSpan[] { new TimeSpan(12,0,0), new TimeSpan(12, 0,0) };
            }
            Max_Distance = 12;
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        
    }
}
