using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implements.Workers;
using Model.Models;
using Service.Modules;

namespace Implements.MasterData.Modules
{
    public class DishImplement
    {
        public static ObservableCollection<DishModel> getDBListDishes()
        {
            string query = $"select * from ires.dish a,ires.dish_category b where a.active = true and a.dish_category_id = b.dish_category_id";                  
            ObservableCollection<DishModel> result = new ObservableCollection<DishModel>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                DishModel def_item = new DishModel();
                def_item = new DishModel
                {
                    DishId = -1,                   
                };
                result.Add(def_item);
                return result;
            }
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
                    DishType = dt.Rows[i]["category_name"].ToString(),
                    DishCategoryId = Convert.ToInt32(dt.Rows[i]["dish_category_id"])
                   
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<DishModel> getDBListDeletedDishes()
        {
            string query = $"select * from ires.dish a,ires.dish_category b where a.active = false and a.dish_category_id = b.dish_category_id";
            ObservableCollection<DishModel> result = new ObservableCollection<DishModel>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                DishModel def_item = new DishModel();
                def_item = new DishModel
                {
                    DishId = -1,
                };
                result.Add(def_item);
                return result;
            }
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
                    DishType = dt.Rows[i]["category_name"].ToString(),
                    DishCategoryId = Convert.ToInt32(dt.Rows[i]["dish_category_id"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<DishModel> searchDBListDishes(string search_text)
        {
            string query = $"select *" +
                $" from ires.dish" +
                $" where (active = 'true') and" +
                $" (dish_name ilike '%' || @search_text || '%' or dish_type ilike '%' || @search_text || '%' )";

            ObservableCollection<DishModel> result = new ObservableCollection<DishModel>();
            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQueryOne(query, search_text);

            if (dt.Rows.Count == 0)
            {
                DishModel def_item = new DishModel();
                def_item = new DishModel
                {
                    DishId = -1,
                };
                result.Add(def_item);
                return result;
            }


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
                    DishType = dt.Rows[i]["dish_type"].ToString(),
                    DishCategoryId = Convert.ToInt32(dt.Rows[i]["dish_category_id"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<DishModel> searchDBListDishesDeleted(string search_text)
        {
            string query = $"select *" +
                $" from ires.dish" +
                $" where (active = 'false') and" +
                $" (dish_name ilike '%' || @search_text || '%' or dish_type ilike '%' || @search_text || '%' )";

            ObservableCollection<DishModel> result = new ObservableCollection<DishModel>();
            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQueryOne(query, search_text);

            if (dt.Rows.Count == 0)
            {
                DishModel def_item = new DishModel();
                def_item = new DishModel
                {
                    DishId = -1,
                };
                result.Add(def_item);
                return result;
            }


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
                    DishType = dt.Rows[i]["dish_type"].ToString(),
                    DishCategoryId = Convert.ToInt32(dt.Rows[i]["dish_category_id"])
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<ItemModel> getDBListItem()
        {
            string query = $"select * from ires.item";
            ObservableCollection<ItemModel> result = new ObservableCollection<ItemModel>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                ItemModel def_item = new ItemModel();
                def_item = new ItemModel
                {
                    ItemId = -1,
                };
                result.Add(def_item);
                return result;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemModel item = new ItemModel();

                item = new ItemModel
                {
                    ItemId = Convert.ToInt32(dt.Rows[i]["item_id"]),
                    ResId = Convert.ToInt32(dt.Rows[i]["restaurant_id"]),
                    ItemCode = dt.Rows[i]["item_code"].ToString(),
                    ItemName = dt.Rows[i]["item_name"].ToString(),
                    ItemCategoryId = Convert.ToInt32(dt.Rows[i]["item_category_id"]),
                    ItemToleren = Convert.ToDouble(dt.Rows[i]["item_toloren"]),
                    ItemDes = dt.Rows[i]["item_description"].ToString(),
                    ItemUnitPrice = Convert.ToDouble(dt.Rows[i]["item_unit_price"])
                };
                result.Add(item);
            }

            return result;
        }
        public static Dictionary<int,string> getDBListCategory()
        {
            string query = $"select * from ires.dish_category";
            Dictionary<int, string> result = new Dictionary<int, string>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                Dictionary<int, string> def_item = new Dictionary<int, string>() { { 1, "None" }, }; 
                return def_item;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(Convert.ToInt32(dt.Rows[i]["dish_category_id"]), dt.Rows[i]["category_name"].ToString());
            }

            return result;
        }
    }
}
