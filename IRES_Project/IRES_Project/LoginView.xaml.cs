using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;
using ViewModel.Modules;
using Model.Models;

namespace IRES_Project
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Window
    {   
        public loginPage()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {   try
            {
                User user = new User( txtUsername.Text, txtPassword.Password);
                LoginViewModel loginViewModel = new LoginViewModel(user);

                Boolean login = loginViewModel.checkUser(user);

                if (login == true )
                {
                    MessageBox.Show("Login thanh cong");
                }
                else
                {
                    MessageBox.Show("Login that bai");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }     
    }
}
