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
using System.Collections.ObjectModel;

namespace ViewModel.MasterData
{
  public  class PromoViewModel : BaseViewModel
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

        public PromoViewModel()
        {
            ListPromo = new ObservableCollection<PromoModel>();
            ListPromo = getListPromo();
            ListPromoRoot = new ObservableCollection<PromoModel>();
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

        private ObservableCollection<PromoModel> _ListPromo;

        public ObservableCollection<PromoModel> ListPromo
        {
            get { return _ListPromo; }
            set { _ListPromo = value; OnPropertyChanged(); }
        }
        private ObservableCollection<PromoModel> _ListPromoRoot;

        public ObservableCollection<PromoModel> ListPromoRoot
        {
            get { return _ListPromoRoot; }
            set { _ListPromoRoot = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PromoModel> getListPromo()
        {
            IsSearching = false;
            ObservableCollection<PromoModel> listPromo = new ObservableCollection<PromoModel>();
            listPromo = PromoImplement.getDBListPromo();
            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listPromo.Clear();
            }
            return listPromo;
        }

        public ObservableCollection<PromoModel> getDeletedPromo()
        {
            IsSearching = false;
            ObservableCollection<PromoModel> listPromo = new ObservableCollection<PromoModel>();
            listPromo = PromoImplement.getDBListDeletedPromo();
            PromoModel X = listPromo.First();
            if (X.PromotionId == -1)
            {
                MessageBox.Show("Không có kết quả");
                listPromo.Clear();
            }
            return listPromo;
        }
        public ObservableCollection<PromoModel> searchPromo()
        {
            IsSearching = true;
            ObservableCollection<PromoModel> listPromo = new ObservableCollection<PromoModel>();
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
            
            return listPromo;
        }
        public ObservableCollection<PromoModel> searchDeletedPromo()
        {
            IsSearching = true;
            ObservableCollection<PromoModel> listPromo = new ObservableCollection<PromoModel>();
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
           
            return listPromo;
        }



        public bool DeletePromo(string promo_code, PromoModel a)
        {
            RemoveItem(ListPromoRoot, a);
            return PromoImplement.DeletePromo(promo_code);
        }
        public bool ActivePromo(string promo_code, PromoModel a)
        {
            RemoveItem(ListPromoRoot, a);
            return PromoImplement.ActivePromo(promo_code);
        }
       


        public void RemoveItem(ObservableCollection<PromoModel> collection, PromoModel instance)
        {
            collection.Remove(collection.Where(i => i.PromotionCode == instance.PromotionCode).Single());
        }
       

    }
}
