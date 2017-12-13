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
    /// Interaction logic for Nannydetails.xaml
    /// </summary>
    public partial class Nannydetails : UserControl
    {
        public Nannydetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nanny newNanny = new Nanny(new_ID.Text,new_LastName.Text,new_Firstname.Text
                                    ,new_Birthdate.Text,new_Phonenumber.Text,new_Address.Text,
                                    new_Floor.Text,new_experience.Text,new_Max_Num_Kids.Text,
                                    new_min_age.Text,new_max_age.Text,new_hourrate.Text,new_monthlyrate.Text,
                                    new bool[] {new_Sunday.IsChecked==true, new_Monday.IsChecked == true ,
                                    new_Tuesday.IsChecked==true,new_Wednesday.IsChecked==true,new_Thursday.IsChecked==true,
                                    new_Friday.IsChecked==true,new_Saturday.IsChecked==true}//,
                                    /*new string[,] { {new_Sunday_start,new_Sunday_end.Text },
                                    {new_Monday_start.Text,new_Mnday_end.Text },
                                    {new_Tuesday_start.Text,new_Tuesday_end.Text },
                                    {new_Wednesday_start.Text,new_Wednesday_end.Text },
                                    {new_Thursday_start.Text,new_Thursday_end.Text },
                                    {new_Friday_start.Text,new_Friday_end.Text },
                                    {new_Saturday_start.Text,new_Saturday_end.Text }}*/
                );
        }
    }
}
