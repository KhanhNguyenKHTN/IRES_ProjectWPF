using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DishModel
    {
        public DishModel()
        {

        }

        private int dishId;
        private int resId;
        private string dishCode;
        private string dishName;
        private string imageUrl;
        private int dishCost;
        private string dishType;
        private int dishCategoryId;
        private int comboId;
        private int saleId;
        private string dishStatus;
        private string dishDescription;
        private string createBy;
        private DateTime createdDatetime;
        private int updateBy;
        private DateTime updatedDatetime;
        private string active;
        private float version;

        public int DishId { get => dishId; set => dishId = value; }
        public int ResId { get => resId; set => resId = value; }
        public string DishCode { get => dishCode; set => dishCode = value; }
        public string DishName { get => dishName; set => dishName = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public int DishCost { get => dishCost; set => dishCost = value; }
        public string DishType { get => dishType; set => dishType = value; }
        public int DishCategoryId { get => dishCategoryId; set => dishCategoryId = value; }
        public int ComboId { get => comboId; set => comboId = value; }
        public int SaleId { get => saleId; set => saleId = value; }
        public string DishStatus { get => dishStatus; set => dishStatus = value; }
        public string DishDescription { get => dishDescription; set => dishDescription = value; }
        public string CreateBy { get => createBy; set => createBy = value; }
        public DateTime CreatedDatetime { get => createdDatetime; set => createdDatetime = value; }
        public int UpdateBy { get => updateBy; set => updateBy = value; }
        public DateTime UpdatedDatetime { get => updatedDatetime; set => updatedDatetime = value; }
        public string Active { get => active; set => active = value; }
        public float Version { get => version; set => version = value; }
    }
}
