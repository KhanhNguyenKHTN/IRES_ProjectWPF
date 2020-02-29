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
                    DishStatus = dt.Rows[i]["dish_status"].ToString(),
                    DishCode = dt.Rows[i]["dish_code"].ToString(),
                    DishType = dt.Rows[i]["dish_type"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
//<<<<<<< Updated upstream
//=======
//        public static ObservableCollection<ItemModel> getDBListItem()
//        {
//            string query = $"select * from ires.item";
//            ObservableCollection<ItemModel> result = new ObservableCollection<ItemModel>();
//            WorkerToDB worker = new WorkerToDB();
//            DataTable dt = worker.getRecordsCommand(query);
//            if (dt.Rows.Count == 0)
//            {
//                ItemModel def_item = new ItemModel();
//                def_item = new ItemModel
//                {
//                    ItemId = -1,
//                };
//                result.Add(def_item);
//                return result;
//            }
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                ItemModel item = new ItemModel();

//                item = new ItemModel
//                {
//                    ItemId = Convert.ToInt32(dt.Rows[i]["item_id"]),
//                    ResId = Convert.ToInt32(dt.Rows[i]["restaurant_id"]),
//                    ItemCode = dt.Rows[i]["item_code"].ToString(),
//                    ItemName = dt.Rows[i]["item_name"].ToString(),
//                    ItemCategoryId = Convert.ToInt32(dt.Rows[i]["item_category_id"]),
//                    ItemToleren = Convert.ToDouble(dt.Rows[i]["item_toloren"]),
//                    ItemDes = dt.Rows[i]["item_description"].ToString(),
//                   // ItemUnitPrice = Convert.ToDouble(dt.Rows[i]["item_unit_price"])
//                };
//                result.Add(item);
//            }
//>>>>>>> Stashed changes

    }
}
