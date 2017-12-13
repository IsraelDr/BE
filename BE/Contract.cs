using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
     
        private static int contract_number_=10000000;
        private int Nanny_ID_;
        private int Child_ID_;
        private bool introduce_meeting_;
        private bool contract_signed_;
        private int Hourly_payment_;
        private double Monthly_payment_;
        private MyEnum.Paymentmethode Paymentmethode_;
        private DateTime startdate_;
        private DateTime enddate_;
        private double salary_;

        public int Contract_number                   { get { return contract_number_; }set { contract_number_ = value; }}
        public int Nanny_ID                          { get { return Nanny_ID_; }set { Nanny_ID_ = value; }}
        public int Child_ID                          { get { return Child_ID_; }set { Child_ID_ = value; }}
        public bool introduce_meeting                { get { return introduce_meeting_; }set { introduce_meeting_ = value; }}
        public bool contract_signed                  { get { return contract_signed_; }set { contract_signed_ = value; }}
        public int Hourly_payment                    { get { return Hourly_payment_; }set { Hourly_payment_ = value; }}
        public double Monthly_payment                { get { return Monthly_payment_; }set { Monthly_payment_ = value; }}
        public MyEnum.Paymentmethode Paymentmethode  { get { return Paymentmethode_; }set { Paymentmethode_ = value; }}//monthly or houerly enum
        public DateTime startdate                    { get { return startdate_; }set { startdate_ = value; }}
        public DateTime enddate                      { get { return enddate_; }set { enddate_ = value; }}
        public double salary                         { get { return salary_; }set { salary_ = value; }}

        public Contract(params object[] parameter)
        {
            Contract_number++;
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
