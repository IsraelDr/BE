using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    { 
        public int ID { get; set; }                                                //ID
        public string last_name { get; set; }                                      //last name
        public string first_name { get; set; }                                     //first name
        public string Birthdate { get; set; }                                         //Birthdate
        public int PhoneNumber { get; set; }                                       //Phone number
        public string address { get; set; }//(st,city,cuntry)                      //Address(St, City, Country)
        public bool elevatorExists { get; set; }                                   //Elevator exists?
        public int Floor { get; set; }                                             //Floor
        public int experience { get; set; }                                        //experience
        public int Max_number_kids { get; set; }                                   //Max number kids
        public int Min_age { get; set; }// Min_age (Month)                         //Min age (Month)
        public int Max_age { get; set; }//Max_age(Month)                           //Max age(Month)
        public bool Possible_Hourly_rate { get; set; }//Possible pay rate by Hour? //Possible Hourly rate
        public int Hourly_rate { get; set; }//                                     //Hourly rate
        public int Monthly_rate { get; set; }                                      //Monthly rate
        public bool[] Working_days { get; set; }                                   //Working days
        public int[,] Daily_Working_hours { get; set; }// Daily_Working_hours(week)//Daily Working hours(week)
        public bool Vacation_days { get; set; }// "Chinuch" or "tamat" { get; set; //Vacation days- "Chinuch" or "tamat"
        public string Recommendations { get; set; }                                //Recommendations
        public int Additional_Info { get; set; }                                   //Additional Info
        public Nanny(params object[] parameters)
        {
            ID = (int)parameters[0];
            last_name = (string)parameters[1];
            first_name = (string)parameters[2];
            Birthdate = (string)parameters[3];
            PhoneNumber = (int)parameters[4];
            address = (string)parameters[5];
            elevatorExists = (bool)parameters[6];
            Floor = (int)parameters[7];
            experience = (int)parameters[8];
            Max_number_kids = (int)parameters[9];
            Min_age = (int)parameters[10];
            Max_age = (int)parameters[11];
            Possible_Hourly_rate = (bool)parameters[12];
            Hourly_rate = (int)parameters[13];
            Monthly_rate = (int)parameters[14];
            Working_days = (bool[])parameters[15];
            Daily_Working_hours = (int[,])parameters[16];
            Vacation_days = (bool)parameters[17];
            Recommendations = (string)parameters[18];
            Additional_Info = (int)parameters[19];
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        protected int fideback { get; set; }                                          //
        Nanny() { }
    }
}
