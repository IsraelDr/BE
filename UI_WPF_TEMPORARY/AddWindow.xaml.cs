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
                    AddGrid.Children.Add(new MotherDetails(this));
                    break;
                case 1:
                    AddGrid.Children.Add(new Nannydetails(this));
                    break;
                case 2:
                    this.Height = 480 ;
                    this.Width = 300;
                    AddGrid.Children.Add(new ChildDetails(this));
                    break;
                case 3:
                    this.Height = 700;
                    this.Width = 1200;
                    AddGrid.Children.Add(new ContractDetails(this));
                    break;
            }
        }
    }
}
