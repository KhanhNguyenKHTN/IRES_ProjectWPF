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
           
        }

        private Employee _NewEmp;

        public Employee NewEmp
        {
            get { return _NewEmp; }
            set { _NewEmp = value; OnPropertyChanged(); }
        }

        
    }
}

 
