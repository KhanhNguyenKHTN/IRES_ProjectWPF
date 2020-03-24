using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            // GridChartProduct.Children.Clear();
            GridChartProductHigh.Children.Clear();
            GridChartProductLow.Children.Clear();
            var chartStatisticVM = new ProductStatisticViewModel(mode);
            Chart chartHigh = new Chart() { };
            Chart chartLow = new Chart() { };

            //LineSeries line1 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts1, DependentValuePath = "Count", IndependentValuePath = "Time" };
            //LineSeries line2 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts2, DependentValuePath = "Count", IndependentValuePath = "Time" };
            //LineSeries line3 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts3, DependentValuePath = "Count", IndependentValuePath = "Time" };
            //LineSeries line4 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts4, DependentValuePath = "Count", IndependentValuePath = "Time" };
            //LineSeries line5 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts5, DependentValuePath = "Count", IndependentValuePath = "Time" };
            //LineSeries line6 = new LineSeries() { ItemsSource = chartStatisticVM.LineCharts6, DependentValuePath = "Count", IndependentValuePath = "Time" };

            // high series
            LineSeries line1 = BuildLine(Brushes.OrangeRed, chartStatisticVM.LineCharts1, "Bò xào rau muống");
            LineSeries line2 = BuildLine(Brushes.Green, chartStatisticVM.LineCharts2, "Cơm chiên dương châu");
            LineSeries line3 = BuildLine(Brushes.Black, chartStatisticVM.LineCharts3, "Gỏi gà xé chay");

            // low series
            LineSeries line4 = BuildLine(Brushes.DodgerBlue, chartStatisticVM.LineCharts4, "Cơm mắm ruốc");
            LineSeries line5 = BuildLine(Brushes.Brown, chartStatisticVM.LineCharts5, "Cải bó xôi");
            LineSeries line6 = BuildLine(Brushes.DarkSlateBlue, chartStatisticVM.LineCharts6, "Nước mắm truyền thống");
            
            // add series to chart high
            chartHigh.Series.Add(line1);
            chartHigh.Series.Add(line2);
            chartHigh.Series.Add(line3);
            chartHigh.Background = Brushes.SkyBlue;
            chartHigh.Foreground = Brushes.White;

            // Add series to chart low
            chartLow.Series.Add(line4);
            chartLow.Series.Add(line5);
            chartLow.Series.Add(line6);
            chartLow.Background = Brushes.SkyBlue;
            chartLow.Foreground = Brushes.White;

            GridChartProductHigh.Children.Add(chartHigh); // add to chart    
            GridChartProductLow.Children.Add(chartLow); // add to chart    
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
