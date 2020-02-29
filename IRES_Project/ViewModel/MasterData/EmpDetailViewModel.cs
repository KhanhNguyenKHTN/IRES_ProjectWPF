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
    public class EmpDetailViewModel : BaseViewModel
    {

        public List<string> ListRes = new List<string>() { "IRES cơ sở 1" };
        public List<string> RoleList { get; set; } = new List<string>() { "Bếp trưởng", "Thu ngân", "Nhân viên phục vụ", "Lễ tân", "Đầu bếp", "Quản lý ca" };
        public int User_Id = -1;
        public Dictionary<string, int> RoleDict = new Dictionary<string, int>()
        { { "Nhân viên phục vụ", 1 }, { "Bếp trưởng", 2 }, { "Thu ngân", 3} , {"Lễ tân",4 } , {"Đầu bếp",5 }, {"Quản lý ca",6 } };
        public EmpDetailViewModel()
        {
        }   
        private Employee _CurEmp = new Employee();

        public Employee CurEmp
        {
            get { return _CurEmp; }
            set { _CurEmp = value; OnPropertyChanged(); }
        } 
    }
}
