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
using RoyT.TimePicker;
using BL;
using System.Text.RegularExpressions;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for MotherDetails.xaml
    /// </summary>
    public partial class MotherDetails : UserControl
    {
        //static BL_imp bl = new BL_imp();
        public IBL bl; 
        static Window fr;
        public DigitalTime MinTime { get { return new DigitalTime(00, 00); } set { } }
        public DigitalTime MaxTime { get { return new DigitalTime(22, 00);}  set { } }
        public DigitalTime Time    { get { return new DigitalTime(8, 00); } set { } }
        Mother mother;
        System.Threading.Thread t=null;
        MotherT details;
        bool isUpdate = false;
        public MotherDetails(Window f,Mother m=null, bool IsSaveable = true)
        {
            InitializeComponent();
            bl = FactoryBL.IBLInstance;
            if (IsSaveable == false)
                Save.Visibility = Visibility.Collapsed;
            this.mother = m;
            if (m == null)
                details = new MotherT(new Mother(), this);
            else
                details = new MotherT(mother, this);
            /*this.DataContext = new
                        {
                            info = mother,
                            workingHours = this,
                        };*/
            this.DataContext = details;
            var values = from Enum e in Enum.GetValues(typeof(MyEnum.Paymentmethode))
                         select new { ID = e, Name = e.ToString() };
            foreach (var value in values)
            {
                new_paymentmethode.Items.Add(value.Name);
            }
            //new_paymentmethode.DisplayMemberPath = "Name";
            //new_paymentmethode.SelectedValuePath = "ID";
            //new_paymentmethode.SelectedItem = MyEnum.Paymentmethode.hourly.ToString();
            fr = f;
            //new_Sunday_start.MinTime = new DigitalTime(00, 00);
            //new_Sunday_end.MinTime = new DigitalTime(00, 00);
            //new_Monday_start.MinTime = new DigitalTime(00, 00);
            //new_Monday_end.MinTime = new DigitalTime(00, 00);
            //new_Tuesday_start.MinTime = new DigitalTime(00, 00);
            //new_Tuesday_end.MinTime = new DigitalTime(00, 00);
            //new_Wednesday_start.MinTime = new DigitalTime(00, 00);
            //new_Wednesday_end.MinTime = new DigitalTime(00, 00);
            //new_Thursday_start.MinTime = new DigitalTime(00, 00);
            //new_Thursday_end.MinTime = new DigitalTime(00, 00);
            //new_Friday_start.MinTime = new DigitalTime(00, 00);
            //new_Friday_end.MinTime = new DigitalTime(00, 00);
            //new_Saturday_start.MinTime = new DigitalTime(00, 00);
            //new_Saturday_end.MinTime = new DigitalTime(00, 00);

            //new_Sunday_start.MaxTime = new DigitalTime(23, 59);
            //new_Sunday_end.MaxTime = new DigitalTime(23, 59);
            //new_Monday_start.MaxTime = new DigitalTime(23, 59);
            //new_Monday_end.MaxTime = new DigitalTime(23, 59);
            //new_Tuesday_start.MaxTime = new DigitalTime(23, 59);
            //new_Tuesday_end.MaxTime = new DigitalTime(23, 59);
            //new_Wednesday_start.MaxTime = new DigitalTime(23, 59);
            //new_Wednesday_end.MaxTime = new DigitalTime(23, 59);
            //new_Thursday_start.MaxTime = new DigitalTime(23, 59);
            //new_Thursday_end.MaxTime = new DigitalTime(23, 59);
            //new_Friday_start.MaxTime = new DigitalTime(23, 59);
            //new_Friday_end.MaxTime = new DigitalTime(23, 59);
            //new_Saturday_start.MaxTime = new DigitalTime(23, 59);
            //new_Saturday_end.MaxTime = new DigitalTime(23, 59);

            //new_Sunday_start.Time = new DigitalTime(12, 00);
            //new_Sunday_end.Time = new DigitalTime(12, 00);
            //new_Monday_start.Time = new DigitalTime(12, 00);
            //new_Monday_end.Time = new DigitalTime(12, 00);
            //new_Tuesday_start.Time = new DigitalTime(12, 00);
            //new_Tuesday_end.Time = new DigitalTime(12, 00);
            //new_Wednesday_start.Time = new DigitalTime(12, 00);
            //new_Wednesday_end.Time = new DigitalTime(12, 00);
            //new_Thursday_start.Time = new DigitalTime(12, 00);
            //new_Thursday_end.Time = new DigitalTime(12, 00);
            //new_Friday_start.Time = new DigitalTime(12, 00);
            //new_Friday_end.Time = new DigitalTime(12, 00);
            //new_Saturday_start.Time = new DigitalTime(12, 00);
            //new_Saturday_end.Time = new DigitalTime(12, 00);
            isUpdate = false;
            if(m!=null)
            {
                isUpdate = true;
                //new_ID.Text = mother.ID + "";
                //new_LastName.Text = mother.Lastname;
                //new_Firstname.Text = mother.Firstname;
                //new_Phonenumber.Text = mother.Phonenumber + "";
                //new_Address.Text = mother.Address;
                //new_surrounding_address.Text = mother.surrounding_Address + "";
                //new_Sunday.IsChecked = mother.nanny_required[0];
                //new_Monday.IsChecked = mother.nanny_required[1];
                //new_Tuesday.IsChecked = mother.nanny_required[2];
                //new_Wednesday.IsChecked = mother.nanny_required[3];
                //new_Thursday.IsChecked = mother.nanny_required[4];
                //new_Friday.IsChecked = mother.nanny_required[5];
                //new_Saturday.IsChecked = mother.nanny_required[6];
                //new_Sunday_start.Time = new DigitalTime(mother.daily_Nanny_required[0][0].Hours, mother.daily_Nanny_required[0][0].Minutes);
                //new_Sunday_end.Time = new DigitalTime(mother.daily_Nanny_required[0][1].Hours, mother.daily_Nanny_required[0][1].Minutes);
                //new_Monday_start.Time = new DigitalTime(mother.daily_Nanny_required[1][0].Hours, mother.daily_Nanny_required[1][0].Minutes);
                //new_Monday_end.Time = new DigitalTime(mother.daily_Nanny_required[1][1].Hours, mother.daily_Nanny_required[1][1].Minutes);
                //new_Tuesday_start.Time = new DigitalTime(mother.daily_Nanny_required[2][0].Hours, mother.daily_Nanny_required[2][0].Minutes);
                //new_Tuesday_end.Time = new DigitalTime(mother.daily_Nanny_required[2][1].Hours, mother.daily_Nanny_required[2][1].Minutes);
                //new_Wednesday_start.Time = new DigitalTime(mother.daily_Nanny_required[3][0].Hours, mother.daily_Nanny_required[3][0].Minutes);
                //new_Wednesday_end.Time = new DigitalTime(mother.daily_Nanny_required[3][1].Hours, mother.daily_Nanny_required[3][1].Minutes);
                //new_Thursday_start.Time = new DigitalTime(mother.daily_Nanny_required[4][0].Hours, mother.daily_Nanny_required[4][0].Minutes);
                //new_Thursday_end.Time = new DigitalTime(mother.daily_Nanny_required[4][1].Hours, mother.daily_Nanny_required[4][1].Minutes);
                //new_Friday_start.Time = new DigitalTime(mother.daily_Nanny_required[5][0].Hours, mother.daily_Nanny_required[5][0].Minutes);
                //new_Friday_end.Time = new DigitalTime(mother.daily_Nanny_required[5][1].Hours, mother.daily_Nanny_required[5][1].Minutes);
                //new_Saturday_start.Time = new DigitalTime(mother.daily_Nanny_required[6][0].Hours, mother.daily_Nanny_required[6][0].Minutes);
                //new_Saturday_end.Time = new DigitalTime(mother.daily_Nanny_required[6][1].Hours, mother.daily_Nanny_required[6][1].Minutes);
                //new_comment.Text = mother.Comment;
                new_paymentmethode.Text = mother.Paymentmethode.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isUpdate)
                    bl.UpdateMother(details.info);
                else
                    bl.AddMother(details.info);
                fr.Close();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            TimePickerSlider slider;
            if (((CheckBox)(sender)).IsChecked == true)
            {
                slider = (TimePickerSlider)FindName("new_" + ((CheckBox)(sender)).Content + "_start");
                slider.Visibility = Visibility.Visible;
                slider = (TimePickerSlider)FindName("new_" + ((CheckBox)(sender)).Content + "_end");
                slider.Visibility = Visibility.Visible;
            }
            else
            {
                slider = (TimePickerSlider)FindName("new_" + ((CheckBox)(sender)).Content + "_start");
                slider.Visibility = Visibility.Collapsed;
                slider = (TimePickerSlider)FindName("new_" + ((CheckBox)(sender)).Content + "_end");
                slider.Visibility = Visibility.Collapsed;
            }

        }
        private void new_Phonenumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = (regex.IsMatch(e.Text) ||
                        (new_Phonenumber.Text.ToString().Count() > 9) ||
                        (new_Phonenumber.Text.ToString().Count() == 0 && e.Text[0] != '0'));
        }

        private void new_ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = (regex.IsMatch(e.Text) ||
                        (new_ID.Text.ToString().Count() > 8)
                        /* ||(new_ID.Text.ToString().Count() == 0 && e.Text[0] != '0')*/);
        }
        private void new_surrounding_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            new_Address_TextChangedHelp(surround_Address_suggestion, new_surrounding_address);
        }
        private void new_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            new_Address_TextChangedHelp(Address_suggestion,new_Address);
        }
        private void new_Address_TextChangedHelp(ListBox Address_suggestion, TextBox new_Address)
        { 
            List<String> s = new List<String>();
            string str = new_Address.Text;
            
            if (t!=null&&t.IsAlive)
                t.Abort();
            t = new System.Threading.Thread(() =>
            {
                try
                {
                     s = BL.BL_imp.GetPlaceAutoComplete(str);
                }
                catch (Exception f)
                {
                    // fix Nanny?
                    int a = 5;
                }
            });
            t.Start();
            t.Join();
            if(s.Contains(str))
            {
                new_Address.Text = str;
                Address_suggestion.Visibility = Visibility.Collapsed;
                Address_suggestion.ItemsSource = null;
                return;
            }
            if(s.Count()>0)
            {
                Address_suggestion.ItemsSource = s;
                Address_suggestion.Visibility = Visibility.Visible;
            }
            else
            {
                Address_suggestion.Visibility = Visibility.Collapsed;
                Address_suggestion.ItemsSource = null;
            }

        }
        private void surround_Address_suggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Address_suggestion_SelectionChangedhelp(surround_Address_suggestion, new_surrounding_address, new TextChangedEventHandler(new_surrounding_address_TextChanged));
        }
        private void Address_suggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Address_suggestion_SelectionChangedhelp(Address_suggestion, new_Address, new TextChangedEventHandler(new_Address_TextChanged));
        }
        private void Address_suggestion_SelectionChangedhelp(ListBox suggestion, TextBox Address, TextChangedEventHandler a)
        { 
            if (suggestion.ItemsSource!=null)
            {
                suggestion.Visibility = Visibility.Collapsed;
                Address.TextChanged -= a;
                if(suggestion.SelectedIndex!=-1)
                {
                    Address.Text = suggestion.SelectedItem.ToString();
                }
                Address.TextChanged += a;
                Address.Focus();

            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Save.Height += 5;
            Save.Width += 5;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Save.Height -= 5;
            Save.Width -= 5;
        }

    }

    public class MotherT
    {
        public Mother info { get; set; } 
        public MotherDetails workingHours { get; set; }
        public  MotherT(Mother d,MotherDetails a) { info = d; workingHours = a; }
    }
}
