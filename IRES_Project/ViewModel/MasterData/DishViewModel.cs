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
        
        private string _Search_Text;
        public string Search_Text { get { return _Search_Text; } set { _Search_Text = value; OnPropertyChanged(); } }

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
            IsSearching = true;
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
            
            return listDishes;
        }
        public ObservableCollection<DishModel> searchDeletedDish()
        {
            IsSearching = true;
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
            
            return listDishes;
        }
        //public bool UpdatePhoneNb(string phoneNb, string employee_code)
        //{

        //    return DishImplement.UpdatePhone(phoneNb, employee_code);
        //}


        public bool DeleteDish(string dish_code, DishModel a)
        {
            RemoveItem(ListDishesRoot, a);
            return DishImplement.DeleteDish(dish_code);
        }
        public bool ActiveDish(string dish_code, DishModel a)
        {
            RemoveItem(ListDishesRoot, a);
            return DishImplement.ActiveDish(dish_code);
        }
        public void RemoveItem(ObservableCollection<DishModel> collection, DishModel instance)
        {
            collection.Remove(collection.Where(i => i.DishCode == instance.DishCode).Single());
        }
    }
}
