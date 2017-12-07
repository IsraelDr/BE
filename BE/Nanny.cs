using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    { 
        public uint ID { get; set; }                                                //ID
        public string last_name { get; set; }                                      //last name
        public string first_name { get; set; }                                     //first name
        public uint Birthdate { get; set; }                                         //Birthdate
        public uint PhoneNumber { get; set; }                                       //Phone number
        public string address { get; set; }//(st,city,cuntry)                      //Address(St, City, Country)
        public bool elevatorExists { get; set; }                                   //Elevator exists?
        public uint Floor { get; set; }                                             //Floor
        public uint experience { get; set; }                                        //experience
        public uint Max_number_kids { get; set; }                                   //Max number kids
        public uint Min_age { get; set; }// Min_age (Month)                         //Min age (Month)
        public uint Max_age { get; set; }//Max_age(Month)                           //Max age(Month)
        public bool Possible_Hourly_rate { get; set; }//Possible pay rate by Hour? //Possible Hourly rate
        public uint Hourly_rate { get; set; }//                                     //Hourly rate
        public uint Monthly_rate { get; set; }                                      //Monthly rate
        public bool[] Working_days { get; set; }                                   //Working days
        public uint[,] Daily_Working_hours { get; set; }// Daily_Working_hours(week)//Daily Working hours(week)
        public bool Vacation_days { get; set; }// "Chinuch" or "tamat" { get; set; //Vacation days- "Chinuch" or "tamat"
        public string Recommendations { get; set; }                                //Recommendations
        public uint Additional_Info { get; set; }                                   //Additional Info
        public Nanny(params object[] parameters)
        {
            ID = (uint)parameters[0];
            last_name = (string)parameters[1];
            first_name = (string)parameters[2];
            Birthdate = (uint)parameters[3];
            PhoneNumber = (uint)parameters[4];
            address = (string)parameters[5];
            elevatorExists = (bool)parameters[6];
            Floor = (uint)parameters[7];
            experience = (uint)parameters[8];
            Max_number_kids = (uint)parameters[9];
            Min_age = (uint)parameters[10];
            Max_age = (uint)parameters[11];
            Possible_Hourly_rate = (bool)parameters[12];
            Hourly_rate = (uint)parameters[13];
            Monthly_rate = (uint)parameters[14];
            Working_days = (bool[])parameters[15];
            Daily_Working_hours = (uint[,])parameters[16];
            Vacation_days = (bool)parameters[17];
            Recommendations = (string)parameters[18];
            Additional_Info = (uint)parameters[19];
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
        protected int fideback { get; set; }                                          //
        Nanny() { }
    }
}
