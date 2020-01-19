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
            LoadLineChartData();
        }

        private void LoadLineChartData()
        {
            ((LineSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<DateTime, int>[]{
            new KeyValuePair<DateTime,int>(DateTime.Now, 100),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(9), 130),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(2), 150),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(3), 125),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(4),155) };

            ((LineSeries)mcChart.Series[1]).ItemsSource =
                new KeyValuePair<DateTime, int>[]{
            new KeyValuePair<DateTime,int>(DateTime.Now, 200),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(9), 190),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(2), 120),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(3), 205),
            new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(4),375) };
        }
    }
}
