using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
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
    /// Interaction logic for OverviewStatisticPage.xaml
    /// </summary>
    public partial class OverviewStatisticPage : UserControl
    {
        ChartStatisticViewModel chartStatisticVM = null;
        public OverviewStatisticPage()
        {
            InitializeComponent();

            GetDataOverview("tháng");
        }

        private void StatisticHeaderUC_BtnLoadStatistic(object sender, RoutedEventArgs e)
        {
            TimeWatching timeWatching = sender as TimeWatching;

            switch(timeWatching.ModeTime)
            {
                //case "month": GetOverviewStatisticByDate(timeWatching.TimeSearch);
                //    break;
                //case "year": GetOverviewStatisticByMonth(timeWatching.TimeSearch);
                //    break;
                //default: break;

                case "month":
                    GetOverviewStatisticByDate(timeWatching.ModeTime);
                    break;
                case "year":
                    GetOverviewStatisticByMonth(timeWatching.ModeTime);
                    break;
                default: break;
            }
        }

        public void GetOverviewStatisticByDate(string time)
        {
            GetDataOverview("ngày");
        }

        public void GetOverviewStatisticByMonth(string month)
        {
            GetDataOverview("tháng");
        }

        public void GetDataOverview(string mode)
        {
            GridChart.Children.Clear();
            var chartStatisticVM = new ChartStatisticViewModel(mode);
            Chart chart = new Chart() { };

            LineSeries lineRevenue = BuildLine(Brushes.OrangeRed, chartStatisticVM.LineChartsRevenue, "Doanh Thu");
            LineSeries lineProfit = BuildLine(Brushes.Green, chartStatisticVM.LineChartsProfit, "Lợi nhuận");
            LineSeries lineInnitialCost = BuildLine(Brushes.Black, chartStatisticVM.LineChartsInnitialCost, "Chi phí");
            LineSeries linePromotion = BuildLine(Brushes.DodgerBlue, chartStatisticVM.LineChartsPromotion, "Khuyến mãi");

            chart.Series.Add(lineRevenue);
            chart.Series.Add(lineProfit);
            chart.Series.Add(lineInnitialCost);
            chart.Series.Add(linePromotion);
            chart.Background = Brushes.SkyBlue;
            chart.Foreground = Brushes.White;

            var legend = new Legend();
            legend.Background = Brushes.Gray;

           
            //chart.LegendTitle = "Chú thích";
            //chart.LegendStyle.Setters.Add(new Setter(, Brushes.Gray));
            
            GridChart.Children.Add(chart); // add to chart
        }

        private LineSeries BuildLine(SolidColorBrush color, ObservableCollection<ChartStatisticModel> source, string title)
        {
            LineSeries line = new LineSeries();

            // styles for line1
            Style poly1 = new Style(typeof(Polyline));
            poly1.Setters.Add(new Setter(Polyline.StrokeProperty, color));
            poly1.Setters.Add(new Setter(Polyline.StrokeThicknessProperty, 3d));
            line.PolylineStyle = poly1;

            Style pointStyle1 = new Style(typeof(LineDataPoint));
            pointStyle1.Setters.Add(new Setter(LineDataPoint.BackgroundProperty, color));
            line.DataPointStyle = pointStyle1;

            // Set ValuePath
            line.DependentValuePath = "Count";
            line.IndependentValuePath = "Time";
            line.ItemsSource = source;
            line.Title = title;

            return line;
        }
    }
}
