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
        public AddEmpViewModel()
        {
            NewEmp.EmployeeName = "ten_dang_nhap";
            NewEmp.EmployeeCode = NewEmp.Role + DateTime.Now.ToString("yyyyMMddHHmmssffff");
            NewEmp.EmployeeDescription = "";
            NewEmp.Active = true;
            NewEmp.CreatedBy = "";
            NewEmp.CreatedDatetime = DateTime.Now;
        }

        private Employee _NewEmp = new Employee();

        public Employee NewEmp
        {
            get { return _NewEmp; }
            set { _NewEmp = value; OnPropertyChanged(); }
        }

        
    }
}

 
