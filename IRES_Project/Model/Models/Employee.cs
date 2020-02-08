using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.Models
{
    public class Employee : INotifyPropertyChanged, IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName =null)
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
        private string _UserEmail;
        private string _UserAddress;
        public Employee()
        {
            EmployeeName = "Nguyen Van A";
           
            EmployeeDescription = "";
            Active = true;
            CreatedBy = "";
            CreatedDatetime = DateTime.Now;
            EmployeeStatus = "";
            PassWord = "123456";
            UserAddress = "Thành phố Hồ Chí Minh";
            PhoneNb = "0909090988";
            RestaurantId = 1;
            Role = "Nhân viên phục vụ";
            RoleId = 1;
            UserId = -2;
            UserName = "ten_dang_nhap";
            UserEmail = "nhanvien01@ires.com.vn";
            EmployeeCode = "";
        }

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


        public string EmployeeCode    {
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
        public string UserEmail { get => _UserEmail; set { SetField(ref _UserEmail, value, "UserEmail"); } }
        public string UserAddress { get => _UserAddress; set { SetField(ref _UserAddress, value, "UserAddress"); } }


        private bool _isBegin = false,_isEnd = false;
        private Employee backup; 
        public void BeginEdit()
        {
            if (_isBegin == false)
            {
               backup = this.MemberwiseClone() as Employee;
               _isBegin = true;
        
            }
            else
            {
                _isBegin = false;
            }
        }

        public void CancelEdit()
        {
            this.EmployeeId = backup.EmployeeId;
            this.EmployeeName = backup.EmployeeName;
            this.RestaurantId = backup.RestaurantId;
            this.UserId = backup.UserId;
            this.RoleId = backup.RoleId;
            this.Role = backup.Role;
            this.EmployeeStatus = backup.EmployeeStatus;
            this.UserName = backup.UserName;
            this.PassWord = backup.PassWord;
            this.EmployeeDescription = backup.EmployeeDescription;
            this.CreatedBy = backup.CreatedBy;
            this.CreatedDatetime = backup.CreatedDatetime;
            this.UpdatedBy = backup.UpdatedBy;
            this.UpdatedDatetime = backup.UpdatedDatetime;
            this.Active = backup.Active;
            this.Version = backup.Version;
            this.PhoneNb = backup.PhoneNb;

        }
        public void EndEdit()
        {
            if(_isEnd==false)
            {
                //IList Row = dataGrid.SelectedItems;
                //Employee x = Row[0] as Employee;
                //mainPageVM.UpdatePhoneNb(x.PhoneNb, x.EmployeeName);
                //_isEnd = true;
            }
            else
            {
                _isEnd = false;
            }
            
            //other logic...
        }
    }
                 
    }
