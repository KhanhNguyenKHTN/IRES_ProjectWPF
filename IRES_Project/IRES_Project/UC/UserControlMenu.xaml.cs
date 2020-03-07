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

namespace IRES_Project.UC
{
    /// <summary>
    /// Interaction logic for UserControlMenu.xaml
    /// </summary>
    public partial class UserControlMenu : UserControl
    {
        public UserControlMenu()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler StaffClick;
        public event RoutedEventHandler DishClick;
        public event RoutedEventHandler PromoClick;

        public event RoutedEventHandler OverviewStatisticClick;
        public event RoutedEventHandler BillStatisticClick;
        public event RoutedEventHandler ProductStatisticClick;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lsMenu.SelectedIndex;
            lviewStatistic.SelectedItem = null;
            switch (selectedIndex)
            {
                case 0:
                    StaffClick?.Invoke(sender, e);
                    break;
                case 1:
                    DishClick?.Invoke(sender, e);
                    break;
                case 2:
                    
                    break;
                case 3:
                    PromoClick?.Invoke(sender, e);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private void lviewStatistic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lviewStatistic.SelectedIndex;
            lsMenu.SelectedItem = null;
            switch (selectedIndex)
            {
                case 0:
                    OverviewStatisticClick?.Invoke(sender, e);
                    break;
                case 1:
                    BillStatisticClick?.Invoke(sender, e);
                    break;
                case 2:
                    ProductStatisticClick?.Invoke(sender, e);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        
    }
}
