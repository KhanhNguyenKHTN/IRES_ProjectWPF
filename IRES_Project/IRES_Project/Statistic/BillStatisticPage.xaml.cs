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
    /// Interaction logic for BillStatisticPage.xaml
    /// </summary>
    public partial class BillStatisticPage : UserControl
    {
        BillStatisticViewModel billVM = null;

        public BillStatisticPage()
        {
            InitializeComponent();
            this.billVM = new BillStatisticViewModel(DateTime.Now.ToShortDateString());
            DataContext = billVM;
        }

        public void GetBillsByDate(string time)
        {
            billVM.BillStatistic = new List<BillStatisticModel>();
            billVM.GetBillsByDate(time);
        }

        public void GetBillByMonth(string month)
        {
            billVM.GetBillByMonth(month);
        }

        public void GetBillByYear(string time)
        {
            MessageBox.Show("Chúng tôi hiện tại chưa hỗ trợ xem thống kê theo năm, vui lòng chọn tùy chọn khác nhé!");
        }

        private void StatisticHeaderUC_BtnLoadStatistic(object sender, RoutedEventArgs e)
        {
            TimeWatching timeWatching = sender as TimeWatching;
            
            switch(timeWatching.ModeTime)
            {
                case "month": GetBillsByDate(timeWatching.TimeSearch);
                    break;
                case "year": GetBillByMonth(timeWatching.TimeSearch);
                    break;
                case "decade": GetBillByYear(timeWatching.TimeSearch);
                    break;
                default: break;
            }
        }
    }
}
