using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
     
        private static int contract_number_=10000003;
        private int Contract_ID_;
        private int Nanny_ID_;
        private int Child_ID_;
        private int Mother_ID_;
        private bool introduce_meeting_;
        private bool contract_signed_;
        private int Hourly_payment_;
        private double Monthly_payment_;
        private MyEnum.Paymentmethode Paymentmethode_;
        private DateTime startdate_;
        private DateTime enddate_;
        private double salary_;
        private double distance_;
        private bool discount_;
        

        public int     Contract_number                   { get { return contract_number_; }set { contract_number_ = value; }}
        public int Contract_ID
        {   get { return Contract_ID_; }
            set { Contract_number=Math.Max(Contract_number,value); Contract_ID_ = value; }}
        public int     Nanny_ID                          { get { return Nanny_ID_; }set { Nanny_ID_ = value; }}
        public int     Child_ID                          { get { return Child_ID_; }set { Child_ID_ = value; }}
        public int     Mother_ID                         { get { return Mother_ID_; } set { Mother_ID_ = value; } }

        public bool    introduce_meeting                { get { return introduce_meeting_; }set { introduce_meeting_ = value; }}
        public bool    contract_signed                  { get { return contract_signed_; }set { contract_signed_ = value; }}
        public int     Hourly_payment                    { get { return Hourly_payment_; }set { Hourly_payment_ = value; }}
        public double  Monthly_payment                { get { return Monthly_payment_; }set { Monthly_payment_ = value; }}
        public MyEnum.Paymentmethode Paymentmethode  { get { return Paymentmethode_; }set { Paymentmethode_ = value; }}//monthly or houerly enum
        public DateTime  startdate                    { get { return startdate_; }set { startdate_ = value; }}
        public DateTime  enddate                      { get { return enddate_; }set { enddate_ = value; }}
        public double    salary                         { get { return salary_; }set { salary_ = value; }}
        public double    distance                       { get { return distance_; } set { distance_ = value; } }
        public bool      discount                          { get { return discount_; } set { discount_ = value; } }
        public Contract(params object[] parameter)
        {
            Contract_number++;
            Contract_ID = Contract_number;
            Nanny_ID = (int)parameter[0];
            Child_ID = (int)parameter[1];
            Mother_ID = (int)parameter[2];
            introduce_meeting = (bool)parameter[3];
            contract_signed = (bool)parameter[4];
            Hourly_payment = (int)parameter[5];
            Monthly_payment = (int)parameter[6];
            Paymentmethode = (MyEnum.Paymentmethode)parameter[7];
            startdate = (DateTime)parameter[8];
            enddate = (DateTime)parameter[9];
            salary = (double)parameter[10];
            distance = double.Parse(parameter[11].ToString());
            discount=(bool)parameter[12];
        }
        public Contract()
        {
            Contract_number++;
            Contract_ID = Contract_number;
        }
        public override string ToString()
        {//using ToStringProperty() in Class Tools 
            return this.ToStringProperty();
        }
    }
}
