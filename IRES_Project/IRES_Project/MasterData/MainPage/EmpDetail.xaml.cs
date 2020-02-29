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
    /// Interaction logic for EmpDetail.xaml
    /// </summary>
    public partial class EmpDetail : UserControl
    {
        string CurUserName = "";
        Employee TempEmp = new Employee();
        EmpDetailViewModel EditEmpVM = new EmpDetailViewModel();
        private string EmpConfPassWord = "";
        private string EmpPassWord = "";
        bool MyIsFocused = false;
        
        public EmpDetail()
        {
            InitializeComponent();
            this.DataContext = EditEmpVM;
            ResComb.ItemsSource = EditEmpVM.ListRes;
        }
         
         //Quay lại
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
            #region Revert
            //EditEmpVM.CurEmp.Active = TempEmp.Active;
            //EditEmpVM.CurEmp.CreatedBy = TempEmp.CreatedBy;
            //EditEmpVM.CurEmp.CreatedDatetime = TempEmp.CreatedDatetime;
            //EditEmpVM.CurEmp.EmployeeCode = TempEmp.EmployeeCode;
            //EditEmpVM.CurEmp.EmployeeDescription = TempEmp.EmployeeDescription;
            //EditEmpVM.CurEmp.EmployeeId = TempEmp.EmployeeId;
            //EditEmpVM.CurEmp.EmployeeName = TempEmp.EmployeeName;
            //EditEmpVM.CurEmp.EmployeeStatus = TempEmp.EmployeeStatus;
            //EditEmpVM.CurEmp.PassWord = TempEmp.PassWord;
            //EditEmpVM.CurEmp.PhoneNb = TempEmp.PhoneNb;
            //EditEmpVM.CurEmp.RestaurantId = TempEmp.RestaurantId;
            //EditEmpVM.CurEmp.Role = TempEmp.Role;
            //EditEmpVM.CurEmp.RoleId = TempEmp.RoleId;
            //EditEmpVM.CurEmp.UpdatedBy = TempEmp.UpdatedBy;
            //EditEmpVM.CurEmp.UpdatedDatetime = TempEmp.UpdatedDatetime;
            //EditEmpVM.CurEmp.UserAddress = TempEmp.UserAddress;
            //EditEmpVM.CurEmp.UserEmail = TempEmp.UserEmail;
            //EditEmpVM.CurEmp.UserId = TempEmp.UserId;
            //EditEmpVM.CurEmp.UserName = TempEmp.UserName;
            //EditEmpVM.CurEmp.Version = TempEmp.Version;

            //EmpPassWord = TempEmp.PassWord;
            //EmpConfPassWord = EmpPassWord;

            //PassW.Password = EmpPassWord;
            //ConfPassW.Password = EmpPassWord;

            //user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            //user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //UserNameError.Visibility = Visibility.Hidden;

            //PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //PassError.Visibility = Visibility.Hidden;

            //ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ConfPassError.Visibility = Visibility.Hidden;

            //CurEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            //CurEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //EmpEmailError.Visibility = Visibility.Hidden;

            //ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;

            //ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowConfEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;

            ShowConfEmpPass.Visibility = Visibility.Collapsed;
            ShowEmpPass.Visibility = Visibility.Collapsed;
            PassW.Visibility = Visibility.Visible;
            ConfPassW.Visibility = Visibility.Visible;

            PassShow.Visibility = Visibility.Visible;
            PassHide.Visibility = Visibility.Hidden;
            #endregion
        }
        private void PassShow_Click(object sender, RoutedEventArgs e)
        {
            ShowEmpPass.Text = PassW.Password;
            ShowConfEmpPass.Text = ConfPassW.Password;

            PassShow.Visibility = Visibility.Hidden;
            PassHide.Visibility = Visibility.Visible;
            ShowEmpPass.Visibility = Visibility.Visible;      
            ShowConfEmpPass.Visibility = Visibility.Visible;
            PassW.Visibility = Visibility.Hidden;
            ConfPassW.Visibility = Visibility.Hidden;
        }

        private void PassHide_Click(object sender, RoutedEventArgs e)
        {
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
        public void CopyEmployee(Employee From, ref Employee To)
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
    }
}
