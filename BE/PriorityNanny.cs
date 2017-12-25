using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PriorityNanny:Nanny
    {
        //private Nanny nanny_;
        private double distance_;

        //public Nanny nanny { get; set;}
        public double distance { get; set; }
        public double salary { get; set; }
        public PriorityNanny(Nanny nan):base(nan){

        }
    }
}
