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
        //static BL_imp bls = new BL_imp();

        public IBL bl;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                bl = FactoryBL.IBLInstance;
                
                
                //                 class      first   last          id             adreass      Address      ************************work days**********************  *work hours:         sunday :       start******************end*****                   start******************end*****                  start******************end*****                    start******************end*****                   start******************end*****                  start******************end*****                    start******************end*****                        Payment methode          
                //bl.AddMother  (new Mother(1, "Dana", "Anilewitch", "0798512565",  "jerusalem", "jerusalem",new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] new TimeSpan[]{ new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)} }, "comment", MyEnum.Paymentmethode.hourly));
                //bl.AddMother  (new Mother(2, "Rona", "Gurewitch" ,  "0798512565", "tel aviv",  "tel aviv", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] new TimeSpan[]{ new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(15, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] {  new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5),new TimeSpan (8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)} }, "comment", MyEnum.Paymentmethode.hourly));
                //bl.AddMother  (new Mother(3, "Tal" , "Ben Atia"  , "0798512565",  "basel",    "basel",     new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] new TimeSpan[]{ new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)} }, "comment", MyEnum.Paymentmethode.hourly));
                //bl.AddMother  (new Mother(4, "Lea" , "Yosefof"   , "0798512565",  "tiberias",  "tiberias", new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] new TimeSpan[]{ new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[] new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)} }, "comment", MyEnum.Paymentmethode.hourly));
                //                                                                                                                                                                                                                                         start******************end*****                    start******************end*****                   start******************end*****                     start******************end*****                    start******************end*****                    start******************end*****             start******************end*****                                                                                                                                                                                                                                            start******************end*****
                ////bl.AddNanny   (new Nanny(1, "Li"    , "Ben Saken", new DateTime(1994, 05, 17), "0798516858", "bern",     true, 6, 5, 12, 1, 2, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[] {  new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15,1));
                //bl.AddNanny   (new Nanny(7, "Sara"  , "Rachamim",  new DateTime(1994, 05, 17), "0798516858", "tel aviv", true, 6, 5, 12, 5, 3, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.Chinuch, "recommend", 15,34));
                //bl.AddNanny   (new Nanny(90,"Keshet", "Gur",       new DateTime(1994, 05, 17), "0798516858", "jerusalem",true, 6, 5, 12, 7, 15, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5),new TimeSpan (8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan (8, 3, 5)}, new TimeSpan[]{ new TimeSpan (5, 3, 5), new TimeSpan(8, 3, 5)} }, MyEnum.Vacation.Chinuch, "recommend", 15,4));
                //bl.AddNanny   (new Nanny(4, "Efrat" , "Milikowski",new DateTime(1994, 05, 17), "0798516858", "ashdod",   true, 6, 5, 12, 2, 6, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) },new TimeSpan[]{ new TimeSpan(5, 3, 5),new TimeSpan (8, 3, 5)}, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15,3));
                //bl.AddNanny   (new Nanny(6, "Ilana" , "Levy",      new DateTime(1994, 05, 17), "0798516858", "bnei brak",true, 6, 5, 12, 8, 12, false, 50, 300, new bool[] { true, false, true, false, true, false, true }, new TimeSpan[][] { new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) }, new TimeSpan[]{ new TimeSpan(5, 3, 5), new TimeSpan(8, 3, 5) } }, MyEnum.Vacation.tamat, "recommend", 15,5));

                ///bl.AddChild   (new Child("1", "3", "Jankel", new DateTime(1994, 05, 12), true));
                //bl.AddChild   (new Child("2", "1", "Shloime", new DateTime(1994, 05, 12), true));
                //bl.AddChild   (new Child("3", "3", "Jossi", new DateTime(1994, 05, 12), true));
                //bl.AddChild   (new Child("4", "2", "Avi", new DateTime(1994, 05, 12), true));

                //bl.AddContract(new Contract(4,1, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),19.15, 357950, false));
                //bl.AddContract(new Contract(4,2,true, false,  17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),15.14, 4785, false));
                //bl.AddContract(new Contract(4,3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),751.5,0, false));
                //bl.AddContract(new Contract(4,4, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17),14000.50,147852,false));
                  //bl.AddContract(new Contract(4, 1,3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17), 19.15, 35, false));
                  //bl.AddContract(new Contract(4, 2,2, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(1994, 05, 17), new DateTime(2000, 05, 17), 15.14, 4, false));
                  //bl.AddContract(new Contract(4, 4,3, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2019, 05, 17), new DateTime(2020, 05, 17), 751.5, 0, false));
                  //bl.AddContract(new Contract(4, 4,2, true, false, 17, 485, MyEnum.Paymentmethode.hourly, new DateTime(2018, 05, 17), new DateTime(2020, 05, 17), 14000.50, 14, false));

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


        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            mother_title.FontSize += 10;
        }

        private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
        {
            nanny_title.FontSize += 10;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            mother_title.FontSize -= 10;
        }

        private void Grid_MouseLeave_1(object sender, MouseEventArgs e)
        {
            nanny_title.FontSize -= 10;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            ListAll a = new ListAll(0);
            a.Show();
            this.Hide();
            a.Closed += new EventHandler(openwindow);
        }


        private void mother_title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListAll a = new ListAll(0);
            a.Show();
            this.Hide();
            a.Closed += new EventHandler(openwindow);
        }

        private void nanny_title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListAll b = new ListAll(1);
            b.Show();
            this.Hide();
            b.Closed += new EventHandler(openwindow);
        }

        private void mother_title_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            mother_title.FontSize += 10;
        }

        private void mother_title_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            mother_title.FontSize -= 10;
        }

        private void nanny_title_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            nanny_title.FontSize += 10;
        }

        private void nanny_title_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            nanny_title.FontSize -= 10;
        }

        private void child_title_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            child_title.FontSize += 10;
        }

        private void child_title_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            child_title.FontSize -= 10;
        }

        private void contract_title_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            contract_title.FontSize += 10;
        }

        private void contract_title_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            contract_title.FontSize -= 10;
        }

        private void child_title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListAll c = new ListAll(2);
            c.Show();
            this.Hide();
            c.Closed += new EventHandler(openwindow);
        }

        private void contract_title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListAll d = new ListAll(3);
            d.Show();
            this.Hide();
            d.Closed += new EventHandler(openwindow);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            options_grid.Visibility = Visibility.Visible;
        }
    }
}
