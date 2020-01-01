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

namespace ViewModel.Modules
{

    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Employee> _ListEmployee;
        public ObservableCollection<Employee> ListEmployee { get { return _ListEmployee; } set { _ListEmployee = value;  OnPropertyChanged(); } }

        //public bool Isloaded = false;
        //public ICommand LoadedWindowCommand { get; set; }
        public ObservableCollection<Employee> GetData()
        {
            ListEmployee = new ObservableCollection<Employee>();
            for (int i = 0; i <= 15; i++)

            {
                ListEmployee.Add(new Employee(i));

            }
            return ListEmployee;         
        }
        public MainPageViewModel()
        {
          //  SQLConnection SqlInstant = new SQLConnection();

           // ObservableCollection<Employee> employees = GetData();

            //dataGrid 
            

        //LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
        //{
        //    Isloaded = true;
        //    loginPage loginWindow = new loginPage();
        //    loginWindow.ShowDialog();
        //}
        //  );


    }


    }
}
