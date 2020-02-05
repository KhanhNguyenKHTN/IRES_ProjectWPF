using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class BillModel
    {
        private int billId;
        private string billCode;
        private int orderId;
        private float orderTotalPrice;
        private int customerId;
        private int employeeId;
        private float payment;
        private float tip;
        private int promotionId;
        private float promotionCost;
        private DateTime createdDate;
        private string updatedBy;
        private string username;
        private int personQuantity;
        private int countDishes;
        private float discount;
        private List<OrderDetailModel> ordersDetail;

        public int BillId { get => billId; set => billId = value; }
        public string BillCode { get => billCode; set => billCode = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public float OrderTotalPrice { get => orderTotalPrice; set => orderTotalPrice = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public float Payment { get => payment; set => payment = value; }
        public float Tip { get => tip; set => tip = value; }
        public int PromotionId { get => promotionId; set => promotionId = value; }
        public float PromotionCost { get => promotionCost; set => promotionCost = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public string Username { get => username; set => username = value; }
        public int PersonQuantity { get => personQuantity; set => personQuantity = value; }
        public int CountDishes { get => countDishes; set => countDishes = value; }
        public float Discount { get => discount; set => discount = value; }
        public List<OrderDetailModel> OrdersDetail { get => ordersDetail; set => ordersDetail = value; }
    }
}
