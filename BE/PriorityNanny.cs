using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// class of each special nanny that fits to a mother
    /// by prioritys, inheritance of nanny
    /// </summary>
    public class PriorityNanny:Nanny
    {
        //private Nanny nanny_;
        private double distance_;
        private double salary_;
        //public Nanny nanny { get; set;}
        public double Distance { get {return distance_; } set { distance_ = value; } }
        public double Salary { get { return salary_; } set { salary_ = value; } }
        public PriorityNanny(Nanny nan):base(nan){

        }
    }
}
