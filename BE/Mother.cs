using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Mother
    {
        protected uint ID { get; set; }
        protected string Lastname { get; set; }
        protected string Firstname { get; set; }
        protected uint Phonenumber { get; set; }
        protected string Adress { get; set; }//(psikim)
        protected string surrounding_adress { get; set; }
        protected bool[] nanny_required { get; set; }
        protected int[,] Daily_Nanny_required { get; set; }
        protected string Comment { get; set; }
        public override string ToString()
        {
            return "";
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
