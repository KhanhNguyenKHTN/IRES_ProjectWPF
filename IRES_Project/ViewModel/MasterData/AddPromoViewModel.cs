using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.GlobalViewModels;

namespace ViewModel.MasterData
{
    public class AddPromoViewModel : BaseViewModel
    {
        public List<string> ListRes { get; set; } = new List<string>() { "IRES cơ sở 1" };
        public List<string> PromoUnitList { get; set; } = new List<string>() { "VNĐ", "%" };
        public int Promo_Id = -1;
        
        public Dictionary<string, string> RoleDict { get; set; } = new Dictionary<string, string>()
        { {"ALL","Tất cả" }, { "CUSTOMER", "Khách hàng" } };
        public AddPromoViewModel()
        {


        }

        private PromoModel _NewPromo = new PromoModel();

        public PromoModel NewPromo
        {
            get { return _NewPromo; }
            set { _NewPromo = value; OnPropertyChanged(); }
        }

        //public bool InsertNewPromo()
        //{
        //    if (EmployeeImplement.InsertUserToDb(NewEmp, ref User_Id))
        //        NewEmp.UserId = User_Id;
        //    else
        //        return false;
        //    if (EmployeeImplement.InsertEmpToDb(NewEmp))
        //        return true;
        //    else
        //        return false;
        //}
    }
}
