using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implements.Workers;
using Model.Models;

namespace Implements.MasterData.Modules
{
    public class DishImplement
    {
        public List<DishModel> getLishDishes()
        {
            string query = $"select * from ires.dish";

            List<DishModel> result = new List<DishModel>();

            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DishModel item = new DishModel();

                item = new DishModel
                {
                    DishId = Convert.ToInt32(dt.Rows[i]["dish_id"]),
                    DishName = dt.Rows[i]["dish_name"].ToString(),
                    DishCost = Convert.ToInt32(dt.Rows[i]["dish_cost"]),
                    DishStatus = dt.Rows[i]["dish_status"].ToString()
                };
                result.Add(item);
            }

            return result;
        }

    }
}
