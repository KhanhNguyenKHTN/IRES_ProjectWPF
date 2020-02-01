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
        private bool _Refresh = false;
        public bool Refresh { get { return _Refresh; } set { _Refresh = value; OnPropertyChanged(); } } 
        public ICommand SearchCommand { get; set; }
       
        public string Search_Text { get; set; } = null;

        private ObservableCollection<Employee> _ListEmployee;
        public ObservableCollection<Employee> ListEmployee { get { return _ListEmployee; } set { _ListEmployee = value;  OnPropertyChanged(); } }
        private ObservableCollection<Employee> _ListEmployeeRoot;
        public ObservableCollection<Employee> ListEmployeeRoot { get { return _ListEmployeeRoot; } set { _ListEmployeeRoot = value; OnPropertyChanged(); } }

        //public bool Isloaded = false;
        //public ICommand LoadedWindowCommand { get; set; }

        public MainPageViewModel()
        {
            //  SQLConnection SqlInstant = new SQLConnection();
            ListEmployee = getDataEmployee();
            ListEmployeeRoot = new ObservableCollection<Employee>();
            ListEmployeeRoot = ListEmployee;
            if (ListEmployee.Count()==0)
            {
                MessageBox.Show("Khong co data");
            }

            SearchCommand = new RelayCommand<TextBox>((p) => { return (p.Text == null || p.Text=="") ? false : true; }, (p) =>
            {
               
                ListEmployee = null;
                ListEmployee = searchEmployee();
                if (Refresh == true)
                {
                    Refresh = false;
                }
                else
                    Refresh = true;

            }
            );

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
            
            listEmployee = EmployeeImplement.getListEmployee();
            Employee X = listEmployee.First();
            if (X.RoleId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listEmployee.Clear();
            }
            return listEmployee;
        }
        public ObservableCollection<Employee> searchEmployee()
        {
            ObservableCollection<Employee> listEmployee = new ObservableCollection<Employee>();
           
            if ( Search_Text==null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listEmployee;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listEmployee;
            }
            
            listEmployee = EmployeeImplement.searchListEmployee(Search_Text);

            Employee X= listEmployee.First();
            if(X.RoleId ==-1)
            {
                MessageBox.Show("Không có kết quả");
                listEmployee.Clear();
            }
            return listEmployee;
        }
        public bool UpdatePhoneNb(string phoneNb, string role)
        {

            return EmployeeImplement.UpdatePhone(phoneNb, role);
        }

    }
}
