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
        public static bool InsertDishToDb(DishModel dish, ref int dishId, string hour, string min)
        {
            string query = $"insert into ires.dish(restaurant_id,dish_code, dish_name,dish_cook_time,dish_cost,dish_type, dish_category_id,dish_status, created_by,created_datetime,updated_by, updated_datetime,active,version)" +
                                             $" values(1, 'D-099', '' || @dish_name ||'',  @cook_time  , @dish_cost,  '' || @dish_type||'', @dish_cate,  'ACTIVE', 'Admin', CURRENT_TIMESTAMP(0), 'Admin', CURRENT_TIMESTAMP(0), true, '0') returning dish_id";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.InsertDishQuery(query, dish, ref dishId, hour,min);
        }
        public static bool UpdateDishCode(int dishId)
        {
            string query = $"UPDATE ires.dish " +
                $"SET dish_code = '' || @dish_code || ''" +
                $" WHERE dish_id = @dish_Id";   
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.UpdateDishCodeQuery(query, dishId);

        }
        public static bool InsertDishItemToDb(DishItem item, ref int itemId,int dishId)
        {
            string query = $"insert into ires.dish_item(dish_item_code,       dish_id,  item_id,  item_quantity, uom_id, dish_item_status, created_by,created_datetime,updated_by, updated_datetime,active,version)" +
                                             $" values('D'  ,                @dish_id, @item_id, @item_quantity, 1     , 'ACTIVE', 'Admin', CURRENT_TIMESTAMP(0), 'Admin', CURRENT_TIMESTAMP(0), true, '0') returning dish_item_id";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.InsertDishItemQuery(query, item, ref itemId, dishId);
        }
        public static bool UpdateItemCode(int dishItemId)
        {
            string query = $"UPDATE ires.dish_item SET dish_item_code = '' || @dish_item_code || '' WHERE dish_item_id = @dish_item_id";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.UpdateItemCodeQuery(query, dishItemId);
        }
    }
}               
