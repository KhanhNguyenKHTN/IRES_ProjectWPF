using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DishItem : INotifyPropertyChanged
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
        public DishItem()
        {
            DishItemTotalPrice = 50000;
            DishItemUnitPrice = 50000;
            ItemId = 8;
            ItemQuantity = 1.0;
        }
        private double dishItemTotalPrice;
        private int dishItemId;
        private double dishItemUnitPrice;
        private string disItemCode;
        private int dishId;
        private int itemId;
        private double itemQuantity;
        private int uomId;
        private string dishItemStatus;
        private string createBy;
        private string dishItemDes;
        private DateTime createdDatetime;
        private string updateBy;
        private DateTime updatedDatetime;
        private bool active;
        private float version;

        public string DisItemCode { get => disItemCode; set => SetField(ref disItemCode , value); }
        public int DishItemId { get => dishItemId; set => SetField(ref dishItemId , value); }
        public int DishId { get => dishId; set => SetField(ref dishId , value); }
        public int ItemId { get => itemId; set => SetField(ref itemId , value); }
        public double ItemQuantity { get => itemQuantity; set => SetField(ref itemQuantity , value); }
        public int UomId { get => uomId; set => SetField(ref uomId , value); }
        public string DishItemStatus { get => dishItemStatus; set => SetField(ref dishItemStatus , value); }
        public string CreateBy { get => createBy; set => SetField(ref createBy , value); }
        public string DishItemDes { get => dishItemDes; set => SetField(ref dishItemDes , value); }
        public DateTime CreatedDatetime { get => createdDatetime; set => SetField(ref createdDatetime , value); }
        public string UpdateBy { get => updateBy; set => SetField(ref updateBy , value); }
        public DateTime UpdatedDatetime { get => updatedDatetime; set => SetField(ref updatedDatetime , value); }
        public bool Active { get => active; set => SetField(ref active , value); }
        public float Version { get => version; set => SetField(ref version , value); }
        public double DishItemUnitPrice { get => dishItemUnitPrice; set => SetField(ref dishItemUnitPrice, value); }

        public double DishItemTotalPrice { get => dishItemTotalPrice; set => SetField(ref dishItemTotalPrice, value); }
    }
}
