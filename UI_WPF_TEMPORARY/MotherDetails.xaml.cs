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
        public DigitalTime Time    { get { return new DigitalTime(12, 00); } set { } }
        Mother mother;
        System.Threading.Thread t=null;
        T details;
        bool isUpdate = false;
        public MotherDetails(Window f,Mother m=null)
        {
            InitializeComponent();
            bl = FactoryBL.IBLInstance;

            this.mother = m;
            if (m == null)
                details = new T(new Mother(), this);
            else
                details = new T(mother, this);
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
                //new_Address.Text = mother.Adress;
                //new_surrounding_address.Text = mother.surrounding_adress + "";
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
                
                /*Mother mother = new Mother(/*new_ID.Textint.Parse( new_ID.Text),new_LastName.Text, new_Firstname.Text,
                                            new_Phonenumber.Text, new_Address.Text,
                                            new_surrounding_address.Text,
                                            new bool[] {new_Sunday.IsChecked==true, new_Monday.IsChecked == true ,
                                    new_Tuesday.IsChecked==true,new_Wednesday.IsChecked==true,new_Thursday.IsChecked==true,
                                    new_Friday.IsChecked==true,new_Saturday.IsChecked==true},
                                            new TimeSpan[][] { new TimeSpan[]{new_Sunday_start.Time.ToTimeSpan(),new_Sunday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Monday_start.Time.ToTimeSpan(),new_Monday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Tuesday_start.Time.ToTimeSpan(),new_Tuesday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Wednesday_start.Time.ToTimeSpan(),new_Wednesday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Thursday_start.Time.ToTimeSpan(),new_Thursday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Friday_start.Time.ToTimeSpan(),new_Friday_end.Time.ToTimeSpan() },
                                    new TimeSpan[]{new_Saturday_start.Time.ToTimeSpan(),new_Saturday_end.Time.ToTimeSpan() }},
                                    new_comment.Text,/*new_paymentmethode.Text/(MyEnum.Paymentmethode)Enum.Parse             ( typeof(MyEnum.Paymentmethode), new_paymentmethode.Text));*/
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

        private void new_Address_TextChanged(object sender, TextChangedEventArgs e)
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
            if(s.Count()>0)
            {
                adress_suggestion.ItemsSource = s;
                adress_suggestion.Visibility = Visibility.Visible;
            }
            else
            {
                adress_suggestion.Visibility = Visibility.Collapsed;
                adress_suggestion.ItemsSource = null;
            }

        }

        private void adress_suggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(adress_suggestion.ItemsSource!=null)
            {
                adress_suggestion.Visibility = Visibility.Collapsed;
                new_Address.TextChanged -= new TextChangedEventHandler(new_Address_TextChanged);
                if(adress_suggestion.SelectedIndex!=-1)
                {
                    new_Address.Text = adress_suggestion.SelectedItem.ToString();
                }
                new_Address.TextChanged += new TextChangedEventHandler(new_Address_TextChanged);
                new_Address.Focus();

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

    public class T
    {
        public Mother info { get; set; } 
        public MotherDetails workingHours { get; set; }
        public  T(Mother d,MotherDetails a) { info = d; workingHours = a; }
    }
}
