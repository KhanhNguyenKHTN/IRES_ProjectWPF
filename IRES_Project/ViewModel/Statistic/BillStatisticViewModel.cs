using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.Statistic;
using ViewModel.GlobalViewModels;

namespace ViewModel.Statistic 
{
    public class BillStatisticViewModel: BaseViewModel
    {
        private List<BillStatisticModel> _BillStatistic;

        public List<BillStatisticModel> BillStatistic { 
            get => _BillStatistic; set { _BillStatistic = value; OnPropertyChanged(); }
        }

        public BillStatisticViewModel(string date)
        {
            // load BillStatistic
           BillStatistic = new List<BillStatisticModel>();
           GetBillsByDate(date);
        }

        public void GetBillsByDate(string date)
        {
            BillStatisticImplements billImp = new BillStatisticImplements();

            BillStatisticModel result = billImp.GetBillsByDate(date);

            BillStatistic.Add(result);
        }

        public void GetBillByMonth(string month)
        {
            BillStatisticImplements billImpl = new BillStatisticImplements();

            BillStatistic = new List<BillStatisticModel>();

            BillStatistic = billImpl.GetBillsByMonth(month);
        }

        //public List<BillModel> GetBillsByMonth()
        //{
        //    BillStatisticImplements billImp = new BillStatisticImplements();

        //    return billImp.GetBillsByDate(DateTime.Now);
        //}

        //public List<BillModel> GetBillsByYear()
        //{
        //    BillStatisticImplements billImp = new BillStatisticImplements();

        //    return billImp.GetBillsByDate(DateTime.Now);
        //}
    }
}
