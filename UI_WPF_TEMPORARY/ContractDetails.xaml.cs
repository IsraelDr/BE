using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for ContractDetails.xaml
    /// </summary>
    public partial class ContractDetails : UserControl
    {
        static BL_imp bl = new BL_imp();
        static Window fr;
        bool isUpdate = false;
        public ContractDetails(Window f, Contract mother = null)
        {
            InitializeComponent();
            fr = f;
            isUpdate = false;
            nannysoptiongrid.ItemsSource = null;
            nannysoptiongrid.ItemsSource = bl.getNannyList();
            if (mother != null)
            {
                isUpdate = true;
            }
        }
    }
}
