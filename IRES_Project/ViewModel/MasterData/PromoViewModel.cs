using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.GlobalViewModels;
using Model.Models;
using System.Windows;
using System.Windows.Controls;
using Implements.MasterData.Modules;

namespace ViewModel.MasterData
{
  public  class PromoViewModel : BaseViewModel
    {

        public bool IsSearching = false;
        public string Search_Text { get; set; } = null;

        private bool _Refresh = false;
        public bool Refresh { get { return _Refresh; } set { _Refresh = value; OnPropertyChanged(); } }

        private bool _IsChecked = true;
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; OnPropertyChanged(); } }

        public ICommand SearchCommand { get; set; }
        private ICommand checkCommand;

        public PromoViewModel()
        {
            ListPromo = new List<PromoModel>();
            ListPromo = getListPromo();
            ListPromoRoot = new List<PromoModel>();
            ListPromoRoot = getListPromo();

            if (ListPromo.Count() == 0)
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

        private List<PromoModel> _ListPromo;

        public List<PromoModel> ListPromo
        {
            get { return _ListPromo; }
            set { _ListPromo = value; OnPropertyChanged(); }
        }
        private List<PromoModel> _ListPromoRoot;

        public List<PromoModel> ListPromoRoot
        {
            get { return _ListPromoRoot; }
            set { _ListPromoRoot = value; OnPropertyChanged(); }
        }

        public List<PromoModel> getListPromo()
        {
            IsSearching = false;
            List<PromoModel> listPromo = new List<PromoModel>();
            listPromo = PromoImplement.getDBListPromo();
            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listPromo.Clear();
            }
            return listPromo;
        }

        public List<PromoModel> getDeletedPromo()
        {
            IsSearching = false;
            List<PromoModel> listPromo = new List<PromoModel>();
            listPromo = PromoImplement.getDBListDeletedPromo();
            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listPromo.Clear();
            }
            return listPromo;
        }
        public List<PromoModel> searchDish()
        {
            List<PromoModel> listPromo = new List<PromoModel>();
            if (Search_Text == null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listPromo;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listPromo;
            }
            listPromo = PromoImplement.searchDBListPromo(Search_Text);

            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                //MessageBox.Show("Không có kết quả");
                listPromo.Clear();
                return listPromo;
            }
            IsSearching = true;
            return listPromo;
        }
        public List<PromoModel> searchDeletedDish()
        {
            List<PromoModel> listPromo = new List<PromoModel>();
            if (Search_Text == null)
            {
                MessageBox.Show("Vui lòng gõ nội dung tìm kiếm");
                return listPromo;
            }
            else if (Search_Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm không được rỗng");
                return listPromo;
            }
            listPromo = PromoImplement.searchDBListDeletedPromo(Search_Text);

            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                //MessageBox.Show("Không có kết quả");
                listPromo.Clear();
                return listPromo;
            }
            IsSearching = true;
            return listPromo;
        }
        //public bool UpdatePhoneNb(string phoneNb, string employee_code)
        //{

        //    return EmployeeImplement.UpdatePhone(phoneNb, employee_code);
        //}


        //public bool DeleteEmployee(string employee_code, Employee a)
        //{
        //    RemoveItem(ListEmployeeRoot, a);
        //    return EmployeeImplement.DeleteEmp(employee_code);
        //}
        //public bool ActiveEmployee(string employee_code, Employee a)
        //{
        //    RemoveItem(ListEmployeeRoot, a);
        //    return EmployeeImplement.ActiveEmp(employee_code);
        //}
        //public bool UpdateRole(int RoleId, string employee_code)
        //{

        //    return EmployeeImplement.UpdateRole(RoleId, employee_code);
        //}
        //public void UpdateLocalEmpRoleId(string Role, string employee_code)
        //{
        //    for (int i = 1; i <= ListEmployee.Count(); i++)
        //    {
        //        if (ListEmployee[i - 1].EmployeeCode == employee_code)
        //        {
        //            switch (Role)
        //            {
        //                case "Nhân viên phục vụ":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 1;
        //                        break;
        //                    }
        //                case "Bếp trưởng":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 2;
        //                        break;
        //                    }
        //                case "Thu ngân":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 3;
        //                        break;
        //                    }

        //                case "Lễ tân":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 4;
        //                        break;
        //                    }
        //                case "Đầu bếp":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 5;
        //                        break;
        //                    }
        //                case "Quản lý ca":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 6;
        //                        break;
        //                    }
        //                case "Quản lý nhà hàng":
        //                    {
        //                        ListEmployee[i - 1].RoleId = 7;
        //                        break;
        //                    }

        //            }
        //        }
        //    }
        //}


        //public void RemoveItem(ObservableCollection<Employee> collection, Employee instance)
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
