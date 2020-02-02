using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implements.Workers;
using Model.Models;

namespace Implements.Statistic
{
    public class BillStatisticImplements
    {
        public BillStatisticImplements()
        {

        }

        public BillStatisticModel GetBillsByDate(string date)
        {
            //string query = $"SELECT b.*, c.user_name " +
            //    $"FROM ires.bill b" +
            //    $" JOIN ires.customer c ON b.customer_id = c.customer_id" +
            //    $" WHERE bill_id IN " +
            //    $" (SELECT bill_id FROM ires.bill WHERE CAST(created_datetime AS DATE) = '{date}')";

            string query = $"SELECT b.*, c.user_name, o1.person_quantity, o1.count_dish_in_order" +
                $" FROM ires.bill b JOIN ires.customer c ON b.customer_id = c.customer_id" +
                $" JOIN ( SELECT o.*, o_d.count_dish_in_order FROM ires.orders o JOIN (SELECT order_id, COUNT(order_id) AS count_dish_in_order FROM ires.order_detail GROUP BY order_id) AS o_d" +
                $" ON o.order_id = o_d.order_id) AS o1 ON b.order_id = o1.order_id" +
                $" WHERE bill_id IN( SELECT bill_id FROM ires.bill WHERE CAST(created_datetime AS DATE) = '11-22-2019')";

            var result = new BillStatisticModel
            {
                StatisticByDate = new StatisticByDateModel { Date = date, Revenue = 0 }
            };

            WorkerToDB worker = new WorkerToDB();

            DataTable dt = worker.getRecordsCommand(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BillModel item ;

                item = new BillModel
                {
                    BillId = Convert.ToInt32(dt.Rows[i]["bill_id"]),
                    BillCode = dt.Rows[i]["bill_code"].ToString(),
                    OrderId = Convert.ToInt32(dt.Rows[i]["order_id"]),
                    OrderTotalPrice = Convert.ToInt32(dt.Rows[i]["order_total_price"]),
                    CustomerId = Convert.ToInt32(dt.Rows[i]["customer_id"]),
                    EmployeeId = Convert.ToInt32(dt.Rows[i]["employee_id"]),
                    Payment = (float)Convert.ToDouble(dt.Rows[i]["payment"]),
                    Tip = (float)Convert.ToDouble(dt.Rows[i]["tip"]),
                    PromotionCost = (float)Convert.ToDouble(dt.Rows[i]["promotion_cost"]),
                    CreatedDate = Convert.ToDateTime(dt.Rows[i]["created_datetime"]),
                    Username = dt.Rows[i]["user_name"].ToString(),
                    PersonQuantity = Convert.ToInt32(dt.Rows[i]["person_quantity"]),
                    CountDishes = Convert.ToInt32(dt.Rows[i]["count_dish_in_order"])
                };
                if (result.ListBills == null)
                {
                    result.ListBills = new List<BillModel>();
                }
                result.ListBills.Add(item);
                result.StatisticByDate.Revenue += item.OrderTotalPrice;
            }

            return result;
        }

        public List<BillStatisticModel> GetBillsByMonth(string month)
        {
            //string query = $"SELECT b.*, c.user_name " +
            //    $"FROM ires.bill b" +
            //    $" JOIN ires.customer c ON b.customer_id = c.customer_id" +
            //    $" WHERE bill_id IN (" +
            //    $" SELECT bill_id FROM ires.bill WHERE " +
            //    $" extract(month FROM created_datetime) = 11 " +
            //    $"AND extract(year FROM created_datetime) = 2019)";

            string query = $"SELECT b.*, c.user_name, o1.person_quantity, o1.count_dish_in_order" +
                $" FROM ires.bill b JOIN ires.customer c ON b.customer_id = c.customer_id" +
                $" JOIN ( SELECT o.*, o_d.count_dish_in_order FROM ires.orders o JOIN (SELECT order_id, COUNT(order_id) AS count_dish_in_order FROM ires.order_detail GROUP BY order_id) AS o_d" +
                $" ON o.order_id = o_d.order_id) AS o1 ON b.order_id = o1.order_id" +
                $"  WHERE bill_id IN ( SELECT bill_id FROM ires.bill WHERE extract(month FROM created_datetime) = 11 AND extract(year FROM created_datetime) = 2019)";

            var result = new List<BillStatisticModel>();

            WorkerToDB worker = new WorkerToDB();

            DataTable dt = worker.getRecordsCommand(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var createdDateTime = dt.Rows[i]["created_datetime"].ToString();
                BillStatisticModel checkDateBillIsExist = result.FirstOrDefault(x => x.StatisticByDate.Date == createdDateTime);

                BillModel item = new BillModel
                {
                    BillId = Convert.ToInt32(dt.Rows[i]["bill_id"]),
                    BillCode = dt.Rows[i]["bill_code"].ToString(),
                    OrderId = Convert.ToInt32(dt.Rows[i]["order_id"]),
                    OrderTotalPrice = Convert.ToInt32(dt.Rows[i]["order_total_price"]),
                    CustomerId = Convert.ToInt32(dt.Rows[i]["customer_id"]),
                    EmployeeId = Convert.ToInt32(dt.Rows[i]["employee_id"]),
                    Payment = (float)Convert.ToDouble(dt.Rows[i]["payment"]),
                    Tip = (float)Convert.ToDouble(dt.Rows[i]["tip"]),
                    //PromotionId = Convert.ToInt32(dt.Rows[i]["promotion_id"]),
                    PromotionCost = (float)Convert.ToDouble(dt.Rows[i]["promotion_cost"]),
                    CreatedDate = Convert.ToDateTime(dt.Rows[i]["created_datetime"]),
                    Username = dt.Rows[i]["user_name"].ToString(),
                    PersonQuantity = Convert.ToInt32(dt.Rows[i]["person_quantity"]),
                    CountDishes = Convert.ToInt32(dt.Rows[i]["count_dish_in_order"])
                };

                if (checkDateBillIsExist == null) // if not exist -> add to result
                {
                    List<BillModel> temp = new List<BillModel>();
                    temp.Add(item);

                    BillStatisticModel itemBillStatistic = new BillStatisticModel
                    {
                        StatisticByDate = new StatisticByDateModel
                        {
                            Date = createdDateTime,
                            Revenue = item.OrderTotalPrice
                        },
                        ListBills = temp
                    };
                    result.Add(itemBillStatistic);
                }
                else // else if exist, add more billModel
                {
                    checkDateBillIsExist.ListBills.Add(item);
                    checkDateBillIsExist.StatisticByDate.Revenue += item.OrderTotalPrice;
                }

            }

            return result;
        }

    }
}
