using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Employee
    {
        private int _EmployeeId;
        private string _EmployeeCode;
        private int _RestaurantId;
        private int _UserId;
        private int _RoleId;
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
        public Employee( int i)
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

        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }
        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }

        public int RestaurantId { get => _RestaurantId; set => _RestaurantId = value; }
        public int UserId { get => _UserId; set => _UserId = value; }
        public int RoleId { get => _RoleId; set => _RoleId = value; }
        public string EmployeeStatus { get => _EmployeeStatus; set => _EmployeeStatus = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string PassWord { get => _PassWord; set => _PassWord = value; }
        public string EmployeeDescription { get => _EmployeeDescription; set => _EmployeeDescription = value; }
        public string CreatedBy { get => _CreatedBy; set => _CreatedBy = value; }
        public DateTime CreatedDatetime { get => _CreatedDatetime; set => _CreatedDatetime = value; }
        public string UpdatedBy { get => _UpdatedBy; set => _UpdatedBy = value; }
        public DateTime UpdatedDatetime { get => _UpdatedDatetime; set => _UpdatedDatetime = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int Version { get => _Version; set => _Version = value; }
        public string PhoneNb { get => _PhoneNb; set => _PhoneNb = value; }
    }
}
