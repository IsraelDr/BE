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
        Contract contr;
        public ContractDetails(Window f, Contract contract = null, bool isSaveable=true)
        {
            InitializeComponent();
            if (isSaveable == false)
                Savebutton.Visibility = Visibility.Collapsed;
            var values = from Mother moth in bl.getMotherList()
                         select new { ID = moth.ID, Name = moth.Firstname + " "+moth.Lastname };
            foreach (var value in values)
            {
                listofMothers.Items.Add(value);
            }
            listofMothers.DisplayMemberPath = "Name";
            listofMothers.SelectedValuePath = "ID";
            var paymentmethods = from Enum e in Enum.GetValues(typeof(MyEnum.Paymentmethode))
                                 select new { ID = e, Name = e.ToString() };
            foreach (var value in paymentmethods)
            {
                paymentmethod.Items.Add(value);
            }
            paymentmethod.DisplayMemberPath = "Name";
            paymentmethod.SelectedValuePath = "ID";
            fr = f;
            isUpdate = false;
            nannysoptiongrid.ItemsSource = null;
            if (contract != null)
            {
                contr = contract;
                isUpdate = true;
                listofMothers.SelectedValue = bl.GetChildById(contract.Child_ID).Mother_ID;
                listofChildren.SelectedValue = contract.Child_ID;
                paymentmethod.SelectedValue = contract.Paymentmethode;
                introduce_meeting.IsChecked = contract.introduce_meeting ? true : false;
                is_signed.IsChecked = contract.contract_signed? true : false;
                workbegindate.SelectedDate = contract.startdate;
                workenddate.SelectedDate = contract.enddate;
                foreach (var item in nannysoptiongrid.ItemsSource)
                {
                    if (((PriorityNanny)item).ID == contract.Nanny_ID)
                        nannysoptiongrid.SelectedItem = (PriorityNanny)item;
                        
                }
            }
        }

        private void listofMothers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int motherid;
                nannysoptiongrid.ItemsSource = null;
                nannysoptiongrid.AutoGeneratingColumn += nannysoptiongrid_PriorityNannyGeneratingColumns;
                if (isUpdate)
                    motherid = bl.GetChildById(contr.Child_ID).Mother_ID;
                else
                    motherid = int.Parse((listofMothers.SelectedValue).ToString());
                nannysoptiongrid.ItemsSource = bl.PriorityNannyList(bl.GetMotherById(motherid));
                nannysoptiongrid.Items.Refresh();
                listofChildren.Items.Clear();
                var values = from Child child in bl.getChildList()
                             where child.Mother_ID == motherid
                             select new { ID = child.ID, Name = child.name };
                foreach (var value in values)
                {
                    listofChildren.Items.Add(value);
                }
                listofChildren.DisplayMemberPath = "Name";
                listofChildren.SelectedValuePath = "ID";
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
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
                    throw new Exception("One of the checkboxes was not clicked!!");
                Contract contract = new Contract(((PriorityNanny)(nannysoptiongrid.SelectedItem)).ID, listofChildren.SelectedValue, introduce_meeting.IsChecked,
                                            is_signed.IsChecked, ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Hourly_rate,
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Monthly_rate,
                                            (MyEnum.Paymentmethode)Enum.Parse(typeof(MyEnum.Paymentmethode),paymentmethod.Text),
                                            Convert.ToDateTime(workbegindate.SelectedDate), Convert.ToDateTime(workenddate.SelectedDate),
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Salary, ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Distance);
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

        private void nannysoptiongrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nanny nanny = bl.GetNannyById(((Nanny)nannysoptiongrid.SelectedItem).ID);
            UpdateWindow a = new UpdateWindow(1, nanny,false);
            a.Show();
            fr.Hide();
            a.Closed += new EventHandler(openwindow);
        }
        private void openwindow(object sender, EventArgs e)
        {
            fr.Show();
            
        }
    }
}
