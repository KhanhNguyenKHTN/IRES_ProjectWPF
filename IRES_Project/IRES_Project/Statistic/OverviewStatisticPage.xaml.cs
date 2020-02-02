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
            //LoadLineChartData();
            //this.DataContext
             var model = new PieChartViewModel();
            Chart chart = new Chart() {};

            
            LineSeries lines = new LineSeries() { ItemsSource = model.Pies, DependentValuePath ="Count", IndependentValuePath = "Name" };

            var pie = new List<PieChartModel>();
            pie.Add(new PieChartModel() { Name = "thang 1", Count = 1222 });
            pie.Add(new PieChartModel() { Name = "thang 2", Count = 1111 });
            pie.Add(new PieChartModel() { Name = "thang 3", Count = 222 });
            pie.Add(new PieChartModel() { Name = "thang 4", Count = 231 });
            pie.Add(new PieChartModel() { Name = "thang 5", Count = 122 });
            pie.Add(new PieChartModel() { Name = "Pakistan", Count = 122 });
            pie.Add(new PieChartModel() { Name = "Nigeria", Count = 321 });
            LineSeries lines1 = new LineSeries() { ItemsSource = pie, DependentValuePath = "Count", IndependentValuePath = "Name" };
            chart.Series.Add(lines);
            chart.Series.Add(lines1);
            GridChart.Children.Add(chart);
        }

        //private void LoadLineChartData()
        //{
        //    ((System.Windows.Controls.DataVisualization.Charting.LineSeries)mcChart.Series[0]).ItemsSource =
        //        new KeyValuePair<DateTime, int>[]{
        //    new KeyValuePair<DateTime,int>(DateTime.Now, 100),
        //    new KeyValuePair<DateTime,int>(DateTime.Now.AddDays(1), 130),
        //    new KeyValuePair<DateTime,int>(DateTime.Now.AddDays(2), 150),
        //    new KeyValuePair<DateTime,int>(DateTime.Now.AddDays(3), 125),
        //    new KeyValuePair<DateTime,int>(DateTime.Now.AddDays(4),155) };


        //}
    }
}
