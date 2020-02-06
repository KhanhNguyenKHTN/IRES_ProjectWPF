using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ViewModel.Statistic
{
    public class ProductStatisticViewModel
    {
        private readonly ObservableCollection<ChartStatisticModel> lineCharts1 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts1
        {
            get { return lineCharts1; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineCharts2 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts2
        {
            get { return lineCharts2; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineCharts3 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts3
        {
            get { return lineCharts3; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineCharts4 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts4
        {
            get { return lineCharts4; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineCharts5 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts5
        {
            get { return lineCharts5; }
        }

        private readonly ObservableCollection<ChartStatisticModel> lineCharts6 = new ObservableCollection<ChartStatisticModel>();

        public ObservableCollection<ChartStatisticModel> LineCharts6
        {
            get { return lineCharts6; }
        }

        public ProductStatisticViewModel(string type)
        {
            if (type == "month")
            {
                fakeDataForDate f = new fakeDataForDate();
                lineCharts1.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake1 });
                lineCharts2.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake2 });
                lineCharts3.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake3 });
                lineCharts4.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake4 });
                lineCharts5.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake5 });
                lineCharts6.Add(new ChartStatisticModel { Time = f.fakeTime, Count = f.fake6 });
            }
            else
            {
                fakeDataForMonth f = new fakeDataForMonth();
                for (int i = 0; i < 31; i++)
                {
                    lineCharts1.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake1[i] });
                    lineCharts2.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake2[i] });
                    lineCharts3.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake3[i] });
                    lineCharts4.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake4[i] });
                    lineCharts5.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake5[i] });
                    lineCharts6.Add(new ChartStatisticModel { Time = f.fakeTime[i], Count = f.fake6[i] });
                }
            }
        }

        public class fakeDataForDate
        {
            public string fakeTime;
            public float fake1;
            public float fake2;
            public float fake3;
            public float fake4;
            public float fake5;
            public float fake6;

            public fakeDataForDate()
            {
                fakeTime = "20/12/2019";
                fake1 = 1100000;
                fake2 = 600000;
                fake3 = 0;
                fake4 = 500000;
                fake5 = 0;
                fake6 = 500000;
                //ProductStatisticModel tempData1 = new ProductStatisticModel { Count = 1700000, Name = "Bò xào rau muống" };
                //ProductStatisticModel tempData2 = new ProductStatisticModel { Count = 1600000, Name = "Cơm chiên dương châu" };
                //ProductStatisticModel tempData3 = new ProductStatisticModel { Count = 1300000, Name = "Gỏi gà xé chay" };
                //ProductStatisticModel tempData4 = new ProductStatisticModel { Count = 80000, Name = "Cơm mắm ruốc" };
                //ProductStatisticModel tempData5 = new ProductStatisticModel { Count = 100000, Name = "Cơm mắm ruốc" };
                //ProductStatisticModel tempData6 = new ProductStatisticModel { Count = 300000, Name = "Cơm mắm ruốc" };
            }
        };

        public class fakeDataForMonth
        {
            public string[] fakeTime = new string[31] {"12/01/2019", "12/02/2019", "12/03/2019", "12/04/2019", "12/05/2019", "12/06/2019", "12/07/2019", "12/08/2019", "12/09/2019",
                "12/10/2019", "12/11/2019", "12/12/2019", "12/13/2019", "12/14/2019", "12/15/2019", "12/16/2019", "12/17/2019", "12/18/2019", "12/19/2019", "12/20/2019",
                "12/21/2019", "12/22/2019", "12/23/2019", "12/24/2019", "12/25/2019", "12/26/2019", "12/27/2019", "12/28/2019", "12/29/2019", "12/30/2019", "12/31/2019" };

            public float[] fake1 = new float[31] {800000, 1100000, 3000000, 1000000, 1100000, 140000, 800000, 989000, 13000000, 1200000, 700000, 200000, 100000, 450000, 500000, 6000000, 7000000, 10000000, 850000, 400000,
                500000, 600000, 7000000, 300000, 670000, 800000, 800000, 300000, 900000, 100000, 400000};

            public float[] fake2 = new float[31] { 400000, 4000000, 800000, 1300000, 600000, 700000, 400000, 500000, 8000000, 700000, 300000, 80000, 50000, 40000, 300000, 3000000, 4000000, 5000000, 700000, 100000,
                200000, 300000, 2000000, 100000, 200000, 400000, 500000, 100000, 400000, 60000, 300000};

            public float[] fake3 = new float[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200000, 100000, 450000, 500000, 3000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            public float[] fake4 = new float[31] {400000, 300000, 1700000, 600000, 500000, 40000, 300000, 300000, 1500000, 300000, 200000, 100000, 50000, 120000, 100000, 2000000, 2000000, 3000000, 30000, 100000,
                100000, 200000, 2000000, 120000, 210000, 200000, 200000, 300000, 200000, 300000, 230000};

            public float[] fake5 = new float[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200000, 100000, 450000, 500000, 3000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            public float[] fake6 = new float[31] {400000, 300000, 1700000, 600000, 500000, 40000, 300000, 300000, 1500000, 300000, 200000, 100000, 50000, 120000, 100000, 2000000, 2000000, 3000000, 30000, 100000,
                100000, 200000, 2000000, 120000, 210000, 200000, 200000, 300000, 200000, 300000, 230000};
        }

    }
}
