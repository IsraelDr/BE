using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public int ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Phonenumber { get; set; }
        public string Adress { get; set; }//(psikim)
        public string surrounding_adress { get; set; }
        public bool[] nanny_required { get; set; }
        public int[,] Daily_Nanny_required { get; set; }
        public string Comment { get; set; }
        public MyEnum.Paymentmethode Paymentmethode {get; set;}
        public Mother(params object[] parameters)
        {
            ID = (int)(parameters[0]);
            Lastname = (string)parameters[1];
            Firstname = (string)parameters[2];
            Phonenumber = (int)parameters[3];
            Adress = (string)parameters[4];
            surrounding_adress = (string)parameters[5];
            nanny_required = (bool[])parameters[6];
            Daily_Nanny_required = (int[,])parameters[7];
            Comment = (string)parameters[8];
            Paymentmethode = (MyEnum.Paymentmethode)parameters[9];
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        /*
         * ID
         * Last name
         * first name
         * phoneNumber
         *  Address(St, City, Country)
         *  searching address
         *  Babysitting days or not
         *   Daily Babysitting hours(week)
         *    Additional Info
          Tostring
         */
    }
}
