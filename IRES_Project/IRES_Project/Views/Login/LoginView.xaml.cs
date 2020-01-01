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
using ViewModel.Modules;
using Model.Models;

namespace IRES_Project
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel loginViewModel = null;
        public Login()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loginViewModel.PassWord = txtPassword.Password;
                Boolean checkLogin = loginViewModel.checkUser();

                if (checkLogin == true)
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại!");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

        private void BtnCancelLogin_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void PackIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("123");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
