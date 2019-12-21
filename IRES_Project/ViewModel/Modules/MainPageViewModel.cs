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
        public ObservableCollection<Employee>  ListEmployee { get; set; }

        //public bool Isloaded = false;
        //public ICommand LoadedWindowCommand { get; set; }

        public MainPageViewModel()
        {
            ListEmployee = new ObservableCollection<Employee>();
            for (int i = 0; i <= 15; i++)
                
            {
                ListEmployee.Add(new Employee(i));
           
            }

            //int pageIndex = 1;
            //private int numberOfRecPerPage;
            //private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };


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
