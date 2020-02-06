using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel.Statistic;

namespace IRES_Project.Statistic
{
    /// <summary>
    /// Interaction logic for ProductStatisticPage.xaml
    /// </summary>
    public partial class ProductStatisticPage : UserControl
    {
        public ProductStatisticPage()
        {
            InitializeComponent();

            GetData("tháng");
        }

        public void GetData(string mode)
        {
            GridChartProduct.Children.Clear();
            var chartStatisticVM = new ProductStatisticViewModel(mode);
            Chart chart = new Chart() { };

            LineSeries line1 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts1, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries line2 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts2, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries line3 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts3, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries line4 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts4, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries line5 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts5, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries line6 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts6, DependentValuePath = "Count", IndependentValuePath = "Time" };

            line1.Title = "Bò xào rau muống";
            line2.Title = "Cơm chiên dương châu";
            line3.Title = "Gỏi gà xé chay";
            line4.Title = "Cơm mắm ruốc";
            line5.Title = "Cải bó xôi";
            line6.Title = "Nước mắm truyền thống";

            chart.Series.Add(line1);
            chart.Series.Add(line2);
            chart.Series.Add(line3);
            chart.Series.Add(line4);
            chart.Series.Add(line5);
            chart.Series.Add(line6);

            GridChartProduct.Children.Add(chart); // add to chart 
        }

        private void StatisticHeaderUC_BtnLoadStatistic(object sender, RoutedEventArgs e)
        {
            TimeWatching timeWatching = sender as TimeWatching;

            switch (timeWatching.ModeTime)
            {
                case "month":
                    GetData(timeWatching.ModeTime);
                    break;
                case "year":
                    GetData(timeWatching.ModeTime);
                    break;
                default: break;
            }
        }
    }
}
