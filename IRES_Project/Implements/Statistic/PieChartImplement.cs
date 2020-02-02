using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.Workers;
using System.Data;
using System.Windows.Forms;

namespace Implements.Statistic
{
    public class PieChartImplement
    {
        public List<PieChartModel> GetListPie()
        {
            List<PieChartModel> result = new List<PieChartModel>();

            string query = $"select count(1) from ires.bill where created_datetime between '2019-11-22' and '2019-11-23'";

            WorkerToDB worker = new WorkerToDB();

            DataTable dt = worker.getRecordsCommand(query);

            int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return result;
        }

        public void GetAllBillByDate()
        {

        }

        public void executeQuery()
        {

        }

    }
}
