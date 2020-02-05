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
using ViewModel.Statistic;
using Model.Models;

namespace IRES_Project.Statistic
{
    /// <summary>
    /// Interaction logic for DetailOrderView.xaml
    /// </summary>
    public partial class DetailOrderView : UserControl
    {
        DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();

        //public static DependencyProperty DetailOrdersProperty =
        //    DependencyProperty.Register("DetailOrders", typeof(int), typeof(int) );

        public DetailOrderView()
        {
            InitializeComponent();

            this.DataContext = detailOrderVM;
        }

    }
}
