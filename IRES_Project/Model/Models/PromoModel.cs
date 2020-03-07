using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
 public  class PromoModel : INotifyPropertyChanged
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
        public PromoModel()
        {
            Active = true;
            PromotionValue = "1000";
            promotionMaxValue = 500000;
            PromotionUnit = "VNĐ";
            PromotionApplyType = "ALL";
            PromotionName = "";
            PromotionCode = "";
            PromotionId = 0;
            PromotionStartDate = DateTime.Now;
            PromotionEndDate = DateTime.Now.AddDays(1);
            PromotionDes = "Mô tả";
        }
        private string promotionName;
        private int promotionId;
        private int restaurantId;
        private string promotionCode;
        private string promotionApplyType;
        private DateTime promotionStartDate;
        private DateTime promotionEndDate;
        private int promotionQuantity;
        private string promotionValue;
        private int promotionMaxValue;
        private string promotionUnit;
        private string promotionCondition;
        private string promotionDes;
        private string createdBy;
        private DateTime createdDatetime;
        private string updateBy;
        private DateTime updatedDatetime;
        private bool active;
        private float version;

        public DateTime CreatedDatetime { get => createdDatetime; set => SetField( ref  createdDatetime, value); }
        public int RestaurantId { get => restaurantId; set => SetField( ref  restaurantId, value); }
        public int PromotionId { get => promotionId; set => SetField( ref  promotionId, value); }
        public string PromotionCode { get => promotionCode; set => SetField( ref  promotionCode, value); }
        public string PromotionApplyType { get => promotionApplyType; set => SetField( ref  promotionApplyType, value); }
        public DateTime PromotionStartDate { get => promotionStartDate; set => SetField( ref  promotionStartDate, value); }
        public DateTime PromotionEndDate { get => promotionEndDate; set => SetField( ref  promotionEndDate, value); }
        public int PromotionQuantity { get => promotionQuantity; set => SetField( ref  promotionQuantity, value); }
        public string PromotionValue { get => promotionValue; set => SetField( ref  promotionValue, value); }
        public int PromotionMaxValue { get => promotionMaxValue; set => SetField( ref  promotionMaxValue, value); }
        public string PromotionUnit { get => promotionUnit; set => SetField( ref  promotionUnit, value); }
        public string PromotionCondition { get => promotionCondition; set => SetField( ref  promotionCondition, value); }
        public string PromotionDes { get => promotionDes; set => SetField( ref  promotionDes, value); }
        public string CreatedBy { get => createdBy; set => SetField( ref  createdBy, value); }
        public string UpdateBy { get => updateBy; set => SetField( ref  updateBy, value); }
        public DateTime UpdatedDatetime { get => updatedDatetime; set => SetField( ref  updatedDatetime, value); }
        public bool Active { get => active; set => SetField( ref  active, value); }
        public float Version { get => version; set => SetField( ref  version, value); }
        public string PromotionName { get => promotionName; set => SetField(ref promotionName, value); }
    }
}
