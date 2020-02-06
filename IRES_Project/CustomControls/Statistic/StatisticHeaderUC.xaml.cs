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
using CustomControls.Statistic;
using MaterialDesignThemes.Wpf;
using Model.Models;

namespace CustomControls.Statistic
{
    /// <summary>
    /// Interaction logic for StatisticHeaderUC.xaml
    /// </summary>
    public partial class StatisticHeaderUC : UserControl
    {
        private string modeTime = "month";

        TimeWatching timeWatching = new TimeWatching { ModeTime = "Tháng", TimeSearch = DateTime.Now.Month.ToString() };

        public StatisticHeaderUC()
        {       
            InitializeComponent();
            cmbChooseTime.SelectedValue = "Tháng"; // default select item is month    
            
        }

        public event RoutedEventHandler BtnLoadStatistic;

        public bool GetTime()
        {
            try
            {
                if (timeWatching.ModeTime == "month")
                {
                    timeWatching.TimeSearch = ((DateTime)timeCal.SelectedDate).ToShortDateString();
                }
                else if (timeWatching.ModeTime == "year")
                {
                    timeWatching.TimeSearch = ((DateTime)timeCal.SelectedDate).Month.ToString();
                }
                else
                {
                    timeWatching.TimeSearch = ((DateTime)timeCal.SelectedDate).Year.ToString();
                }
                return true;
            }
            catch
            {
                return false;
            }           
        }

        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            if (GetTime())
            {
                BtnLoadStatistic?.Invoke(timeWatching, e);
            }
            else
            {
                MessageBox.Show("Mời bạn chọn lại thời gian!");
            }      
        }

        private void cmbChooseTime_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbChooseTime.SelectedValue.ToString() == "Năm")
            {
                timeWatching.ModeTime = "decade";
                timeWatching.TimeSearch = DateTime.Now.Year.ToString();
                timeCal.DisplayMode = CalendarMode.Decade;
            }
            else if (cmbChooseTime.SelectedValue.ToString() == "Tháng")
            {
                timeWatching.ModeTime = "year";
                timeWatching.TimeSearch = DateTime.Now.Month.ToString();
                timeCal.DisplayMode = CalendarMode.Year;
            }
            else
            {
                timeWatching.ModeTime = "month";
                timeWatching.TimeSearch = DateTime.Now.Date.ToString();
                timeCal.DisplayMode = CalendarMode.Month;
            }        
        }

        //private void timeCal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void timeCal_SelectionModeChanged(object sender, EventArgs e)
        //{
        //    if (timeCal.DisplayMode == CalendarMode.Month) timeCal.DisplayMode = CalendarMode.Year;
        //}

        //private void timeCal_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        //{

        //}
    }
}
