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
        MotherT details;
        bool isUpdate = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="m"></param>
        /// <param name="IsSaveable"></param>
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
            //new_paymentmethode.SelectedItem = MyEnum.Paymentmethode.hourly.ToString();
            fr = f;
            
            isUpdate = false;
            if(m!=null)
            {
                isUpdate = true;
               
                new_paymentmethode.Text = mother.Paymentmethode.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //digits and 10 numbers only on first number "0" 
               Regex regex = new Regex("[^0-9]+");
            e.Handled = (regex.IsMatch(e.Text) ||//need to be false
                        (new_Phonenumber.Text.ToString().Count() > 9) ||//need to be false
                        (new_Phonenumber.Text.ToString().Count() == 0 && e.Text[0] != '0'));//need to be false
        }
       
        private void new_ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {   // digits and 9 numbers only on text box
            Regex regex = new Regex("[^0-9]+");
            e.Handled = (regex.IsMatch(e.Text) ||//need to be fals
                        (new_ID.Text.ToString().Count() > 8)//need to be fals
                        /* ||(new_ID.Text.ToString().Count() == 0 && e.Text[0] != '0')*/);
        }
        
        private void new_surrounding_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            //open aoto complete text box
            new_Address_TextChangedHelp(surround_adress_suggestion, new_surrounding_address);
        }
        
        private void new_Address_TextChanged(object sender, TextChangedEventArgs e)
        {   //help function that send to aoto complete text box
            new_Address_TextChangedHelp(adress_suggestion,new_Address);
        }
        
        private void new_Address_TextChangedHelp(ListBox adress_suggestion, TextBox new_Address)
        { 
            List<String> s = new List<String>();
            string str = new_Address.Text;
            
            if (t!=null&&t.IsAlive)//Is Alive checked 
                t.Abort();
            //aoto complete text box
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
                adress_suggestion.Visibility = Visibility.Collapsed;
                adress_suggestion.ItemsSource = null;
                return;
            }
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
        /// <summary>
        /// list of auto complite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void surround_adress_suggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adress_suggestion_SelectionChangedhelp(surround_adress_suggestion, new_surrounding_address, new TextChangedEventHandler(new_surrounding_address_TextChanged));
        }
        /// <summary>
        /// list of auto complite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adress_suggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adress_suggestion_SelectionChangedhelp(adress_suggestion, new_Address, new TextChangedEventHandler(new_Address_TextChanged));
        }
        /// <summary>
        /// list of auto complite help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adress_suggestion_SelectionChangedhelp(ListBox suggestion, TextBox Address, TextChangedEventHandler a)
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
        /// <summary>
        /// if Mouse Enter font size get bigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Save.Height += 5;
            Save.Width += 5;
        }
        /// <summary>
        /// if Mouse Leave font size get smaller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Save.Height -= 5;
            Save.Width -= 5;
        }

        
    }
    /// <summary>
    /// class to baind maximal and minimal time
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public class MotherT
    {
        public Mother info { get; set; } 
        public MotherDetails workingHours { get; set; }
        public  MotherT(Mother d,MotherDetails a) { info = d; workingHours = a; }
    }
}
