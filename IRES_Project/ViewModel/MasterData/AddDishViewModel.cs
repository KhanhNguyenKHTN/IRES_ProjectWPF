using Implements.MasterData.Modules;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.GlobalViewModels;

namespace ViewModel.MasterData
{
   public class AddDishViewModel : BaseViewModel
    {
        public ObservableCollection<string> ListRes = new ObservableCollection<string>() { "IRES cơ sở 1" };
        public ObservableCollection<string> DishTypeList { get; set; } = new ObservableCollection<string>() { "Khai vị", "Món chính","Món lẩu","Tráng miệng"};
        
        public string Unit { get; set; } = "Kg";
        public int ItemIndex { get; set; } = 10;
        public ObservableCollection<ItemModel> ListItem { get; set; } = new ObservableCollection<ItemModel>();
        

        public int dish_Id = -1;
        public Dictionary<int, string> ItemDict { get; set; } = new Dictionary<int, string>();

        private Dictionary<int, Double> priceDict;

        public Dictionary<int, Double> PriceDict
        {
            get { return priceDict; }
            set { priceDict = value; OnPropertyChanged(); }
        }

        private Dictionary<int, string> dishCateDict;

        public Dictionary<int, string> DishCateDict
        {
            get { return dishCateDict; }
            set { dishCateDict = value; OnPropertyChanged(); }
        }


        private ObservableCollection<DishItem> listDishItem = new ObservableCollection<DishItem>();

        public ObservableCollection<DishItem> ListDishItem
        {
            get { return listDishItem; }
            set { listDishItem = value; OnPropertyChanged(); }
        }


        public AddDishViewModel()
        {
            
            ListDishItem.Add(new DishItem());
           
            DishCateDict = GetListCategory();
            ListItem = GetListItem();
            ItemDict = ListItem.Select(p => new { id = p.ItemId, name = p.ItemName }).ToDictionary(x => x.id, x => x.name);

            PriceDict = new Dictionary<int, Double>();
            PriceDict = ListItem.Select(p => new { id = p.ItemId, name = p.ItemUnitPrice }).ToDictionary(x => x.id, x => x.name);
            

        }

        private DishModel _NewDish = new DishModel();

        public DishModel NewDish
        {
            get { return _NewDish; }
            set { _NewDish = value; OnPropertyChanged(); }
        }


        public bool NewDishInsert(string hour, string min)
        {

            if (DishImplement.InsertDishToDb(NewDish, ref dish_Id, hour, min))
            {
                NewDish.DishId = dish_Id;
                DishImplement.UpdateDishCode(dish_Id);
                int itemId = -1;
                foreach (DishItem a in listDishItem)
                {
                    DishImplement.InsertDishItemToDb(a, ref itemId, dish_Id);
                    if (itemId != -1)
                    {
                        DishImplement.UpdateItemCode(itemId);
                        itemId = -1;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm DishItem");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm DishItem");
                return false;
            }
            return true;
        }
        public ObservableCollection<ItemModel> GetListItem()
        {
            ObservableCollection<ItemModel> ListItemTemp = new ObservableCollection<ItemModel>();
            ListItemTemp = DishImplement.getDBListItem();
            ItemModel X = ListItemTemp.First();
            if (X.ItemId == -1)
            {
                MessageBox.Show("Không có kết quả");
                ListItemTemp.Clear();
            }
           
            return ListItemTemp;
        }
        public Dictionary<int, string> GetListCategory()
        {
            Dictionary<int, string> DictTemp = new Dictionary<int, string>();
            DictTemp = DishImplement.getDBListCategory();      
            if (DictTemp[1] == "None")
            {
                MessageBox.Show("Không có kết quả");
                DictTemp.Clear();
            }
            return DictTemp;
        }

    }
}
