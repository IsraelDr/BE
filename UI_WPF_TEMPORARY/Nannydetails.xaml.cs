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
        public Window fr;
        public static BL_imp bl = new BL_imp();
        public bool isUpdate = false;
        public Nannydetails(Window f,Nanny nanny=null)
        {
            InitializeComponent();
            fr = f;
            isUpdate = false;
            if (nanny != null)
            {
                isUpdate = true;
                new_ID.Text = nanny.ID + "";
                new_LastName.Text = nanny.last_name;
                new_Firstname.Text = nanny.first_name;
                new_Birthdate.SelectedDate = nanny.Birthdate;
                new_Phonenumber.Text = nanny.PhoneNumber+"";
                new_Address.Text = nanny.address;
                new_elevator_exists.IsChecked = nanny.elevatorExists;
                new_Floor.Text = nanny.Floor + "";
                new_experience.Text = nanny.experience + "";
                new_Max_Num_Kids.Text = nanny.Max_number_kids + "";
                new_min_age.Text = nanny.Min_age + "";
                new_max_age.Text = nanny.Max_age + "";
                possible_hourly_rate.IsChecked = nanny.Possible_Hourly_rate;
                new_hourrate.Text = nanny.Hourly_rate+"";
                new_monthlyrate.Text = nanny.Monthly_rate + "";
                new_Sunday.IsChecked = nanny.Working_days[0];
                new_Monday.IsChecked = nanny.Working_days[1];
                new_Tuesday.IsChecked = nanny.Working_days[2];
                new_Wednesday.IsChecked = nanny.Working_days[3];
                new_Thursday.IsChecked = nanny.Working_days[4];
                new_Friday.IsChecked = nanny.Working_days[5];
                new_Saturday.IsChecked = nanny.Working_days[6];
                new_Sunday_start.Time = new RoyT.TimePicker.DigitalTime(21,00);   
                new_Sunday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[0, 1].Hours, nanny.Daily_Working_hours[0, 1].Minutes);
                new_Monday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[1, 0].Hours, nanny.Daily_Working_hours[1, 0].Minutes);
                new_Monday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[1, 1].Hours, nanny.Daily_Working_hours[1, 1].Minutes);
                new_Tuesday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[2, 0].Hours, nanny.Daily_Working_hours[2, 0].Minutes);
                new_Tuesday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[2, 1].Hours, nanny.Daily_Working_hours[2, 1].Minutes);
                new_Wednesday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[3, 0].Hours, nanny.Daily_Working_hours[3, 0].Minutes);
                new_Wednesday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[3, 1].Hours, nanny.Daily_Working_hours[3, 1].Minutes);
                new_Thursday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[4, 0].Hours, nanny.Daily_Working_hours[4, 0].Minutes);
                new_Thursday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[4, 1].Hours, nanny.Daily_Working_hours[4, 1].Minutes);
                new_Friday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[5, 0].Hours, nanny.Daily_Working_hours[5, 0].Minutes);
                new_Friday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[5, 1].Hours, nanny.Daily_Working_hours[5, 1].Minutes);
                new_Saturday_start.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[6, 0].Hours, nanny.Daily_Working_hours[6, 0].Minutes);
                new_Saturday_end.Time = new RoyT.TimePicker.DigitalTime(nanny.Daily_Working_hours[6, 1].Hours, nanny.Daily_Working_hours[6, 1].Minutes);
                vacationmethod.Text = nanny.Vacation_days.ToString();
                new_recommendations.Text = nanny.Recommendations;
                new_additional_info.Text = nanny.Additional_Info+"";
                news_kidsCount.Text = nanny.kidsCount.ToString();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Nanny newNanny = new Nanny(new_ID.Text, new_LastName.Text, new_Firstname.Text
                                        , new_Birthdate.Text, new_Phonenumber.Text, new_Address.Text,
                                        new_elevator_exists.IsChecked == true,
                                        new_Floor.Text, new_experience.Text, new_Max_Num_Kids.Text,
                                        new_min_age.Text, new_max_age.Text, possible_hourly_rate.IsChecked == true,
                                        new_hourrate.Text, new_monthlyrate.Text,
                                        new bool[] {new_Sunday.IsChecked==true, new_Monday.IsChecked == true ,
                                    new_Tuesday.IsChecked==true,new_Wednesday.IsChecked==true,new_Thursday.IsChecked==true,
                                    new_Friday.IsChecked==true,new_Saturday.IsChecked==true},
                                        new TimeSpan[,] { {new_Sunday_start.Time.ToTimeSpan(),new_Sunday_end.Time.ToTimeSpan() },
                                    {new_Monday_start.Time.ToTimeSpan(),new_Monday_end.Time.ToTimeSpan() },
                                    {new_Tuesday_start.Time.ToTimeSpan(),new_Tuesday_end.Time.ToTimeSpan() },
                                    {new_Wednesday_start.Time.ToTimeSpan(),new_Wednesday_end.Time.ToTimeSpan() },
                                    {new_Thursday_start.Time.ToTimeSpan(),new_Thursday_end.Time.ToTimeSpan() },
                                    {new_Friday_start.Time.ToTimeSpan(),new_Friday_end.Time.ToTimeSpan() },
                                    {new_Saturday_start.Time.ToTimeSpan(),new_Saturday_end.Time.ToTimeSpan() }},
                                        vacationmethod.Text, new_recommendations.Text, new_additional_info.Text,
                                        news_kidsCount.Text);
                if (isUpdate)
                    bl.UpdateNanny(newNanny);
                else
                    bl.AddNanny(newNanny);
                fr.Close();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
