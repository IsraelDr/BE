using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UI_WPF_TEMPORARY
{
    class converter : IValueConverter
    {
        //static BL_imp bl = new BL_imp();
        public IBL bl = FactoryBL.IBLInstance;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Mother m = bl.GetMotherById(bl.GetChildById((int)value).Mother_ID);
                return m.Firstname + " " + m.Lastname;
            }
            catch (Exception)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }


    }
}
