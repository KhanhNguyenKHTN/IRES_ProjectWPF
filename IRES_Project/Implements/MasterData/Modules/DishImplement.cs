using System;
using System.Collections.Generic;
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
        public static List<DishModel> getDBListDishes()
        {
            string query = $"select * from ires.dish where active = true";                  
            List<DishModel> result = new List<DishModel>();
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
                    DishType = dt.Rows[i]["dish_type"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
        public static List<DishModel> getDBListDeletedDishes()
        {
            string query = $"select * from ires.dish where active = false";
            List<DishModel> result = new List<DishModel>();
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
                    DishType = dt.Rows[i]["dish_type"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
        public static List<DishModel> searchDBListDishes(string search_text)
        {
            string query = $"select *" +
                $" from ires.dish" +
                $" where (active = 'true') and" +
                $" (dish_name ilike '%' || @search_text || '%' or dish_type ilike '%' || @search_text || '%' )";

            List<DishModel> result = new List<DishModel>();
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
                    DishType = dt.Rows[i]["dish_type"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
        public static List<DishModel> searchDBListDishesDeleted(string search_text)
        {
            string query = $"select *" +
                $" from ires.dish" +
                $" where (active = 'false') and" +
                $" (dish_name ilike '%' || @search_text || '%' or dish_type ilike '%' || @search_text || '%' )";

            List<DishModel> result = new List<DishModel>();
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
                    DishType = dt.Rows[i]["dish_type"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
    }
}
