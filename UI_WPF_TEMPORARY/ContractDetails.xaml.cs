﻿using System;
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
using System.Windows.Media.Animation;

namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for ContractDetails.xaml
    /// </summary>
    public partial class ContractDetails : UserControl
    {
        //static BL_imp bl = new BL_imp();
        public IBL bl;
        static Window fr;
        //ContractT details;
        bool isUpdate = false;
        Contract contr;

        public ContractDetails(Window f, Contract contract = null, bool isSaveable = true)
        {
            InitializeComponent();
            bl = FactoryBL.IBLInstance;
            if (isSaveable == false)
                Savebutton.Visibility = Visibility.Collapsed;
            var values = from Mother moth in bl.getMotherList()
                         select new { ID = moth.ID, Name = moth.Firstname + " " + moth.Lastname };
            foreach (var value in values)
            {
                listofMothers.Items.Add(value);
            }
            nannysoptiongrid.AutoGeneratingColumn += nannysoptiongrid_PriorityNannyGeneratingColumns;
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
            nannysoptiongrid.SelectedValuePath = "Nanny_ID";
            fr = f;
            workbegindate.DisplayDateStart = DateTime.Today;
            workenddate.DisplayDateStart = DateTime.Today;
            //this.contr = contract;
            if (contract == null)
                contr = new Contract();
            //details = new ContractT(new Contract(), this);
            else
                contr = contract;
            //details = new ContractT(contr, this);
            isUpdate = false;
            this.DataContext = contr;
            nannysoptiongrid.ItemsSource = null;
            if (contract != null)
            {
                contr = contract;
                isUpdate = true;
                List<PriorityNanny> lst = new List<PriorityNanny>();
                Nanny n = (Nanny)bl.GetNannyById(contr.Nanny_ID);
                PriorityNanny temp = new PriorityNanny(n);
                temp.Distance = contr.distance;
                temp.Salary = contr.salary;
                lst.Add(temp);
                nannysoptiongrid.ItemsSource = lst;
                //listofChildren.Items.Add(bl.GetChildById(contr.Child_ID).name);
                //listofChildren.SelectedItem = contr.Child_ID;

                var values2 = from Child child in bl.getChildList()
                              where child.Mother_ID == contr.Mother_ID
                              select new { ID = child.ID, Name = child.name };
                foreach (var value in values2)
                {
                    listofChildren.Items.Add(value);
                }
                listofChildren.DisplayMemberPath = "Name";
                listofChildren.SelectedValuePath = "ID";
                listofChildren.SelectedValue = contr.Child_ID;
                listofChildren.IsEnabled = false;
            }
        }

        private void listofMothers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (isUpdate)
                {
                    listofMothers.IsEnabled = false;
                    return;
                }
                int motherid;
                nannysoptiongrid.ItemsSource = null;
                nannysoptiongrid.AutoGeneratingColumn += nannysoptiongrid_PriorityNannyGeneratingColumns;
                if (isUpdate && listofMothers.SelectedValue == null)
                {
                    motherid = bl.GetChildById(contr.Child_ID).Mother_ID;
                }
                else
                {
                    motherid = int.Parse((listofMothers.SelectedValue).ToString());
                    listofChildren.SelectedItem = null;
                    nannysoptiongrid.SelectedItem = null;
                }
                listofChildren.Items.Clear();
                int countfailed = 0;
                List<PriorityNanny> lst = bl.PriorityNannyList(bl.GetMotherById(motherid),ref countfailed);
                nannysoptiongrid.ItemsSource = lst;
                nannysoptiongrid.Items.Refresh();
                var values = from Child child in bl.getChildList()
                             where child.Mother_ID == motherid
                             select new { ID = child.ID, Name = child.name };
                foreach (var value in values)
                {
                    listofChildren.Items.Add(value);
                }
                listofChildren.DisplayMemberPath = "Name";
                listofChildren.SelectedValuePath = "ID";
                if (countfailed > 0)
                    throw new Exception("Failed "+ countfailed + " times to calculate the distance!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void nannysoptiongrid_PriorityNannyGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Working_days" || e.PropertyName == "Daily_Working_hours" || e.PropertyName == "Vacation_days" || e.PropertyName == "Birthdate")
                e.Cancel = true;
            if (e.PropertyName == "fideback")
            {
                e.Column.Header = "Feedback";
                e.Column.Width = 60;
            }
            if (e.PropertyName == "Salary")
            {
                e.Column.Header = "Salary[₪]";
                e.Column.Width = 60;
            }
            if (e.PropertyName == "Distance")
            {
                e.Column.Header = "Distance[km]";
                e.Column.Width = 80;
            }
            if (e.PropertyName == "Hourly_rate")
                e.Cancel = true;
            if (e.PropertyName == "Monthly_rate")
                e.Cancel = true;
            if (e.PropertyName == "Recommendations")
                e.Cancel = true;
            if (e.PropertyName == "Additional_Info")
                e.Cancel = true;
            if (e.PropertyName == "Possible_Hourly_rate")
                e.Cancel = true;
            if (e.PropertyName == "Floor")
                e.Column.Width = 40;
            if (e.PropertyName == "elevatorExists")
            {
                e.Column.Header = "Elevator";
                e.Column.Width = 60;
            }
            if (e.PropertyName == "PhoneNumber")
                e.Column.Header = "Phone";
            if (e.PropertyName == "Min_age")
                e.Column.Header = "Minage[Month]";
            if (e.PropertyName == "Max_age")
                e.Column.Header = "Maxage[Month]";
            if (e.PropertyName == "kidsCount")
            {
                e.Column.Header = "Class";
                e.Column.Width = 40;
            }
            if (e.PropertyName == "Max_number_kids")
            {
                e.Column.Header = "Capacity";
                e.Column.Width = 55;
            }






    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (introduce_meeting.IsChecked == false || is_signed.IsChecked == false)
                    throw new Exception("One of the checkboxes was not clicked!!");
                /*Contract contract = new Contract(((PriorityNanny)(nannysoptiongrid.SelectedItem)).ID, listofMothers.SelectedValue, listofChildren.SelectedValue, introduce_meeting.IsChecked,
                                            is_signed.IsChecked, ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Hourly_rate,
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Monthly_rate,
                                            (MyEnum.Paymentmethode)Enum.Parse(typeof(MyEnum.Paymentmethode),paymentmethod.Text),
                                            Convert.ToDateTime(workbegindate.SelectedDate), Convert.ToDateTime(workenddate.SelectedDate),
                                            ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Salary, ((PriorityNanny)(nannysoptiongrid.SelectedItem)).Distance,
                                            bl.checkForDiscunt((Nanny)(nannysoptiongrid.SelectedItem), bl.GetMotherById((int)listofMothers.SelectedValue)));
                */
                if (isUpdate)
                    bl.UpdateContract(contr);
                else
                    bl.AddContract(contr);
                fr.Close();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nannysoptiongrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Nanny nanny = bl.GetNannyById((int)nannysoptiongrid.SelectedItem);
                UpdateWindow a = new UpdateWindow(1, nanny, false);
                a.Show();
                fr.Hide();
                a.Closed += new EventHandler(openwindow);
            }
            catch (Exception d)
            {
                throw d;
            }
        }
        private void openwindow(object sender, EventArgs e)
        {
            fr.Show();

        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Savebutton.Height += 5;
            Savebutton.Width += 5;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Savebutton.Height -= 5;
            Savebutton.Width -= 5;
        }

        private void nannysoptiongrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUpdate)
            {
                //nannysoptiongrid.IsEnabled = false;
                return;
            }
            List<PriorityNanny> a = (List<PriorityNanny>)nannysoptiongrid.ItemsSource;
            PriorityNanny temp = (from A in a
                                  where A.ID == (int)(nannysoptiongrid.SelectedItem)
                                  select A).FirstOrDefault();
            this.contr.Monthly_payment = temp.Monthly_rate;
            this.contr.Hourly_payment = temp.Hourly_rate;
            this.contr.discount = bl.checkForDiscunt((Nanny)temp, bl.GetMotherById(this.contr.Mother_ID));
            this.contr.salary = temp.Salary;
            this.contr.distance = temp.Distance;
        }
        private void OnWorkBeginSelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            this.workenddate.SelectedDate = workbegindate.SelectedDate;
        }

        private void date_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void introduce_meeting_Checked(object sender, RoutedEventArgs e)
        {
            introduce_meeting.BorderBrush = Brushes.Black ;
        }

        private void introduce_meeting_Unchecked(object sender, RoutedEventArgs e)
        {
            introduce_meeting.BorderBrush = Brushes.Red;
        }

        private void is_signed_Unchecked(object sender, RoutedEventArgs e)
        {
            is_signed.BorderBrush = Brushes.Red;
        }

        private void is_signed_Checked(object sender, RoutedEventArgs e)
        {
            is_signed.BorderBrush = Brushes.Black; 
        }

        private void listofChildren_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listofChildren.SelectedItem == null)
                return;
            try
            {
                Child child = bl.GetChildById((int)listofChildren.SelectedValue);
                UpdateWindow a = new UpdateWindow(2, child, false);
                a.Show();
                fr.Hide();
                a.Closed += new EventHandler(openwindow);
            }
            catch (Exception d)
            {
                throw d;
            }
        }

        private void listofMothers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listofMothers.SelectedItem == null)
                return;
            try
            {
                Mother mothers = bl.GetMotherById((int)listofMothers.SelectedValue);
                UpdateWindow a = new UpdateWindow(0, mothers, false);
                a.Show();
                fr.Hide();
                a.Closed += new EventHandler(openwindow);
            }
            catch (Exception d)
            {
                throw d;
            }
        }
    }

}
