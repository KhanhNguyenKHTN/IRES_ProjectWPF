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
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage : UserControl
    {
        public OverviewPage()
        {
            InitializeComponent();

            var chartStatisticVM = new ChartStatisticViewModel("tháng");
            Chart chart = new Chart() { };

            LineSeries lineRevenue = new LineSeries() { ItemsSource = chartStatisticVM.LineChartsRevenue, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries lineProfit = new LineSeries() { ItemsSource = chartStatisticVM.LineChartsProfit, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries lineInnitialCost = new LineSeries() { ItemsSource = chartStatisticVM.LineChartsInnitialCost, DependentValuePath = "Count", IndependentValuePath = "Time" };
            LineSeries linePromotion = new LineSeries() { ItemsSource = chartStatisticVM.LineChartsPromotion, DependentValuePath = "Count", IndependentValuePath = "Time" };


            lineRevenue.Title = "Doanh Thu";
            lineProfit.Title = "Lợi nhuận";
            lineInnitialCost.Title = "Chi phí";
            linePromotion.Title = "Khuyến mãi";

            chart.Series.Add(lineRevenue);
            chart.Series.Add(lineProfit);
            chart.Series.Add(lineInnitialCost);
            chart.Series.Add(linePromotion);

            GridChart.Children.Add(chart); // add to chart 
        }
    }
}
