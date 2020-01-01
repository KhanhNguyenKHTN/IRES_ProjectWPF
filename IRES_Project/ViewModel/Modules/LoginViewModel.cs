using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Windows;
using System.Collections.ObjectModel;
using ViewModel.GlobalViewModels;
using Implements.Common;

namespace ViewModel.Modules
{
    public class LoginViewModel: BaseViewModel
    {
        public LoginViewModel()
        {
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
 
            set { _UserName = value; OnPropertyChanged(); }
        }

        private string _PassWord;

        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; OnPropertyChanged(); }
        }

        public Boolean checkUser()
        {
            LoginImplement loginImp = new LoginImplement();
            UserModel user = loginImp.getUser(new UserModel(UserName, PassWord));

            if (user.Role != null && user.Role == "7")
            {
                return true;
            }

            return false;
        }
    }
}
