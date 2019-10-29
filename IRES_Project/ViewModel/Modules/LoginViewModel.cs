using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Windows;
using System.Collections.ObjectModel;
using Model.DB;

namespace ViewModel.Modules
{
    public class LoginViewModel
    {
        private User user;
        public LoginViewModel(User user)
        {
            this.user = new User(user.Username, user.Password);
        }

        public ObservableCollection<User> User
        {
            get;
            set;
        }

        public Boolean checkUser(User user)
        {
            Connection cn = new Connection();
            cn.connectDB();
            cn.openfConnection();

            string query = $"SELECT 1 FROM employee WHERE user_name='{user.Username}' and password='{user.Password}'";

            return cn.runCommand(query);
        }
    }
}
