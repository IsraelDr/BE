using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    { 
        protected int ID { get; set; }                                                //ID
        protected string last_name { get; set; }                                      //last name
        protected string first_name { get; set; }                                     //first name
        protected int Birthdate { get; set; }                                         //Birthdate
        protected int PhoneNumber { get; set; }                                       //Phone number
        protected string address { get; set; }//(st,city,cuntry)                      //Address(St, City, Country)
        protected bool elevatorExists { get; set; }                                   //Elevator exists?
        protected int Floor { get; set; }                                             //Floor
        protected int experience { get; set; }                                        //experience
        protected int Max_number_kids { get; set; }                                   //Max number kids
        protected int Min_age { get; set; }// Min_age (Month)                         //Min age (Month)
        protected int Max_age { get; set; }//Max_age(Month)                           //Max age(Month)
        protected bool Possible_Hourly_rate { get; set; }//Possible pay rate by Hour? //Possible Hourly rate
        protected int Hourly_rate { get; set; }//                                     //Hourly rate
        protected int Monthly_rate { get; set; }                                      //Monthly rate
        protected bool[] Working_days { get; set; }                                   //Working days
        protected int[,] Daily_Working_hours { get; set; }// Daily_Working_hours(week)//Daily Working hours(week)
        protected bool Vacation_days { get; set; }// "Chinuch" or "tamat" { get; set; //Vacation days- "Chinuch" or "tamat"
        protected string Recommendations { get; set; }                                //Recommendations
        protected int Additional_Info { get; set; }                                   //Additional Info
        
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        protected int fideback { get; set; }                                          //
        Nanny() { }
    }
}
