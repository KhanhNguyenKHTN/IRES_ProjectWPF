using Model.Models;
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
    /// Interaction logic for EditEmp.xaml
    /// </summary>
    public partial class EditEmp : UserControl
    {
        EditEmpViewModel EditEmpVM = new EditEmpViewModel();
        private string EmpConfPassWord = "";
        private string EmpPassWord = "";
        bool MyIsFocused = false;
        bool IsUserNameOk, IsPassWordOK, IsEmailOK = true;
        public EditEmp()
        {
            InitializeComponent();
            this.DataContext = EditEmpVM;
            ResComb.ItemsSource = EditEmpVM.ListRes;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            EditEmpVM.CurEmp.RoleId = EditEmpVM.RoleDict[EditEmpVM.CurEmp.Role]; //update RoleId
            if (EditEmpVM.CurEmp.UserName == "" || EditEmpVM.CurEmp.UserName == "ten_dang_nhap")
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
                if (!EditEmpVM.CheckUserName())
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

            if (EmpPassWord == "" || EmpPassWord.Length < 6)
            {
                PassWordHasError();
                MessageBox.Show("Password không hợp lệ");
            }
            else if (EmpPassWord != EmpConfPassWord)
            {
                PassWordHasError();
                MessageBox.Show("Password không trùng khớp");
            }
            else
            {
                IsPassWordOK = true;
                EditEmpVM.CurEmp.PassWord = EmpPassWord;
            }

            if (!IsValidEmail(EditEmpVM.CurEmp.UserEmail))
            {
                IsEmailOK = false;
                CurEmpEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                CurEmpEmail.Background = (Brush)bc.ConvertFrom("#FCA08C");
                CurEmpEmail.GotFocus += CurEmpEmail_GotFocus;
                EmpEmailError.Visibility = Visibility.Visible;
                MessageBox.Show("Email không hợp lệ");
            }
            else
            {
                IsEmailOK = true;
            }
            if (IsEmailOK && IsPassWordOK && IsUserNameOk)
            {


                if (EditEmpVM.CurEmpInsert())
                {
                    MessageBox.Show("Thêm nhân viên thành công !");
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


        private void CurEmpEmail_GotFocus(object sender, RoutedEventArgs e)
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
            tb.GotFocus -= CurEmpEmail_GotFocus;
            //}
            //else
            //{
            //    MyIsFocused = false;
            //}
        }



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

            CurEmpEmail.Text = "nhanvien01@ires.com.vn";
            CurEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            CurEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            EmpEmailError.Visibility = Visibility.Hidden;
            CurEmpEmail.GotFocus += CurEmpEmail_GotFocus;


        }

        private void MyEmpConfPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox a = sender as PasswordBox;
            EmpConfPassWord = a.Password;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

            //user_name.Text = "ten_dang_nhap";
            //user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            //user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //UserNameError.Visibility = Visibility.Hidden;
            //user_name.GotFocus += TextBox_GotFocus;

            //PassW.Password = "123456";
            //PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //PassError.Visibility = Visibility.Hidden;
            //PassW.GotFocus += PassW_GotFocus;

            //ConfPassW.Password = "123456";
            //ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ConfPassError.Visibility = Visibility.Hidden;
            //ConfPassW.GotFocus += ConfPassW_GotFocus;

            //CurEmpEmail.Text = "nhanvien01@ires.com.vn";
            //CurEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            //CurEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //EmpEmailError.Visibility = Visibility.Hidden;
            //CurEmpEmail.GotFocus += CurEmpEmail_GotFocus;

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
        }
        public void TakeEmp(Employee A)
        {
            EditEmpVM.CurEmp = A;
        }
    }
}
