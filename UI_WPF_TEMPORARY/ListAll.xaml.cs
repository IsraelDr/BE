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
using System.Windows.Shapes;
using BE;
using BL;
namespace UI_WPF_TEMPORARY
{
    /// <summary>
    /// Interaction logic for ListAll.xaml
    /// </summary>
    public partial class ListAll : Window
    {
        //static BL_imp bl = new BL_imp();
        public IBL bl;
        static int Choosen;
        public ListAll(int choosen)
        {
            Choosen = choosen;
            try
            {
                InitializeComponent();
                bl = FactoryBL.IBLInstance;
                //details_grid.Children.Add(new RadioButton());
                switch (choosen)
                {
                    case 0:
                        listofAll.AutoGeneratingColumn += listofAll_MotherGeneratingColumns;
                        listofAll.ItemsSource = bl.getMotherList();
                        DetailsChoice.Visibility = Visibility.Collapsed;
                        GroupChoice.Visibility = Visibility.Collapsed;
                    break;
                    case 1:
                        listofAll.AutoGeneratingColumn += listofAll_NannyGeneratingColumns;
                        listofAll.ItemsSource = bl.getNannyList();
                        GroupChoice.Content = "Group Nanny's by childrens Age";
                        break;
                    case 2:
                        listofAll.ItemsSource = bl.getChildList();
                        DetailsChoice.Visibility = Visibility.Collapsed;
                        GroupChoice.Visibility = Visibility.Collapsed;
                        
                        break;
                    case 3:
                        listofAll.AutoGeneratingColumn += listofAll_ContractGeneratingColumns;
                        listofAll.ItemsSource = bl.getContractList();
                        GroupChoice.Content = "Group Contracts by distance";
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            
        }

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow a = new AddWindow(Choosen);
            a.Show();
            this.Hide();
            a.Closed += new EventHandler(openwindow);
            
        }
        void openwindow(object sender, EventArgs e)
        {
            this.Show();
            listofAll.ItemsSource = null;
            switch (Choosen)
            {
                case 0:
                    listofAll.ItemsSource = bl.getMotherList();
                    break;
                case 1:
                    listofAll.ItemsSource = bl.getNannyList();
                    break;
                case 2:
                    listofAll.ItemsSource = bl.getChildList();
                    break;
                case 3:
                    listofAll.ItemsSource = bl.getContractList();
                    break;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (Choosen)
                {
                    case 0:
                        bl.RemoveMother(((Mother)listofAll.SelectedItem).ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getMotherList();
                        break;
                    case 1:
                        bl.RemoveNanny(((Nanny)listofAll.SelectedItem).ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getNannyList();
                        break;
                    case 2:
                        bl.RemoveChild(((Child)listofAll.SelectedItem).ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getChildList();
                        break;
                    case 3:
                        bl.RemoveContract(((Contract)listofAll.SelectedItem).Contract_ID);
                        listofAll.ItemsSource = null;
                        listofAll.ItemsSource = bl.getContractList();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show( "No line was choosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
}

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateWindow a;
                switch (Choosen)
                {
                    case 0:
                        Mother mother = bl.GetMotherById(((Mother)listofAll.SelectedItem).ID);
                        a = new UpdateWindow(Choosen, mother);
                        a.Show();
                        this.Hide();
                        a.Closed += new EventHandler(openwindow);
                        break;
                    case 1:
                        Nanny nanny = bl.GetNannyById(((Nanny)listofAll.SelectedItem).ID);
                        a = new UpdateWindow(Choosen, nanny);
                        a.Show();
                        this.Hide();
                        a.Closed += new EventHandler(openwindow);
                        break;
                    case 2:
                        Child chil=bl.GetChildById(((Child)listofAll.SelectedItem).ID);
                        a = new UpdateWindow(Choosen,chil);
                        a.Show();
                        this.Hide();
                        a.Closed += new EventHandler(openwindow);
                        break;
                    case 3:
                        Contract contract = bl.GetContractById(((Contract)listofAll.SelectedItem).Contract_ID);
                        a = new UpdateWindow(Choosen, contract);
                        a.Show();
                        this.Hide();
                        a.Closed += new EventHandler(openwindow);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No line was choosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void listofAll_MotherGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "daily_Nanny_required")
                e.Cancel = true;
            if (e.PropertyName == "nanny_required")
                e.Cancel = true;



        }
        void listofAll_ContractGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Contract_number")
                e.Cancel = true;

        }
        void listofAll_NannyGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Daily_Working_hours")
                e.Cancel = true;
            if (e.PropertyName == "Working_days")
                e.Cancel = true;
            if (e.PropertyName == "Additional_Info")
                e.Cancel = true;
            if (e.PropertyName == "Min_age")
                e.Cancel = true;
            if (e.PropertyName == "Max_age")
                e.Cancel = true;
            if (e.PropertyName == "fideback")
                e.Cancel = true;
            if (e.PropertyName == "Vacation_days")
                e.Cancel = true;
            if (e.PropertyName == "Recommendations")
                e.Cancel = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                listofAll.Visibility = Visibility.Visible;
                if(Choosen==3)
                    contractcond.Visibility = Visibility.Visible;
                GroupingPanel.Visibility = Visibility.Collapsed;
                

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                listofAll.Visibility = Visibility.Collapsed;
                contractcond.Visibility = Visibility.Collapsed;
                GroupingPanel.Visibility = Visibility.Visible;
                switch (Choosen)
                {
                    case 1:
                        GroupByAge uc = new GroupByAge();
                        uc.Source = bl.nannysByChildrenAge(false);
                        this.GroupingPanel.Content = uc;
                        break;
                    case 3:
                        Groupbycontracts userc = new Groupbycontracts();
                        userc.Source = bl.ContractsByNannyDistance();
                        this.GroupingPanel.Content = userc;
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Addbutton.Height += 5;
            Addbutton.Width += 5;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Addbutton.Height -= 5;
            Addbutton.Width -= 5;
        }
        private void Grid2_MouseEnter(object sender, MouseEventArgs e)
        {
            UpdateButton.Height += 5;
            UpdateButton.Width += 5;
        }

        private void Grid2_MouseLeave(object sender, MouseEventArgs e)
        {
            UpdateButton.Height -= 5;
            UpdateButton.Width -= 5;
        }
        private void Grid3_MouseEnter(object sender, MouseEventArgs e)
        {
            RemoveButton.Height += 5;
            RemoveButton.Width += 5;
        }

        private void Grid3_MouseLeave(object sender, MouseEventArgs e)
        {
            RemoveButton.Height -= 5;
            RemoveButton.Width -= 5;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BL_imp.contractCondition contractCondition;
            switch (((ComboBoxItem)contractcond.SelectedItem).Content.ToString())
            {
                case "None":
                    listofAll.ItemsSource = null;
                    listofAll.ItemsSource = bl.getContractList();
                    break;
                case "Ended Contracts":
                    listofAll.ItemsSource = null;
                    listofAll.ItemsSource = bl.GetAllContractWithCondition(bl.contractsEnd);
                    break;
                default:
                    break;
            }
        }
    }
}
