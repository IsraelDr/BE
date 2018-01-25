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
using BE;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow(int choice,object a,bool isSaveable=true)
        {
            InitializeComponent();
            switch (choice)
            {
                case 0:
                    Updategrid.Children.Add(new MotherDetails(this, (Mother)a, isSaveable));
                    break;
                case 1:
                    Updategrid.Children.Add(new Nannydetails(this,(Nanny)a, isSaveable));
                    break;
                case 2:
                    this.Height = 480;
                    this.Width = 300;
                    Updategrid.Children.Add(new ChildDetails(this,(Child)a, isSaveable));
                    break;
                case 3:
                    this.Height = 450;
                    this.Width = 1200;
                    Updategrid.Children.Add(new ContractDetails(this, (Contract)a));
                    break;
            }
        }
    }
}
