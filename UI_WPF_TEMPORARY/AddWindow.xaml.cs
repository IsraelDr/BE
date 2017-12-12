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
using System.Windows.Shapes;

namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(int choosen)
        {
            InitializeComponent();
            switch (choosen)
            {
                case 0:
                    //listofAll.ItemsSource = bl.getMotherList();
                    break;
                case 1:
                    AddGrid.Children.Add(new Nannydetails());
                    break;
                case 2:
                    //listofAll.ItemsSource = bl.getChildList();
                    break;
                case 3:
                    //listofAll.ItemsSource = bl.getContractList();
                    break;
            }
        }
    }
}
