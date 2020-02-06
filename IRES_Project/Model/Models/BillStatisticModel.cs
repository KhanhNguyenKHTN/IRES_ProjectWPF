using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class BillStatisticModel
    {
        private StatisticByDateModel statisticByDate;
        private List<BillModel> listBills;

        public StatisticByDateModel StatisticByDate { get => statisticByDate; set => statisticByDate = value; }
        public List<BillModel> ListBills { get => listBills; set => listBills = value; }
    }
}
