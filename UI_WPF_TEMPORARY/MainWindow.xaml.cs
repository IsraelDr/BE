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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MyBL bl = new MyBL();
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                bl.AddMother(new Mother(1, "first", "last", 0798512565, "adress", "surrounding", new bool[] { true, false }, new int[,] { { 1, 3 }, { 2, 4 } }, "comment", MyEnum.Paymentmethode.houerly));
                bl.AddMother(new Mother(2, "first", "last", 0798512565, "adress", "surrounding", new bool[] { true, false }, new int[,] { { 1, 3 }, { 2, 4 } }, "comment", MyEnum.Paymentmethode.houerly));
                bl.AddMother(new Mother(3, "first", "last", 0798512565, "adress", "surrounding", new bool[] { true, false }, new int[,] { { 1, 3 }, { 2, 4 } }, "comment", MyEnum.Paymentmethode.houerly));
                bl.AddMother(new Mother(4, "first", "last", 0798512565, "adress", "surrounding", new bool[] { true, false }, new int[,] { { 1, 3 }, { 2, 4 } }, "comment", MyEnum.Paymentmethode.houerly));
                bl.AddNanny(new Nanny(1, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5,3,5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) },{ new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15,1));
                bl.AddNanny(new Nanny(7, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15,34));
                bl.AddNanny(new Nanny(90, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15,4));
                bl.AddNanny(new Nanny(4, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15,3));
                bl.AddNanny(new Nanny(6, "first", "last", new DateTime(1994, 05, 17), 0798516858, "adress", true, 6, 5, 12, 2, 6, false, 200, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[,] { { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) }, { new TimeSpan(5, 3, 5), new TimeSpan(5, 3, 5) } }, false, "recommend", 15,5));
                bl.AddChild(new Child(1, 3, "Test", new DateTime(1994, 05, 12), true));
                bl.AddChild(new Child(2, 3, "Test", new DateTime(1994, 05, 12), true));
                bl.AddChild(new Child(3, 3, "Test", new DateTime(1994, 05, 12), true));
                bl.AddChild(new Child(4, 3, "Test", new DateTime(1994, 05, 12), true));
                //bl.AddContract(new Contract(1, 4, true, false, 17, 485, MyEnum.Paymentmethode.houerly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),19.15));
                //bl.AddContract(new Contract(2, 4, true, false, 17, 485, MyEnum.Paymentmethode.houerly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),15.14));
                //bl.AddContract(new Contract(3, 4, true, false, 17, 485, MyEnum.Paymentmethode.houerly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),751.5));
                //bl.AddContract(new Contract(4, 4, true, false, 17, 485, MyEnum.Paymentmethode.houerly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),14000.50));
            }
            catch (Exception e)
            {
                MessageBox.Show( e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void openwindow(object sender, EventArgs e)
        {
            this.Show();
        }

        private void MotherButton_Click(object sender, RoutedEventArgs e)
        {
            ListAll a = new ListAll(0);
            a.Show();
            this.Hide();
            a.Closed += new EventHandler(openwindow);
        }

        private void NannyButton_Click(object sender, RoutedEventArgs e)
        {
            ListAll b = new ListAll(1);
            b.Show();
            this.Hide();
            b.Closed += new EventHandler(openwindow);
        }

        private void ChildButton_Click(object sender, RoutedEventArgs e)
        {
            ListAll c = new ListAll(2);
            c.Show();
            this.Hide();
            c.Closed += new EventHandler(openwindow);
        }

        private void ContractsButton_Click(object sender, RoutedEventArgs e)
        {
            ListAll d = new ListAll(3);
            d.Show();
            this.Hide();
            d.Closed += new EventHandler(openwindow);
        }
    }
}
