using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Implements.MasterData.Modules;
using ViewModel.GlobalViewModels;

namespace ViewModel.MasterData
{
    public class DishViewModel: BaseViewModel
    {
        public DishViewModel()
        {
            _ListDishes = getListDishes();
        }

        private List<DishModel> _ListDishes;

        public List<DishModel> ListDishes 
        { get { return _ListDishes; }
          set { _ListDishes = value;  OnPropertyChanged(); }
        }

        public List<DishModel> getListDishes()
        {
            List<DishModel> listDishes = new List<DishModel>();
            DishImplement dishImp = new DishImplement();
            listDishes = dishImp.getLishDishes();
            return listDishes;
        }
    }
}
