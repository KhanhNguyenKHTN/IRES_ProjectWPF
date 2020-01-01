using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Windows;
using System.Collections.ObjectModel;
using Model.DB;
using ViewModel.GlobalViewModels;

namespace ViewModel.Modules
{
    public class LoginViewModel: BaseViewModel
    {
        private User user;
        Connection DataContext = null;
        public LoginViewModel()
        {
            //this.user = new User(user.Username, user.Password);
            DataContext = Connection.Instance;
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

        public ObservableCollection<User> User
        {
            get;
            set;
        }
       
        public Boolean checkUser()
        {
            string query = "SELECT 1 FROM employee WHERE user_name='{this.UserName}' and password='{this.PassWord}'";

            return DataContext.runCommand(query);
        }
    }
}
