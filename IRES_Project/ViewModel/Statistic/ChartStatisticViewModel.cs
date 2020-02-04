using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ViewModel.Statistic
{
    public class ChartStatisticViewModel
    {

        private readonly ObservableCollection<ChartStatisticModel> lineChartsOrigin = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineChartsOrigin
        {
            get { return lineChartsOrigin; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineChartsRevenue = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineChartsRevenue
        {
            get { return lineChartsRevenue; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineChartsProfit = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineChartsProfit
        {
            get { return lineChartsProfit; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineChartsPromotion = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineChartsPromotion
        {
            get { return lineChartsPromotion; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineChartsInnitialCost = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineChartsInnitialCost
        {
            get { return lineChartsInnitialCost; }
        }
        public ChartStatisticViewModel(string type)
        {
            //lineCharts.Add(new ChartStatisticModel { Time = "12/15/2019", Count = 15000 });

            if(type == "ngày")
            {
                fakeDataForDate f = new fakeDataForDate();
                lineChartsRevenue.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fakeCountRevenue });
                lineChartsProfit.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fakeCountProfit });
                LineChartsPromotion.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fakePromotion });
                LineChartsInnitialCost.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fakeCountInitialCost });
            } 
            else
            {
                fakeDateForMonth f = new fakeDateForMonth();
                for (int i = 0; i<31; i++)
                {
                    lineChartsRevenue.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fakeCountRevenue[i] });
                    lineChartsProfit.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fakeCountProfit[i] });
                    LineChartsPromotion.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fakeCountPromotion[i] });
                    LineChartsInnitialCost.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fakeCountInnitialCost[i] });
                }
            }
        }

        public class  fakeDataForDate
        {
            public string fakeTime ;
            public float fakeCountRevenue ;
            public float fakeCountProfit;
            public float fakePromotion;
            public float fakeCountInitialCost;

            public fakeDataForDate()
            {
                fakeTime = "20/12/2019";
                fakeCountRevenue = 1100000;
                fakeCountProfit = 600000;
                fakePromotion = 0;
                fakeCountInitialCost = 500000;
            }
        };

        public class fakeDateForMonth
        {
            public string[] fakeTime = new string[31] {"12/01/2019", "12/02/2019", "12/03/2019", "12/04/2019", "12/05/2019", "12/06/2019", "12/07/2019", "12/08/2019", "12/09/2019",
                "12/10/2019", "12/11/2019", "12/12/2019", "12/13/2019", "12/14/2019", "12/15/2019", "12/16/2019", "12/17/2019", "12/18/2019", "12/19/2019", "12/20/2019",
                "12/21/2019", "12/22/2019", "12/23/2019", "12/24/2019", "12/25/2019", "12/26/2019", "12/27/2019", "12/28/2019", "12/29/2019", "12/30/2019", "12/31/2019" };

            public float[] fakeCountRevenue = new float[31] {800000, 1100000, 3000000, 1000000, 1100000, 140000, 800000, 989000, 13000000, 1200000, 700000, 200000, 100000, 450000, 500000, 6000000, 7000000, 10000000, 850000, 400000, 
                500000, 600000, 7000000, 300000, 670000, 800000, 800000, 300000, 900000, 100000, 400000};

            public float[] fakeCountProfit = new float[31] { 400000, 4000000, 800000, 1300000, 600000, 700000, 400000, 500000, 8000000, 700000, 300000, 80000, 50000, 40000, 300000, 3000000, 4000000, 5000000, 700000, 100000,
                200000, 300000, 2000000, 100000, 200000, 400000, 500000, 100000, 400000, 60000, 300000};

            public float[] fakeCountPromotion = new float[31] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200000, 100000, 450000, 500000, 3000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            public float[] fakeCountInnitialCost = new float[31] {400000, 300000, 1700000, 600000, 500000, 40000, 300000, 300000, 1500000, 300000, 200000, 100000, 50000, 120000, 100000, 2000000, 2000000, 3000000, 30000, 100000,
                100000, 200000, 2000000, 120000, 210000, 200000, 200000, 300000, 200000, 300000, 230000};
        }
    }
}
