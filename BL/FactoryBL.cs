﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        //to build only on oject each time
        private static IBL bl_instance;

        private FactoryBL() { }
        static FactoryBL() { bl_instance = new BL_imp(); } // called once at program startup

        public static IBL IBLInstance { get { return bl_instance; } }
    }
}
