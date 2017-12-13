using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class Address
    {
       
        private string street_;
        private string city_;
        private string country_;

       public string st      { get { return street_; }  set { street_ = value; } }
       public string city    { get { return city_  ; }  set { city_ = value; } }
       public string country { get { return country_; } set { country_ = value; } }
       public string address {get{ return street_ + " " + city_ + " " + country_; } }
        Address()
        {
            st = " ";
            city = " ";
            country = " ";
        }
    }
}
