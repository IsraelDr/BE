using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public uint ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public uint Phonenumber { get; set; }
        public string Adress { get; set; }//(psikim)
        public string surrounding_adress { get; set; }
        public bool[] nanny_required { get; set; }
        public int[,] Daily_Nanny_required { get; set; }
        public string Comment { get; set; }
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
