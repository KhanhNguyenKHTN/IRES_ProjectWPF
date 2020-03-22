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
            string query = $"SELECT b.*, o.count_dish_in_order FROM ires.bill b " +
                $"JOIN ( SELECT order_id, COUNT(order_id) AS count_dish_in_order FROM ires.order_detail GROUP BY order_id) AS o" +
                $" ON o.order_id = b.order_id WHERE CAST(created_datetime AS DATE) = '{date}'";

            var result = new BillStatisticModel
            {
                StatisticByDate = new StatisticByDateModel { Date = date, Revenue = 0 }
            };

            WorkerToDB worker = new WorkerToDB();

            DataTable dt = worker.getRecordsCommand(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int orderId = Convert.ToInt32(dt.Rows[i]["order_id"]);

                string queryOrderDetail = $"SELECT d.*, o_d.dish_quantity FROM ires.dish d " +
                    $"JOIN ( SELECT dish_id, dish_quantity FROM ires.order_detail " +
                    $"WHERE order_id = 1) AS o_d ON d.dish_id = o_d.dish_id";

                DataTable dtOrderDetail = worker.getRecordsCommand(queryOrderDetail);
                List<OrderDetailModel> listOrderDetail = new List<OrderDetailModel>();
                for (int j = 0; j< dtOrderDetail.Rows.Count; j++)
                {
                    var totalPrice = 0;//Convert.ToInt32(dtOrderDetail.Rows[j]["dish_quantity"]) * Convert.ToInt32(dtOrderDetail.Rows[j]["dish_cost"]);
                    OrderDetailModel detail = new OrderDetailModel
                    {
                        Name = dtOrderDetail.Rows[j]["dish_name"].ToString(),
                        Discount = 0,
                        Price = Convert.ToInt32(dtOrderDetail.Rows[j]["dish_cost"]),
                        DishQuantity = Convert.ToInt32(dtOrderDetail.Rows[j]["dish_quantity"]),
                        TotalDishPrice = (float)totalPrice
                    };

                    listOrderDetail.Add(detail);
                }

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
                    //PromotionCost = (float)Convert.ToDouble(dt.Rows[i]["promotion_cost"]),
                    CreatedDate = Convert.ToDateTime(dt.Rows[i]["created_datetime"]),
                    Username = dt.Rows[i]["customer_name"].ToString(),
                    PersonQuantity = Convert.ToInt32(dt.Rows[i]["person_quantity"]),
                    CountDishes = Convert.ToInt32(dt.Rows[i]["count_dish_in_order"]),
                    OrdersDetail = listOrderDetail
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
            string query = $"SELECT b.*, o.count_dish_in_order FROM ires.bill b " +
                $"JOIN ( SELECT order_id, COUNT(order_id) AS count_dish_in_order FROM ires.order_detail GROUP BY order_id) AS o" +
                $" ON o.order_id = b.order_id WHERE extract(month FROM created_datetime)=12 AND extract(year FROM created_datetime)=2019";

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
                    //PromotionCost = (float)Convert.ToDouble(dt.Rows[i]["promotion_cost"]),
                    CreatedDate = Convert.ToDateTime(dt.Rows[i]["created_datetime"]),
                    Username = dt.Rows[i]["customer_name"].ToString(),
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
