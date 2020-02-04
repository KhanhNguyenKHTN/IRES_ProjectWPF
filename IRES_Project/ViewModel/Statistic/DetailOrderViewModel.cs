using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.GlobalConstants;
using Model.Models;
using ViewModel.GlobalViewModels;

namespace ViewModel.Statistic
{
    public class DetailOrderViewModel: BaseViewModel
    {
        List<OrderDetailModel> _ListDetailOrders;

        public List<OrderDetailModel> ListDetailOrders { get => _ListDetailOrders; set => _ListDetailOrders = value; }

        public DetailOrderViewModel()
        {
            OrderDetailModel orderDetail1 = new OrderDetailModel
            {
                Name = "Cơm gà",
                Discount = 0,
                DishQuantity = 2,
                TotalDishPrice = 200000,
                Price = 100000
            };

            OrderDetailModel orderDetail2 = new OrderDetailModel
            {
                Name = "Cơm cuộn Bắc Hải",
                Discount = 0,
                DishQuantity = 2,
                TotalDishPrice = 250000,
                Price = 125000
            };

            ListDetailOrders = new List<OrderDetailModel>();
            ListDetailOrders.Add(orderDetail1);
            ListDetailOrders.Add(orderDetail2);
            ListDetailOrders.Add(orderDetail1);
            ListDetailOrders.Add(orderDetail2);
        }
    }
}
