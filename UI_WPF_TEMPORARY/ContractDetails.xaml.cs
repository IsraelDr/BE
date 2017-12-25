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
            var values = from Mother moth in bl.getMotherList()
                         select new { ID = moth.ID, Name = moth.Firstname + " "+moth.Lastname };
            foreach (var value in values)
            {
                listofMothers.Items.Add(value.ID);
            }
            var paymentmethods = from Enum e in Enum.GetValues(typeof(MyEnum.Paymentmethode))
                                 select new { ID = e, Name = e.ToString() };
            foreach (var value in paymentmethods)
            {
                paymentmethod.Items.Add(value.Name);
            }
            fr = f;
            isUpdate = false;
            nannysoptiongrid.ItemsSource = null;
            
            //nannysoptiongrid.ItemsSource = bl.calculateDistance();
            if (mother != null)
            {
                isUpdate = true;
            }
        }

        private void listofMothers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nannysoptiongrid.ItemsSource = null;
            nannysoptiongrid.AutoGeneratingColumn += nannysoptiongrid_PriorityNannyGeneratingColumns;
            nannysoptiongrid.ItemsSource = bl.PriorityNannyList(bl.GetMotherById(int.Parse(listofMothers.SelectedItem.ToString())));
            nannysoptiongrid.Items.Refresh();
            listofChildren.Items.Clear();
            var values = from Child child in bl.getChildList()
                         where child.Mother_ID== int.Parse(listofMothers.SelectedItem.ToString())
                         select new { ID = child.ID, Name = child.name };
            foreach (var value in values)
            {
                listofChildren.Items.Add(value.Name);
            }
        }
        void nannysoptiongrid_PriorityNannyGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Working_days"|| e.PropertyName == "Daily_Working_hours" || e.PropertyName == "Vacation_days")
                e.Cancel = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (introduce_meeting.IsChecked == false || is_signed.IsChecked == false)
                    return;
                Contract contract = new Contract(((PriorityNanny)(nannysoptiongrid.SelectedItem)).ID, ((Child)(listofChildren.SelectedItem)).ID, introduce_meeting.IsChecked,
                                            is_signed.IsChecked, ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Hourly_rate,
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Monthly_rate,
                                            (MyEnum.Paymentmethode)Enum.Parse(typeof(MyEnum.Paymentmethode),paymentmethod.Text),
                                            Convert.ToDateTime(workbegindate.SelectedDate), Convert.ToDateTime(workenddate.SelectedDate),
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).salary);
                if (isUpdate)
                    bl.UpdateContract(contract);
                else
                    bl.AddContract(contract);
                fr.Close();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
