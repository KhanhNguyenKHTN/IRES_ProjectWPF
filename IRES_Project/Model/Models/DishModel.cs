using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DishModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public DishModel()
        {
            dishId = 1;
            resId  = 1;
            dishCode = "D-0011";
            dishName = "";
            imageUrl = "";
            dishCookTime = new DateTime(2020, 2, 20, 0, 30, 0);
            dishCost = 50000;
            dishType = "Khai vị";
            dishCategoryId = 6;
            comboId = 3;
            saleId = 0;
            dishStatus = "ACTIVE";
            dishDescription = "";
            active = true ;
            version = 1;
        }
      
        private int     dishId;
        private int     resId;
        private string  dishCode;
        private string  dishName;
        private string  imageUrl;
        private double  dishCost;
        private string  dishType;
        
        private int     dishCategoryId;
        private int     comboId;
        private int     saleId;
        private string  dishStatus;
        private string  dishDescription;
        private string  createBy;
        private DateTime dishCookTime;
        private DateTime createdDatetime;
        private string      updateBy;
        private DateTime updatedDatetime;
        private bool     active;
        private float    version;

        public int DishId { get => dishId; set => SetField(ref dishId, value); }
        public int ResId { get => resId;   set => SetField( ref resId,value); }
        public string DishCode { get => dishCode; set => SetField( ref dishCode , value); }
        public string DishName { get => dishName; set => SetField( ref dishName , value); }
        public string ImageUrl { get => imageUrl; set => SetField( ref imageUrl , value); }
        public double DishCost { get => dishCost; set => SetField( ref dishCost , value); }
        public string DishType { get => dishType; set => SetField( ref dishType , value); }
        public int DishCategoryId { get => dishCategoryId; set => SetField( ref dishCategoryId , value); }
        public int ComboId { get => comboId; set => SetField( ref comboId , value); }
        public int SaleId { get => saleId; set => SetField( ref saleId , value); }
        public string DishStatus { get => dishStatus; set => SetField( ref dishStatus , value); }
        public string DishDescription { get => dishDescription; set => SetField( ref dishDescription , value); }
        public string CreateBy { get => createBy; set => SetField( ref createBy , value); }
        public DateTime CreatedDatetime { get => createdDatetime; set => SetField( ref createdDatetime , value); }
        public string UpdateBy { get => updateBy; set => SetField( ref updateBy , value); }
        public DateTime UpdatedDatetime { get => updatedDatetime; set => SetField( ref updatedDatetime , value); }
        public bool Active { get => active; set => SetField( ref active , value); }
        public float Version { get => version; set => SetField( ref version , value); }
        public DateTime DishCookTime { get => dishCookTime; set => SetField(ref dishCookTime , value); }
        
    }
}
