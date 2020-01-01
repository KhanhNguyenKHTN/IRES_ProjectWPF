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
using ViewModel.Modules;
using Model.Models;
using System.Collections.ObjectModel;

namespace IRES_Project.MasterData.MainPage
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        int pageIndex = 1;
        private int numberOfRecPerPage = 5;
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };
        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainPageViewModel();
            MainPageViewModel mainPageVM = new MainPageViewModel();
            ObservableCollection<Employee> listEm = mainPageVM.GetData();
            dataGrid.ItemsSource = listEm.Take(numberOfRecPerPage);
       
            int count = listEm.Take(numberOfRecPerPage).Count();
            lblpageInformation.Content = count + " of " + listEm.Count;
           // dataGrid.Columns[2].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[3].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[4].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[5].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[6].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[7].Visibility = Visibility.Collapsed;
            //dataGrid.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void DataGrid_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
