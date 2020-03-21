using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.Workers;
using System.Data;
using Service.Modules;
using System.Collections.ObjectModel;

namespace Implements.MasterData.Modules
{
    public class PromoImplement
    {
        public static ObservableCollection<PromoModel> getDBListPromo()
        {
            string query = $"select * from ires.promotion where active = true";
            ObservableCollection<PromoModel> result = new ObservableCollection<PromoModel>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                PromoModel def_item = new PromoModel();
                def_item = new PromoModel
                {
                    PromotionId = -1,
                };
                result.Add(def_item);
                return result;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PromoModel item = new PromoModel();

                item = new PromoModel
                {
                    Active = true,
                    PromotionId = Convert.ToInt32(dt.Rows[i]["promotion_id"]),
                    PromotionName = dt.Rows[i]["promotion_name"].ToString(),
                    PromotionMaxValue = Convert.ToInt32(dt.Rows[i]["promotion_max_value"]),
                    PromotionDes = dt.Rows[i]["promotion_description"].ToString(),
                    PromotionValue = dt.Rows[i]["promotion_value"].ToString(),
                    PromotionCode = dt.Rows[i]["promotion_code"].ToString(),
                    PromotionApplyType = dt.Rows[i]["promotion_apply_type"].ToString(),
                    PromotionStartDate = Convert.ToDateTime(dt.Rows[i]["promotion_start_date"]),
                    PromotionEndDate = Convert.ToDateTime(dt.Rows[i]["promotion_end_date"]),
                };
                result.Add(item);
            }
            return result;
        }
        public static ObservableCollection<PromoModel> getDBListDeletedPromo()
        {
            string query = $"select * from ires.promotion where active = false";
            ObservableCollection<PromoModel> result = new ObservableCollection<PromoModel>();
            WorkerToDB worker = new WorkerToDB();
            DataTable dt = worker.getRecordsCommand(query);
            if (dt.Rows.Count == 0)
            {
                PromoModel def_item = new PromoModel();
                def_item = new PromoModel
                {
                    PromotionId = -1,
                };
                result.Add(def_item);
                return result;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PromoModel item = new PromoModel();

                item = new PromoModel
                {
                    Active=false,
                    PromotionId = Convert.ToInt32(dt.Rows[i]["promotion_id"]),
                    PromotionName = dt.Rows[i]["promotion_name"].ToString(),
                    PromotionMaxValue = Convert.ToInt32(dt.Rows[i]["promotion_max_value"]),
                    PromotionDes = dt.Rows[i]["promotion_description"].ToString(),
                    PromotionValue = dt.Rows[i]["promotion_value"].ToString(),
                    PromotionCode = dt.Rows[i]["promotion_code"].ToString(),
                    PromotionApplyType = dt.Rows[i]["promotion_apply_type"].ToString(),
                    PromotionStartDate = Convert.ToDateTime(dt.Rows[i]["promotion_start_date"]),
                    PromotionEndDate = Convert.ToDateTime(dt.Rows[i]["promotion_end_date"]),
                };
                result.Add(item);
            }
            return result;
        }
        public static ObservableCollection<PromoModel> searchDBListPromo(string search_text)
        {
            string query = $"select *" +
                $" from ires.promotion" +
                $" where (active = 'true') and" +
                $" (promotion_name ilike '%' || @search_text || '%' or promotion_code ilike '%' || @search_text || '%' )";

            ObservableCollection<PromoModel> result = new ObservableCollection<PromoModel>();
            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQueryOne(query, search_text);

            if (dt.Rows.Count == 0)
            {
                PromoModel def_item = new PromoModel();
                def_item = new PromoModel
                {
                    PromotionId = -1,
                };
                result.Add(def_item);
                return result;
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PromoModel item = new PromoModel();

                item = new PromoModel
                {
                    Active = true,
                    PromotionId = Convert.ToInt32(dt.Rows[i]["promotion_id"]),
                    PromotionName = dt.Rows[i]["promotion_name"].ToString(),
                    PromotionMaxValue = Convert.ToInt32(dt.Rows[i]["promotion_max_value"]),
                    PromotionDes = dt.Rows[i]["promotion_description"].ToString(),
                    PromotionValue = dt.Rows[i]["promotion_value"].ToString(),
                    PromotionCode = dt.Rows[i]["promotion_code"].ToString(),
                    PromotionApplyType = dt.Rows[i]["promotion_apply_type"].ToString(),
                    PromotionStartDate = Convert.ToDateTime(dt.Rows[i]["promotion_start_date"]),
                    PromotionEndDate = Convert.ToDateTime(dt.Rows[i]["promotion_end_date"]),
                };
                result.Add(item);
            }

            return result;
        }
        public static ObservableCollection<PromoModel> searchDBListDeletedPromo(string search_text)
        {
            string query = $"select *" +
                $" from ires.promotion" +
                $" where (active = 'false') and" +
                $" (promotion_name ilike '%' || @search_text || '%' or promotion_code ilike '%' || @search_text || '%' )";

            ObservableCollection<PromoModel> result = new ObservableCollection<PromoModel>();
            SQLExecute sqlExecute = new SQLExecute();

            DataTable dt = sqlExecute.GetExcuteQueryOne(query, search_text);

            if (dt.Rows.Count == 0)
            {
                PromoModel def_item = new PromoModel();
                def_item = new PromoModel
                {
                    PromotionId = -1,
                };
                result.Add(def_item);
                return result;
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PromoModel item = new PromoModel();

                item = new PromoModel
                {
                    Active = false,
                    PromotionId = Convert.ToInt32(dt.Rows[i]["promotion_id"]),
                    PromotionName = dt.Rows[i]["promotion_name"].ToString(),
                    PromotionMaxValue = Convert.ToInt32(dt.Rows[i]["promotion_max_value"]),
                    PromotionDes = dt.Rows[i]["promotion_description"].ToString(),
                    PromotionValue = dt.Rows[i]["promotion_value"].ToString(),
                    PromotionCode = dt.Rows[i]["promotion_code"].ToString(),
                    PromotionApplyType = dt.Rows[i]["promotion_apply_type"].ToString(),
                    PromotionStartDate = Convert.ToDateTime(dt.Rows[i]["promotion_start_date"]),
                    PromotionEndDate = Convert.ToDateTime(dt.Rows[i]["promotion_end_date"]),
                };
                result.Add(item);
            }

            return result;
        }
        public static bool InsertNewPromoToDb(PromoModel promo)
        {
            string query = $"insert into ires.promotion(       promotion_code       ,      promotion_name     ,       promotion_apply_type,            promotion_start_date     ,       promotion_end_date     ,       promotion_value     ,  promotion_max_value ,      promotion_unit     ,      promotion_description     ,  created_by,created_datetime,updated_by, updated_datetime,active,version)" +
                                             $"  values('' || @promotion_code || '' ,'' ||@promotion_name|| '', '' ||@promotion_apply_type|| '',  @promotion_start_date , @promotion_end_date, '' ||@promotion_value|| '', @promotion_max_value ,'' ||@promotion_unit|| '','' ||@promotion_description|| '', 'Admin', CURRENT_TIMESTAMP(0), 'Admin', CURRENT_TIMESTAMP(0), true, '0')";

            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.InsertPromoQuery(query, promo);
        }
        public static bool ActivePromo(string PromoCode)
        {

            string query = $"UPDATE ires.promotion SET active = true" +
                           $" WHERE promotion_code = '' || @Value ||''";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.DeleteQuery(query, PromoCode);
        }
        public static bool DeletePromo(string PromoCode)
        {

            string query = $"UPDATE ires.promotion SET active = false" +
                           $" WHERE promotion_code = '' || @Value ||''";
            SQLExecute sqlExecute = new SQLExecute();
            return sqlExecute.DeleteQuery(query, PromoCode);
        }
    }
    
}
