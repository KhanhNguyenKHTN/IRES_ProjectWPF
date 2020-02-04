using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class OrderDetailModel 
    {
        private string name;
        private float price;
        private int dishQuantity;
        private float discount;
        private float totalDishPrice;

        public int DishQuantity { get => dishQuantity; set => dishQuantity = value; }
        public float Discount { get => discount; set => discount = value; }
        public float TotalDishPrice { get => totalDishPrice; set => totalDishPrice = value; }
        public float Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
    }
}
