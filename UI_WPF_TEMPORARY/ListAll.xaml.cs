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
using BL;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for ListAll.xaml
    /// </summary>
    public partial class ListAll : Window
    {
        static MyBL bl = new MyBL();
        static int Choosen;
        public ListAll(int choosen)
        {
            try
            {
                InitializeComponent();
                switch (choosen)
                {
                    case 0:
                        listofAll.ItemsSource = bl.getMotherList();
                    break;
                    case 1:
                        listofAll.ItemsSource = bl.getNannyList();
                        break;
                    case 2:
                        listofAll.ItemsSource = bl.getChildList();
                        break;
                    case 3:
                        listofAll.ItemsSource = bl.getContractList();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            Choosen = choosen;
        }

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow a = new AddWindow(Choosen);
            a.Show();
            this.Hide();
            a.Closed += new EventHandler(openwindow);
            
        }
        void openwindow(object sender, EventArgs e)
        {
            this.Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (Choosen)
                {
                    case 0:
                        bl.RemoveMother(((Mother)listofAll.SelectedItem).ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getMotherList();
                        break;
                    case 1:
                        bl.RemoveNanny(((Nanny)listofAll.SelectedItem).ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getNannyList();
                        break;
                    case 2:
                        bl.RemoveChild(((Child)listofAll.SelectedItem)._ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getChildList();
                        break;
                    case 3:
                        bl.RemoveContract(((Contract)listofAll.SelectedItem).Contract_number);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getContractList();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show( "No line was choosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
}
    }
}
