using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel.MasterData;

namespace IRES_Project.MasterData.MainPage
{
    /// <summary>
    /// Interaction logic for AddEmp.xaml
    /// </summary>
    public partial class AddEmp : UserControl
    {
        AddEmpViewModel AddEmpVM = new AddEmpViewModel();
        private string EmpConfPassWord = "";
        private string EmpPassWord = "";
        bool MyIsFocused = false;
        bool IsUserNameOk, IsPassWordOK, IsEmailOK = true;
        public AddEmp()
        {
            InitializeComponent();        
            this.DataContext = AddEmpVM;
            ResComb.ItemsSource = AddEmpVM.ListRes;
        }               
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            AddEmpVM.NewEmp.RoleId = AddEmpVM.RoleDict[AddEmpVM.NewEmp.Role]; //update RoleId
            if (AddEmpVM.NewEmp.UserName == "" || AddEmpVM.NewEmp.UserName == "ten_dang_nhap")
            {
                //MessageBox.Show("Tên đăng nhập không hợp lệ");
                IsUserNameOk = false;
                user_name.BorderBrush = System.Windows.Media.Brushes.Red;               
                user_name.Background = (Brush)bc.ConvertFrom("#FCA08C");
                user_name.Text = "Tên đăng nhập không hợp lệ";
                UserNameError.Visibility = Visibility.Visible;
                user_name.GotFocus += TextBox_GotFocus;
            }
            else
            {
                if (!AddEmpVM.CheckUserName())
                {
                    IsUserNameOk = false;
                    user_name.BorderBrush = System.Windows.Media.Brushes.Red;                   
                    user_name.Background = (Brush)bc.ConvertFrom("#FCA08C");
                    user_name.Text = "Tên đăng nhập bị trùng";
                    UserNameError.Visibility = Visibility.Visible;
                    user_name.GotFocus += TextBox_GotFocus;
                    //MessageBox.Show("Tên đăng nhập bị trùng !");
                }
                else
                    IsUserNameOk = true;
            }
           
            if ( EmpPassWord=="")
            {
                PassWordHasError();
                MessageBox.Show("Mật khẩu không hợp lệ!");
            }
            else if (EmpPassWord.Length < 6)
            {
                PassWordHasError();
                MessageBox.Show("Mật khẩu phải có ít nhất 6 kí tự!");
            }
            else if(EmpPassWord != EmpConfPassWord)
            {
                PassWordHasError();
                MessageBox.Show("Mật khẩu không trùng khớp");
            }
            else
            {
                IsPassWordOK = true;
                AddEmpVM.NewEmp.PassWord = EmpPassWord;
            }
           
           if(!IsValidEmail(AddEmpVM.NewEmp.UserEmail))
            {
                IsEmailOK = false;
                NewEmpEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                NewEmpEmail.Background = (Brush)bc.ConvertFrom("#FCA08C");
                NewEmpEmail.GotFocus += NewEmpEmail_GotFocus;
                EmpEmailError.Visibility = Visibility.Visible;
                NewEmpEmail.Text = "Email không hợp lệ !";
            }
           else
            {
                IsEmailOK = true;
            }
           if(IsEmailOK && IsPassWordOK && IsUserNameOk)
            {    
                if (AddEmpVM.NewEmpInsert())
                {
                    MessageBox.Show("Thêm nhân viên thành công !");
                    user_name.Text = "ten_dang_nhap";
                    user_display_name.Text = "Nguyen Van A";
                    this.Visibility = Visibility.Collapsed;
                    ShowEmpPass.Visibility = Visibility.Collapsed;
                    ShowConfEmpPass.Visibility = Visibility.Collapsed;

                    PassW.Visibility = Visibility.Visible;
                    ConfPassW.Visibility = Visibility.Visible;

                    PassShow.Visibility = Visibility.Visible;
                    PassHide.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi khi thêm nhân viên !");
                }
            }
            else
            {
               // MessageBox.Show("Not Ok");
            }
        }

        private void MyEmpPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox a = sender as PasswordBox;
            EmpPassWord = a.Password;
        }

        private void PassW_GotFocus(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Pass");

            //if (!MyIsFocused)
            //{
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.BorderBrush = System.Windows.Media.Brushes.Black;
            tb.Background = System.Windows.Media.Brushes.WhiteSmoke;
            PassError.Visibility = Visibility.Hidden;
            MyIsFocused = true;
            tb.GotFocus -= PassW_GotFocus;
            //    }
            //else
            //{
            //    MyIsFocused = false;
            //}

        }

        private void ConfPassW_GotFocus(object sender, RoutedEventArgs e)
        {

            // MessageBox.Show("ConPass");
            //if (!MyIsFocused)
            //{
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.BorderBrush = System.Windows.Media.Brushes.Black;
            tb.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ConfPassError.Visibility = Visibility.Hidden;
            MyIsFocused = true;
            tb.GotFocus -= ConfPassW_GotFocus;
            //}
            //else
            //{
            //    MyIsFocused = false;
            //}
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("User");

            //if (!MyIsFocused)
            //{
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            MyIsFocused = true;
            UserNameError.Visibility = Visibility.Hidden;
            tb.GotFocus -= TextBox_GotFocus;
            //}
            //else
            //{
            //    MyIsFocused = false;
            //}

        }
        

        private void NewEmpEmail_GotFocus(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Email");
            //if (!MyIsFocused)
            //{
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.BorderBrush = System.Windows.Media.Brushes.Black;
            tb.Background = System.Windows.Media.Brushes.WhiteSmoke;
            MyIsFocused = true;
            EmpEmailError.Visibility = Visibility.Hidden;
            tb.GotFocus -= NewEmpEmail_GotFocus;
            //}
            //else
            //{
            //    MyIsFocused = false;
            //}
        }

      
        //Quay lại
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;



            user_name.Text = "ten_dang_nhap";
            user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;           
            UserNameError.Visibility = Visibility.Hidden;
            user_name.GotFocus += TextBox_GotFocus;

            PassW.Password = "123456";
            PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            PassError.Visibility = Visibility.Hidden;
            PassW.GotFocus += PassW_GotFocus;

            ConfPassW.Password = "123456";
            ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ConfPassError.Visibility = Visibility.Hidden;
            ConfPassW.GotFocus += ConfPassW_GotFocus;

            NewEmpEmail.Text = "nhanvien01@ires.com.vn";
            NewEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            NewEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            EmpEmailError.Visibility = Visibility.Hidden;
            NewEmpEmail.GotFocus += NewEmpEmail_GotFocus;

            ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            ShowEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            ShowConfEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;

            user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            UserNameError.Visibility = Visibility.Hidden;

            PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            PassError.Visibility = Visibility.Hidden;

            ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ConfPassError.Visibility = Visibility.Hidden;

            ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            ShowEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ShowEmpPass.Visibility = Visibility.Collapsed;
            ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            ShowConfEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ShowConfEmpPass.Visibility = Visibility.Collapsed;

            PassW.Visibility = Visibility.Visible;
            ConfPassW.Visibility = Visibility.Visible;

            PassShow.Visibility = Visibility.Visible;
            PassHide.Visibility = Visibility.Hidden;
        }

        private void MyEmpConfPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox a = sender as PasswordBox;
            EmpConfPassWord = a.Password;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void PassShow_Click(object sender, RoutedEventArgs e)
        {
            ShowEmpPass.Text = EmpPassWord;
            ShowConfEmpPass.Text = EmpConfPassWord;
            PassShow.Visibility = Visibility.Hidden;
            PassHide.Visibility = Visibility.Visible;
            ShowEmpPass.Visibility = Visibility.Visible;
            PassW.Visibility = Visibility.Hidden;

            ShowConfEmpPass.Visibility = Visibility.Visible;
            ConfPassW.Visibility = Visibility.Hidden;
        }

        private void PassHide_Click(object sender, RoutedEventArgs e)
        {
            PassW.Password = EmpPassWord;
            ConfPassW.Password = EmpConfPassWord;
            PassShow.Visibility = Visibility.Visible;
            PassHide.Visibility = Visibility.Hidden;
            ShowEmpPass.Visibility = Visibility.Hidden;
            PassW.Visibility = Visibility.Visible;
            ShowConfEmpPass.Visibility = Visibility.Hidden;
            ConfPassW.Visibility = Visibility.Visible;
        }

        private void ShowEmpPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox a = sender as TextBox;
            EmpPassWord = a.Text;
        }

        private void ShowConfEmpPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox a = sender as TextBox;
            EmpConfPassWord = a.Text;
        }

        private void ShowEmpPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BorderBrush = System.Windows.Media.Brushes.Black;
            tb.Background = System.Windows.Media.Brushes.WhiteSmoke;
            PassError.Visibility = Visibility.Hidden;
            tb.GotFocus -= ShowEmpPass_GotFocus;
        }

        private void ShowConfEmpPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BorderBrush = System.Windows.Media.Brushes.Black;
            tb.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ConfPassError.Visibility = Visibility.Hidden;
            tb.GotFocus -= ShowConfEmpPass_GotFocus;
        }
        private void PassWordHasError()
        {
            var bc = new BrushConverter();
            IsPassWordOK = false;
            PassW.Background = (Brush)bc.ConvertFrom("#FCA08C");
            PassW.BorderBrush = System.Windows.Media.Brushes.Red;
            PassW.GotFocus += PassW_GotFocus;
            PassError.Visibility = Visibility.Visible;

            ConfPassW.BorderBrush = System.Windows.Media.Brushes.Red;
            ConfPassW.Background = (Brush)bc.ConvertFrom("#FCA08C");
            ConfPassW.GotFocus += ConfPassW_GotFocus;
            ConfPassError.Visibility = Visibility.Visible;

            ShowEmpPass.Background = (Brush)bc.ConvertFrom("#FCA08C");
            ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Red;

            ShowConfEmpPass.Background = (Brush)bc.ConvertFrom("#FCA08C");
            ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Red;

            ShowEmpPass.GotFocus += ShowEmpPass_GotFocus;
            ShowConfEmpPass.GotFocus += ShowConfEmpPass_GotFocus;
        }
    }
}       
