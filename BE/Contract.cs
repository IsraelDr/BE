using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        //public static int contract_number  { get; set; }
        private static int contract_number=10000000;

        public int Contract_number
        {
            get { return contract_number; }
            set { contract_number = value; }
        }

        public int Nanny_ID { get; set; }
        public int Child_ID { get; set; }
        public bool introduce_meeting { get; set; }
        public bool contract_signed { get; set; }
        public int Hourly_payment { get; set; }
        public double Monthly_payment { get; set; }
        public MyEnum.Paymentmethode Paymentmethode { get; set; }//monthly or houerly enum
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public double salary { get; set; }

        public Contract(params object[] parameter)
        {
            contract_number++;
            Nanny_ID = (int) parameter[0];
            Child_ID = (int)parameter[1];
            introduce_meeting = (bool)parameter[2];
            contract_signed = (bool)parameter[3];
            Hourly_payment = (int)parameter[4];
            Monthly_payment = (int)parameter[5];
            Paymentmethode = (MyEnum.Paymentmethode)parameter[6];
            startdate = (DateTime)parameter[7];
            enddate = (DateTime)parameter[8];
            salary = (double)parameter[9];
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
    }
}
