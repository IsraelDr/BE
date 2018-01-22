using System;
using System.Collections;
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
    /// Interaction logic for Groupbycontracts.xaml
    /// </summary>
    public partial class Groupbycontracts : UserControl
    {
        private IEnumerable source;
        public IBL bl;
        public IEnumerable Source
        {
            get { return source; }
            set
            {
                source = value;
                this.listView.ItemsSource = source;
            }
        }
        public Groupbycontracts()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IBL bl;
                bl = FactoryBL.IBLInstance;
                UpdateWindow a;
                int ID;
                ID = ((Contract)((ListView)(sender)).SelectedItem).Contract_ID;
                Contract contr = bl.GetContractById(ID);
                a = new UpdateWindow(3, contr, false);
                a.Show();
            }
            catch { }
        }
    }
}
