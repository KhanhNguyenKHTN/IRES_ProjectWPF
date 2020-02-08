using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.MasterData.Modules;
using ViewModel.GlobalViewModels;
using System.Collections.ObjectModel;

namespace ViewModel.MasterData
{
    public class AddEmpViewModel : BaseViewModel
    {
        public List<string> ListRes = new List<string>() { "IRES cơ sở 1" };
        public List<string> RoleList { get; set; } = new List<string>() { "Bếp trưởng", "Thu ngân", "Nhân viên phục vụ", "Lễ tân", "Đầu bếp", "Quản lý ca"};
        public int User_Id =-1;
        public Dictionary<string, int> RoleDict = new Dictionary<string, int>()
        { { "Nhân viên phục vụ", 1 }, { "Bếp trưởng", 2 }, { "Thu ngân", 3} , {"Lễ tân",4 } , {"Đầu bếp",5 }, {"Quản lý ca",6 } };
        public AddEmpViewModel()
        {
            var a = NewEmp;

        }

        private Employee _NewEmp = new Employee();

        public Employee NewEmp
        {
            get { return _NewEmp; }
            set { _NewEmp = value; OnPropertyChanged(); }
        }

        public bool CheckUserName()
        {
            return EmployeeImplement.CheckEmpUserName(NewEmp.UserName);
           
        }
        public bool NewEmpInsert()
        {
            UpDateEmpCode();
            if (EmployeeImplement.InsertUserToDb(NewEmp, ref User_Id))
                NewEmp.UserId = User_Id;
            else
                return false;
            if (EmployeeImplement.InsertEmpToDb(NewEmp))
                return true;
            else
                return false;
        }
        public void UpDateEmpCode()
        {
            string RoleString="";
            switch(NewEmp.RoleId)
            {
                case 1:
                    {
                        RoleString = "WAITER";
                        break;
                    }
                case 2:
                    {
                        RoleString = "CHEF";
                        break;
                    }
                case 3:
                    {
                        RoleString = "CASHIER";
                        break;
                    }
                case 4:
                    {
                        RoleString = "RECEP";
                        break;
                    }
                case 5:
                    {
                        RoleString = "COOK";
                        break;
                    }
                case 6:
                    {
                        RoleString = "SHMN";
                        break;

                    }
            }
            NewEmp.EmployeeCode = RoleString + DateTime.Now.ToString("yyMMddHHmmss");
        }
    }
}

 
