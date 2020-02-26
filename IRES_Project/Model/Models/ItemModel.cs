using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ItemModel : INotifyPropertyChanged
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
        public ItemModel()
        {

        }
        private double itemQuantity;
        private double itemUnitPrice;
        private int itemId;
        private int resId;
        private string itemCode;
        private string itemName;
        private string itemUrl;
        private int itemCategoryId;
        private double itemToleren;
        private string itemStatus;
        private string itemDes;
        private bool active;
        private string createdBy;
        private DateTime createdDateTime;
        private string updatedBy;
        private DateTime updatedDateTime;
        private int version;

        public int ItemId { get => itemId; set => SetField(ref  itemId , value); }
        public int ResId { get => resId; set => SetField(ref  resId , value); }
        public string ItemCode { get => itemCode; set => SetField(ref  itemCode , value); }
        public string ItemName { get => itemName; set => SetField(ref  itemName , value); }
        public string ItemUrl { get => itemUrl; set => SetField(ref  itemUrl , value); }
        public int ItemCategoryId { get => itemCategoryId; set => SetField(ref  itemCategoryId , value); }
        public double ItemToleren { get => itemToleren; set => SetField(ref  itemToleren , value); }
        public string ItemStatus { get => itemStatus; set => SetField(ref  itemStatus , value); }
        public string ItemDes { get => itemDes; set => SetField(ref  itemDes , value); }
        public bool Active { get => active; set => SetField(ref  active , value); }
        public string CreatedBy { get => createdBy; set => SetField(ref  createdBy , value); }
        public DateTime CreatedDateTime { get => createdDateTime; set => SetField(ref  createdDateTime , value); }
        public string UpdatedBy { get => updatedBy; set => SetField(ref  updatedBy , value); }
        public DateTime UpdatedDateTime { get => updatedDateTime; set => SetField(ref  updatedDateTime , value); }
        public int Version { get => version; set => SetField(ref  version , value); }
        public double ItemQuantity { get => itemQuantity; set => SetField(ref itemQuantity, value); }
        public double ItemUnitPrice { get => itemUnitPrice; set => SetField(ref itemUnitPrice, value); }
    }
}
