using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.MasterData.Modules;
using ViewModel.GlobalViewModels;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace ViewModel.MasterData
{
    public class DishViewModel: BaseViewModel
    {

        public bool IsSearching = false;
        public string Search_Text { get; set; } = null;

        private bool _Refresh = false;
        public bool Refresh { get { return _Refresh; } set { _Refresh = value; OnPropertyChanged(); } }

        private bool _IsChecked = true;
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; OnPropertyChanged(); } }

        public ICommand SearchCommand { get; set; }
        private ICommand checkCommand;

        public DishViewModel()
        {
            ListDishes = new ObservableCollection<DishModel>();
            ListDishes = getListDishes();
            ListDishesRoot = new ObservableCollection<DishModel>();
            ListDishesRoot = getListDishes();

            if (ListDishes.Count() == 0)
            {
                MessageBox.Show("Khong co data");
            }

            SearchCommand = new RelayCommand<TextBox>((p) => { return (p.Text == null || p.Text == "") ? false : true; },
                (p) =>
                {
                    Search_Text = p.Text;
                    if (Refresh == true)
                    {
                        Refresh = false;
                    }
                    else
                        Refresh = true;
                });
        }

        private ObservableCollection<DishModel> _ListDishes;

        public ObservableCollection<DishModel> ListDishes
        {
            get { return _ListDishes; }
            set { _ListDishes = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DishModel> _ListDishesRoot;

        public ObservableCollection<DishModel> ListDishesRoot
        {
            get { return _ListDishesRoot; }
            set { _ListDishesRoot = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DishModel> getListDishes()
        {
            IsSearching = false;
            ObservableCollection<DishModel> listDishes = new ObservableCollection<DishModel>();  
            listDishes = DishImplement.getDBListDishes();
            DishModel X = listDishes.First();
            if (X.DishId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listDishes.Clear();
            }

            return listDishes;
        }
      
        public ObservableCollection<DishModel> getDeletedDishes()
        {
            IsSearching = false;
            ObservableCollection<DishModel> listDishes = new ObservableCollection<DishModel>();
            listDishes = DishImplement.getDBListDeletedDishes();
            DishModel X = listDishes.First();
            if (X.DishId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listDishes.Clear();
            }
            return listDishes;
        }
        public ObservableCollection<DishModel> searchDish()
        {
            ObservableCollection<DishModel> listDishes = new ObservableCollection<DishModel>();
            if (Search_Text == null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listDishes;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listDishes;
            }
            listDishes = DishImplement.searchDBListDishes(Search_Text);

            DishModel X = listDishes.First();
            if (X.DishId == -1)
            {
                //MessageBox.Show("Không có kết quả");
                listDishes.Clear();
                return listDishes;
            }
            IsSearching = true;
            return listDishes;
        }
        public ObservableCollection<DishModel> searchDeletedDish()
        {
            ObservableCollection<DishModel> listDishes = new ObservableCollection<DishModel>();
            if (Search_Text == null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listDishes;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listDishes;
            }
            listDishes = DishImplement.searchDBListDishesDeleted(Search_Text);
            DishModel X = listDishes.First();
            if (X.DishId == -1)
            {
                //MessageBox.Show("Không có kết quả");
                listDishes.Clear();
                return listDishes;
            }
            IsSearching = true;
            return listDishes;
        }
        //public bool UpdatePhoneNb(string phoneNb, string employee_code)
        //{

        //    return DishImplement.UpdatePhone(phoneNb, employee_code);
        //}


        //public bool DeleteEmployee(string employee_code, DishModel a)
        //{
        //    RemoveItem(ListEmployeeRoot, a);
        //    return DishImplement.DeleteEmp(employee_code);
        //}
        //public bool ActiveEmployee(string employee_code, DishModel a)
        //{
        //    RemoveItem(ListEmployeeRoot, a);
        //    return DishImplement.ActiveEmp(employee_code);
        //}
        //public bool UpdateRole(int RoleId, string employee_code)
        //{

        //    return DishImplement.UpdateRole(RoleId, employee_code);
        //}
        //public void UpdateLocalEmpRoleId(string Role, string employee_code)
        //{
        //    for (int i = 1; i <= listDishes.Count(); i++)
        //    {
        //        if (listDishes[i - 1].EmployeeCode == employee_code)
        //        {
        //            switch (Role)
        //            {
        //                case "Nhân viên phục vụ":
        //                    {
        //                        listDishes[i - 1].RoleId = 1;
        //                        break;
        //                    }
        //                case "Bếp trưởng":
        //                    {
        //                        listDishes[i - 1].RoleId = 2;
        //                        break;
        //                    }
        //                case "Thu ngân":
        //                    {
        //                        listDishes[i - 1].RoleId = 3;
        //                        break;
        //                    }

        //                case "Lễ tân":
        //                    {
        //                        listDishes[i - 1].RoleId = 4;
        //                        break;
        //                    }
        //                case "Đầu bếp":
        //                    {
        //                        listDishes[i - 1].RoleId = 5;
        //                        break;
        //                    }
        //                case "Quản lý ca":
        //                    {
        //                        listDishes[i - 1].RoleId = 6;
        //                        break;
        //                    }
        //                case "Quản lý nhà hàng":
        //                    {
        //                        listDishes[i - 1].RoleId = 7;
        //                        break;
        //                    }

        //            }
        //        }
        //    }
        //}


        //public void RemoveItem(ObservableCollection<DishModel> collection, DishModel instance)
        //{
        //    collection.Remove(collection.Where(i => i.EmployeeCode == instance.EmployeeCode).Single());
        //}
        //public ICommand CheckCommand
        //{
        //    get
        //    {
        //        if (checkCommand == null)
        //            checkCommand = new RelayCommand<object>((i) => { return true; }, i => { Checkprocess(i); }); ;
        //        return checkCommand;
        //    }
        //    set
        //    {
        //        checkCommand = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public void Checkprocess(object sender)
        //{
        //    if (IsChecked == true)
        //    {
        //        ListEmployeeRoot = getDataEmployee();
        //    }
        //    else
        //    {

        //        ListEmployeeRoot = getDeletedEmployee();
        //    }

        //    //this DOES react when the checkbox is checked or unchecked
        //}

    }
}
