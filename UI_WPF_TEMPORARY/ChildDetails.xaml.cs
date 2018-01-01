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
    /// Interaction logic for ChildDetails.xaml
    /// </summary>
    public partial class ChildDetails : UserControl
    {
        static BL_imp bl = new BL_imp();
        public bool isUpdate = false;
        public Window fr;
        public ChildDetails(Window f,Child a=null)
        {
            InitializeComponent();
            fr = f;
            isUpdate = false;
            if(a!=null)
            {
                isUpdate = true;
                new_ID.Text = a.ID+"";
                new_IDmother.Text = a.Mother_ID + "";
                new_Name.Text = a.name;
                new_Birthdate.SelectedDate = a.Birthdate;
                new_specialneeds.IsChecked = (a.SpecialNeeds==true);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Child chil = new Child(new_ID.Text, new_IDmother.Text,
                                    new_Name.Text,
                                    new_Birthdate.SelectedDate, new_specialneeds.IsChecked == true);

                if (isUpdate)
                    bl.UpdateChild(chil);
                else
                    bl.AddChild(chil);

                fr.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
