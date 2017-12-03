using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MyBE
    {
    }
    public class Nanny
    {

        /*ID
          last name
          first name
          Birthdate
          Phone number
          Address(St, City, Country)
          Elevator exists?
          Floor
          experience
          Max number kids
          Min age (Month)
          Max age(Month)
          Possible Hourly rate
          Hourly rate
          Monthly rate
          Working days
          Daily Working hours(week)
          Vacation days- "Chinuch" or "tamat"
          Recommendations
          Additional Info
          Tostring
         */

        protected int ID { get; set; }


        protected string last_name { get; set; }
        protected string first_name { get; set; }
        protected int Birthdate { get; set; }
        protected int PhoneNumber { get; set; }
        protected string address { get; set; }
        protected bool elevatorExists { get; set; }
        protected int Floor { get; set; }
        protected int experience { get; set; }
        protected int Max_number_kids { get; set; }
        protected int Min_age { get; set; }// Min_age (Month)
        protected int Max_age { get; set; }//Max_age(Month)
        protected bool Possible_Hourly_rate { get; set; }//Possible pay rate by Hour?
        protected int Hourly_rate { get; set; }//
        protected int Monthly_rate { get; set; }
        protected int Working_days { get; set; }
        protected int Daily_Working_hours { get; set; }// Daily_Working_hours(week)
        protected bool Vacation_days { get; set; }// "Chinuch" or "tamat" { get; set; }
        protected string Recommendations { get; set; }
        protected int Additional_Info { get; set; }
        protected string Tostring { get; set; }

    }
    public class Mother
    {
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
    
    public class Contract
    {
        /*
         * Contract number(8 digits)
         * Nanny ID
         * Child ID
         * Meeting happen (Yes/no)
         * Contract signed (Yes/no)
         * Hourly rate
         * Monthly_rate
         * Month_Or_hour
         * StartDate
         * finishDate
         * 
          Tostring
         */
    }
}
