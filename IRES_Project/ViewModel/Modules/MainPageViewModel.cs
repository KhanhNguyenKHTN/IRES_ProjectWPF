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
        public bool IsSearching = false;
        public List<string> RoleList { get; set; } = new List<string>() { "Bếp trưởng", "Thu ngân", "Nhân viên phục vụ", "Lễ tân", "Đầu bếp", "Quản lý ca", "Quản lý nhà hàng" };
        public string Search_Text { get; set; } = null;

        private bool _Refresh = false;
        public bool Refresh { get { return _Refresh; } set { _Refresh = value; OnPropertyChanged(); } }

        private bool _IsChecked = true;
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; OnPropertyChanged(); } }

        public  ICommand SearchCommand { get; set; }
        private ICommand checkCommand;// khong dùng
   
        private ObservableCollection<Employee> _ListEmployee;
        public  ObservableCollection<Employee>  ListEmployee     { get { return _ListEmployee; }     set { _ListEmployee     = value; OnPropertyChanged(); } }

        private ObservableCollection<Employee> _ListEmployeeRoot;
        public  ObservableCollection<Employee>  ListEmployeeRoot { get { return _ListEmployeeRoot; } set { _ListEmployeeRoot = value; OnPropertyChanged(); } }

        //public bool Isloaded = false;
        //public ICommand LoadedWindowCommand { get; set; }

        public MainPageViewModel()
        {
            
            //  SQLConnection SqlInstant = new SQLConnection();
            ListEmployee = new ObservableCollection<Employee>();
            ListEmployee = getDataEmployee();
            ListEmployeeRoot = new ObservableCollection<Employee>();
            ListEmployeeRoot = getDataEmployee();
            if (ListEmployee.Count()==0)
            {
                MessageBox.Show("Khong co data");
            }

            SearchCommand = new RelayCommand<TextBox>((p) => { return (p.Text == null || p.Text=="") ? false : true; },
                (p) =>  {
                            Search_Text = p.Text;
                            //ListEmployeeRoot = searchEmployee();
                            if (Refresh == true)
                            {
                                Refresh = false;
                            }
                            else
                                Refresh = true;

                        });

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
            IsSearching = false;
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
        public ObservableCollection<Employee> getDeletedEmployee()
        {
            IsSearching = false;
            ObservableCollection<Employee> listEmployee = new ObservableCollection<Employee>();

            listEmployee = EmployeeImplement.getListDeletedEmployee();
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
            IsSearching = true;
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
                //MessageBox.Show("Không có kết quả");
                listEmployee.Clear();
                return listEmployee;
            }
           
            return listEmployee;
        }
        public ObservableCollection<Employee> searchDeletedEmployee()
        {
            IsSearching = true;
            ObservableCollection<Employee> listEmployee = new ObservableCollection<Employee>();

            if (Search_Text == null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listEmployee;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listEmployee;
            }

            listEmployee = EmployeeImplement.searchListDeletedEmployee(Search_Text);

            Employee X = listEmployee.First();
            if (X.RoleId == -1)
            {
                //MessageBox.Show("Không có kết quả");
                listEmployee.Clear();
                return listEmployee;
            }
           
            return listEmployee;
        }
        public bool UpdatePhoneNb(string phoneNb, string employee_code)
        {

            return EmployeeImplement.UpdatePhone(phoneNb, employee_code);
        }
        
        
        public bool DeleteEmployee(string employee_code,Employee a)
        {
            RemoveItem(ListEmployeeRoot, a);
            return EmployeeImplement.DeleteEmp(employee_code);
        }
        public bool ActiveEmployee(string employee_code, Employee a)
        {
            RemoveItem(ListEmployeeRoot, a);
            return EmployeeImplement.ActiveEmp(employee_code);
        }
        public bool UpdateRole(int RoleId, string employee_code)
        {

            return EmployeeImplement.UpdateRole(RoleId, employee_code);
        }
        public void UpdateLocalEmpRoleId(string Role, string employee_code)
        {
            for (int i = 1; i <= ListEmployee.Count(); i++)
            {
                if (ListEmployee[i - 1].EmployeeCode == employee_code)
                {
                    switch (Role)
                    {
                        case "Nhân viên phục vụ":
                            {
                                ListEmployee[i - 1].RoleId = 1;
                                break;
                            }
                        case "Bếp trưởng":
                            {
                                ListEmployee[i - 1].RoleId = 2;
                                break;
                            }
                        case "Thu ngân":
                            {
                                ListEmployee[i - 1].RoleId = 3;
                                break;
                            }

                        case "Lễ tân":
                            {
                                ListEmployee[i - 1].RoleId = 4;
                                break;
                            }
                        case "Đầu bếp":
                            {
                                ListEmployee[i - 1].RoleId = 5;
                                break;
                            }
                        case "Quản lý ca":
                            {
                                ListEmployee[i - 1].RoleId = 6;
                                break;
                            }
                        case "Quản lý nhà hàng":
                            {
                                ListEmployee[i - 1].RoleId = 7;
                                break;
                            }

                    }
                }
            }
        }


        public void RemoveItem(ObservableCollection<Employee> collection, Employee instance)
        {
            collection.Remove(collection.Where(i => i.EmployeeCode == instance.EmployeeCode).Single());
        }
        public ICommand CheckCommand
        {
            get
            {
                if (checkCommand == null)
                    checkCommand = new RelayCommand<object>((i) => { return true; }, i => { Checkprocess(i); }); ;
                return checkCommand;
            }
            set
            {
                checkCommand = value;
                OnPropertyChanged();
            }
        }
        public void Checkprocess(object sender)
        {
           if (IsChecked == true)
            {
                ListEmployeeRoot = getDataEmployee();
            }
            else
            {

                ListEmployeeRoot = getDeletedEmployee();
            }

            //this DOES react when the checkbox is checked or unchecked
        }

    }
}
