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
using IRES_Project.MasterData.MainPage;
using IRES_Project.MasterData.FoodView;
using IRES_Project.Statistic;
using ViewModel.MasterData;
using ViewModel.Modules;
using ViewModel.Statistic;

namespace IRES_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Switcher.pageSwitcher = this;
            //Switcher.Switch(new AddEmp());
            //Switcher.Switch(new MainPage());
            DataContext = new MainPage();
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        private void UserControlMenu_StaffClick(object sender, RoutedEventArgs e)
        {
            DataContext = new MainPageViewModel();
        }

        private void UserControlMenu_DishClick(object sender, RoutedEventArgs e)
        {
            DataContext = new DishViewModel();
        }

        private void UserControlMenu_OverviewStatisticClick(object sender, RoutedEventArgs e)
        {
            DataContext = new ChartStatisticViewModel("ngày");
        }

        private void UserControlMenu_BillStatisticClick(object sender, RoutedEventArgs e)
        {
            DataContext = new BillStatisticViewModel(DateTime.Now.ToShortDateString());
        }
    }
}
