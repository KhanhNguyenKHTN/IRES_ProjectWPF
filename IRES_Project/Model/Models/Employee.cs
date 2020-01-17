using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private int _EmployeeId;
        private string _EmployeeCode;
        private string _EmployeeName;
        private int _RestaurantId;
        private int _UserId;
        private int _RoleId;
        private string _Role;
        private string _EmployeeStatus;
        private string _UserName;
        private string _PassWord;
        private string _EmployeeDescription;
        private string _CreatedBy;
        private DateTime _CreatedDatetime;
        private string _UpdatedBy;
        private DateTime _UpdatedDatetime;
        private bool _Active;
        private int _Version;
        private string _PhoneNb;
        public Employee() { }

        public Employee(int i)
        {
            if (i % 2 == 0)
            {
                Active = true;
            }
            else
            {
                Active = false;
            }
            _EmployeeId = i;
            _EmployeeCode = "Số" + i as string;
            _RestaurantId = i;
            _UserId = i;
            _RoleId = i;
        }


        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set
            {
                SetField(ref _EmployeeCode, value, "EmployeeCode");
            }
        }


        public int RestaurantId { get => _RestaurantId; set { SetField(ref _RestaurantId, value, "RestaurantId"); } }
        public int UserId { get => _UserId; set { SetField(ref _UserId, value, "UserId"); } }
        public int RoleId { get => _RoleId; set { SetField(ref _RoleId, value, "RoleId"); } }
        public string EmployeeStatus { get => _EmployeeStatus; set { SetField(ref _EmployeeStatus, value, "EmployeeStatus"); } }
        public string UserName { get => _UserName; set { SetField(ref _UserName, value, "UserName"); } }
        public string PassWord { get => _PassWord; set { SetField(ref _PassWord, value, "PassWord"); } }
        public string EmployeeDescription { get => _EmployeeDescription; set { SetField(ref _EmployeeDescription, value, "EmployeeDescription"); } }
        public string CreatedBy { get => _CreatedBy; set { SetField(ref _CreatedBy, value, "CreatedBy"); } }
        public DateTime CreatedDatetime { get => _CreatedDatetime; set { SetField(ref _CreatedDatetime, value, "CreatedDatetime"); } }
        public string UpdatedBy { get => _UpdatedBy; set { SetField(ref _UpdatedBy, value, "UpdatedBy"); } }
        public DateTime UpdatedDatetime { get => _UpdatedDatetime; set { SetField(ref _UpdatedDatetime, value, "UpdatedDatetime"); } }
        public bool Active { get => _Active; set { SetField(ref _Active, value, "Active"); } }
        public int Version { get => _Version; set { SetField(ref _Version, value, "Version"); } }
        public string PhoneNb { get => _PhoneNb; set { SetField(ref _PhoneNb, value, "PhoneNb"); } }
        public string EmployeeName { get => _EmployeeName; set { SetField(ref _EmployeeName, value, "EmployeeName"); } }
        public string Role { get => _Role; set { SetField(ref _Role, value, "Role"); } }
        public int EmployeeId { get => _EmployeeId; set { SetField(ref _EmployeeId, value, "EmployeeId"); } }
        }
    }
