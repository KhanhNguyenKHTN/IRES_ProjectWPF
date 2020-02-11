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
        string CurUserName = "";
        Employee TempEmp = new Employee();
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
                if (EditEmpVM.CheckUserName() || EditEmpVM.CurEmp.UserName == CurUserName)
                {
                    IsUserNameOk = true;
                }
                else
                {
                    IsUserNameOk = false;
                    user_name.BorderBrush = System.Windows.Media.Brushes.Red;
                    user_name.Background = (Brush)bc.ConvertFrom("#FCA08C");
                    user_name.Text = "Tên đăng nhập bị trùng";
                    UserNameError.Visibility = Visibility.Visible;
                    //MessageBox.Show("Tên đăng nhập bị trùng !");
                }
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
                CurEmpEmail.Text = "Email không hợp lệ !";
            }
            else
            {
                IsEmailOK = true;
            }
            if (IsEmailOK && IsPassWordOK && IsUserNameOk)
            {
               

                if (EditEmpVM.CurEmpEdit())
                {
                    MessageBox.Show("Chỉnh sửa thông tin thành công !");
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
                    MessageBox.Show("Xảy ra lỗi khi chỉnh sửa !");
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
            if (tb.Text == "Email không hợp lệ !")
                tb.Text = "";
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

        private void MyEmpConfPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox a = sender as PasswordBox;
            EmpConfPassWord = a.Password;
        }
        //Quay lại
        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
            this.Visibility = Visibility.Collapsed;
            EditEmpVM.CurEmp.Active = TempEmp.Active;
            EditEmpVM.CurEmp.CreatedBy = TempEmp.CreatedBy;
            EditEmpVM.CurEmp.CreatedDatetime = TempEmp.CreatedDatetime;
            EditEmpVM.CurEmp.EmployeeCode = TempEmp.EmployeeCode;
            EditEmpVM.CurEmp.EmployeeDescription = TempEmp.EmployeeDescription;
            EditEmpVM.CurEmp.EmployeeId = TempEmp.EmployeeId;
            EditEmpVM.CurEmp.EmployeeName = TempEmp.EmployeeName;
            EditEmpVM.CurEmp.EmployeeStatus = TempEmp.EmployeeStatus;
            EditEmpVM.CurEmp.PassWord = TempEmp.PassWord;
            EditEmpVM.CurEmp.PhoneNb = TempEmp.PhoneNb;
            EditEmpVM.CurEmp.RestaurantId = TempEmp.RestaurantId;
            EditEmpVM.CurEmp.Role = TempEmp.Role;
            EditEmpVM.CurEmp.RoleId = TempEmp.RoleId;
            EditEmpVM.CurEmp.UpdatedBy = TempEmp.UpdatedBy;
            EditEmpVM.CurEmp.UpdatedDatetime = TempEmp.UpdatedDatetime;
            EditEmpVM.CurEmp.UserAddress = TempEmp.UserAddress;
            EditEmpVM.CurEmp.UserEmail = TempEmp.UserEmail;
            EditEmpVM.CurEmp.UserId = TempEmp.UserId;
            EditEmpVM.CurEmp.UserName = TempEmp.UserName;
            EditEmpVM.CurEmp.Version = TempEmp.Version;

            EmpPassWord = TempEmp.PassWord;
            EmpConfPassWord = EmpPassWord;

            PassW.Password = EmpPassWord;
            ConfPassW.Password = EmpPassWord;

            user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            UserNameError.Visibility = Visibility.Hidden;

            PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            PassError.Visibility = Visibility.Hidden;

            ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            ConfPassError.Visibility = Visibility.Hidden;

            CurEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            CurEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            EmpEmailError.Visibility = Visibility.Hidden;

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

            ShowEmpPass.Background = (Brush)bc.ConvertFrom("#FCA08C");
            ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Red;

            ShowConfEmpPass.Background = (Brush)bc.ConvertFrom("#FCA08C");
            ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Red;

            ShowEmpPass.GotFocus += ShowEmpPass_GotFocus;
            ShowConfEmpPass.GotFocus += ShowConfEmpPass_GotFocus;

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

      
            

        public void TakeEmp(Employee A)
        {
            CopyEmployee(A, ref TempEmp);
          
            EditEmpVM.CurEmp = A;
            CurUserName = A.UserName;
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

        public void CopyEmployee( Employee From , ref Employee To)
        {
            To.Active = From.Active;
            To.CreatedBy = From.CreatedBy;
            To.CreatedDatetime = From.CreatedDatetime;
            To.EmployeeCode = From.EmployeeCode;
            To.EmployeeDescription = From.EmployeeDescription;
            To.EmployeeId = From.EmployeeId;
            To.EmployeeName = From.EmployeeName;
            To.EmployeeStatus = From.EmployeeStatus;
            To.PassWord = From.PassWord;
            To.PhoneNb = From.PhoneNb;
            To.RestaurantId = From.RestaurantId;
            To.Role = From.Role;
            To.RoleId = From.RoleId;
            To.UpdatedBy = From.UpdatedBy;
            To.UpdatedDatetime = From.UpdatedDatetime;
            To.UserAddress = From.UserAddress;
            To.UserEmail = From.UserEmail;
            To.UserId = From.UserId;
            To.UserName = From.UserName;
            To.Version = From.Version;
            PassW.Password = From.PassWord;
            ConfPassW.Password = From.PassWord;
        }
        void HideError()
        {
            EmpEmailError.Visibility = Visibility.Hidden;
            ConfPassError.Visibility = Visibility.Hidden;
            PassError.Visibility = Visibility.Hidden;
            UserNameError.Visibility = Visibility.Hidden;
        }
    }
}
