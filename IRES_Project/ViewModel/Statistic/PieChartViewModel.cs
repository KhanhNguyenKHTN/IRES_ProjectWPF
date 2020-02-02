using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.Statistic;

namespace ViewModel.Statistic
{
    public class PieChartViewModel
    {
        // Tạo danh sách số dân một số nước bằng ObservableCollection vì có hổ trợ tự động NotifyPropertychanged
        private readonly ObservableCollection<PieChartModel> pie = new ObservableCollection<PieChartModel>();

        // Property sẽ được Binding từ GUI(View)
        public ObservableCollection<PieChartModel> Pies
        {
            get { return pie; }
        }

        // Add data(Model-Item) cho List
        public PieChartViewModel()
        {
            pie.Add(new PieChartModel() { Name = "China", Count = 1340 });
            pie.Add(new PieChartModel() { Name = "India", Count = 1220 });
            pie.Add(new PieChartModel() { Name = "United States", Count = 309 });
            pie.Add(new PieChartModel() { Name = "Indonesia", Count = 240 });
            pie.Add(new PieChartModel() { Name = "Brazil", Count = 195 });
            pie.Add(new PieChartModel() { Name = "Pakistan", Count = 174 });
            pie.Add(new PieChartModel() { Name = "Nigeria", Count = 158 });

            GetDataByDate(DateTime.Now);
        }

        public void GetDataByDate(DateTime date)
        {
            PieChartImplement pieImp = new PieChartImplement();

            List<PieChartModel> listPie = pieImp.GetListPie();
        }
    }

}
