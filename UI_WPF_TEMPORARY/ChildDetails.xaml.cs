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
using System.Text.RegularExpressions;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for ChildDetails.xaml
    /// </summary>
    public partial class ChildDetails : UserControl
    {
        //static BL_imp bl = new BL_imp();
        public bool isUpdate = false;
        public Window fr;
        public Child child;
        public IBL bl;
                
        public ChildDetails(Window f,Child a=null)
        {
            InitializeComponent();
            bl = FactoryBL.IBLInstance;
            child = a;
            fr = f;
            isUpdate = false;
            var values = from Mother moth in bl.getMotherList()
                         select new { ID = moth.ID, Name = moth.Firstname + " " + moth.Lastname };
            foreach (var value in values)
            {
                new_IDmother.Items.Add(value);
            }
            new_IDmother.DisplayMemberPath = "Name";
            new_IDmother.SelectedValuePath = "ID";
            if (a!=null)
            {
                isUpdate = true;
                //new_ID.Text = a.ID+"";
                //new_IDmother.Text = a.Mother_ID + "";
                //new_Name.Text = a.name;
                //new_Birthdate.SelectedDate = a.Birthdate;
                //new_specialneeds.IsChecked = (a.SpecialNeeds==true);

            }
            else
            {
                child = new Child();
            }
            this.DataContext = child;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                /*Child chil = new Child(new_ID.Text, new_IDmother.Text,
                                    new_Name.Text,
                                    new_Birthdate.SelectedDate, new_specialneeds.IsChecked == true);*/
                if (isUpdate)
                    bl.UpdateChild(child);
                else
                    bl.AddChild(child);

                fr.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void new_ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = (regex.IsMatch(e.Text) ||
                        (new_ID.Text.ToString().Count() > 8)
                        /* ||(new_ID.Text.ToString().Count() == 0 && e.Text[0] != '0')*/);
        }
    }
}
