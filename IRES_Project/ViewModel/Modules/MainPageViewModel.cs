using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModel.GlobalViewModels;
using Model.Models;
using System.Collections.ObjectModel;
using Implements.MasterData.Modules;
using System.Windows.Controls;

namespace ViewModel.Modules
{

    public class MainPageViewModel : BaseViewModel
    {
        public ICommand SearchCommand { get; set; }
       
        public string Search_Text { get; set; } = null;

        private ObservableCollection<Employee> _ListEmployee;
        public ObservableCollection<Employee> ListEmployee { get { return _ListEmployee; } set { _ListEmployee = value;  OnPropertyChanged(); } }

        //public bool Isloaded = false;
        //public ICommand LoadedWindowCommand { get; set; }
       
        public MainPageViewModel()
        {
            //  SQLConnection SqlInstant = new SQLConnection();
            _ListEmployee = getDataEmployee();
           
          //  SearchCommand = new RelayCommand<TextBox>((p) => { return p.Text == null ? false : true; }, (p) =>
          //  {
             
          //    _ListEmployee = null;
          //    _ListEmployee = searchEmployee();
                
          //  }
          //);

            //LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    Isloaded = true;
            //    loginPage loginWindow = new loginPage();
            //    loginWindow.ShowDialog();
            //}
            //  );


        }
        public ObservableCollection<Employee> getDataEmployee()
        {
            ObservableCollection<Employee> listEmployee = new ObservableCollection<Employee>();
            EmployeeImplement empImp = new EmployeeImplement();
            listEmployee = empImp.getListEmployee();
            return listEmployee;
        }
        public ObservableCollection<Employee> searchEmployee()
        {
            ObservableCollection<Employee> listEmployee = new ObservableCollection<Employee>();
            EmployeeImplement empImp = new EmployeeImplement();
            listEmployee = empImp.searchListEmployee(Search_Text);
            return listEmployee;
        }


    }
}
