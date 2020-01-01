using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class UserModel
    {
        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        private string username;
        private string password;
        private string role;

        public string Username  { 
            get { 
                return username;
                } 
            set {  
                username = value;
                } 
                                }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role { get => role; set => role = value; }
    }
}
