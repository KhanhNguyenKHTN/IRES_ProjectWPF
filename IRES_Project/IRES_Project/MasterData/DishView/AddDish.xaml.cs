using Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace IRES_Project.MasterData.DishView
{
    /// <summary>
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : UserControl
    {

        AddDishViewModel AddDishVm = new AddDishViewModel();
        bool MyIsFocused = false;
        bool IsUserNameOk, IsEmailOK = true;

        public AddDish()
        {
            InitializeComponent();
            this.DataContext = AddDishVm;
            ResComb.ItemsSource = AddDishVm.ListRes;
        }
        #region chua làm
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            //#region save
            //var bc = new BrushConverter();
            //AddDishVm.NewEmp.RoleId = AddDishVm.RoleDict[AddDishVm.NewEmp.Role]; //update RoleId
            //if (AddDishVm.NewEmp.UserName == "" || AddDishVm.NewEmp.UserName == "ten_dang_nhap")
            //{
            //    //MessageBox.Show("Tên đăng nhập không hợp lệ");
            //    IsUserNameOk = false;
            //    user_name.BorderBrush = System.Windows.Media.Brushes.Red;
            //    user_name.Background = (Brush)bc.ConvertFrom("#FCA08C");
            //    user_name.Text = "Tên đăng nhập không hợp lệ";
            //    UserNameError.Visibility = Visibility.Visible;
            //    user_name.GotFocus += TextBox_GotFocus;
            //}
            //else
            //{
            //    if (!AddDishVm.CheckUserName())
            //    {
            //        IsUserNameOk = false;
            //        user_name.BorderBrush = System.Windows.Media.Brushes.Red;
            //        user_name.Background = (Brush)bc.ConvertFrom("#FCA08C");
            //        user_name.Text = "Tên đăng nhập bị trùng";
            //        UserNameError.Visibility = Visibility.Visible;
            //        user_name.GotFocus += TextBox_GotFocus;
            //        //MessageBox.Show("Tên đăng nhập bị trùng !");
            //    }
            //    else
            //        IsUserNameOk = true;
            //}

            //if (EmpPassWord == "" || EmpPassWord.Length < 6)
            //{
            //    PassWordHasError();
            //    MessageBox.Show("Password không hợp lệ");
            //}
            //else if (EmpPassWord != EmpConfPassWord)
            //{
            //    PassWordHasError();
            //    MessageBox.Show("Password không trùng khớp");
            //}
            //else
            //{
            //    IsPassWordOK = true;
            //    AddDishVm.NewEmp.PassWord = EmpPassWord;
            //}

            //if (!IsValidEmail(AddDishVm.NewEmp.UserEmail))
            //{
            //    IsEmailOK = false;
            //    NewEmpEmail.BorderBrush = System.Windows.Media.Brushes.Red;
            //    NewEmpEmail.Background = (Brush)bc.ConvertFrom("#FCA08C");
            //    NewEmpEmail.GotFocus += NewEmpEmail_GotFocus;
            //    EmpEmailError.Visibility = Visibility.Visible;
            //    NewEmpEmail.Text = "Email không hợp lệ !";
            //}
            //else
            //{
            //    IsEmailOK = true;
            //}
            //if (IsEmailOK && IsPassWordOK && IsUserNameOk)
            //{
            //    if (AddDishVm.NewEmpInsert())
            //    {
            //        MessageBox.Show("Thêm nhân viên thành công !");
            //        user_name.Text = "ten_dang_nhap";
            //        user_display_name.Text = "Nguyen Van A";
            //        this.Visibility = Visibility.Collapsed;
            //        ShowEmpPass.Visibility = Visibility.Collapsed;
            //        ShowConfEmpPass.Visibility = Visibility.Collapsed;

            //        PassW.Visibility = Visibility.Visible;
            //        ConfPassW.Visibility = Visibility.Visible;

            //        PassShow.Visibility = Visibility.Visible;
            //        PassHide.Visibility = Visibility.Collapsed;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Xảy ra lỗi khi thêm nhân viên !");
            //    }
            //}
            //else
            //{
            //    // MessageBox.Show("Not Ok");
            //}
            //#endregion
        }
        //Quay lại
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //#region back
            //this.Visibility = Visibility.Collapsed;
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

            //NewEmpEmail.Text = "nhanvien01@ires.com.vn";
            //NewEmpEmail.BorderBrush = System.Windows.Media.Brushes.Black;
            //NewEmpEmail.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //EmpEmailError.Visibility = Visibility.Hidden;
            //NewEmpEmail.GotFocus += NewEmpEmail_GotFocus;

            //ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowConfEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;

            //user_name.BorderBrush = System.Windows.Media.Brushes.Black;
            //user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //UserNameError.Visibility = Visibility.Hidden;

            //PassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //PassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //PassError.Visibility = Visibility.Hidden;

            //ConfPassW.BorderBrush = System.Windows.Media.Brushes.Black;
            //ConfPassW.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ConfPassError.Visibility = Visibility.Hidden;

            //ShowEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ShowEmpPass.Visibility = Visibility.Collapsed;
            //ShowConfEmpPass.BorderBrush = System.Windows.Media.Brushes.Black;
            //ShowConfEmpPass.Background = System.Windows.Media.Brushes.WhiteSmoke;
            //ShowConfEmpPass.Visibility = Visibility.Collapsed;

            //PassW.Visibility = Visibility.Visible;
            //ConfPassW.Visibility = Visibility.Visible;

            //PassShow.Visibility = Visibility.Visible;
            //PassHide.Visibility = Visibility.Hidden;
            //#endregion
        }


        #endregion

        #region Xử lí
        private void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSave.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddDishVm.ListDishItem.Add(new DishItem());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int i = DataGridItem.SelectedIndex;
            if (AddDishVm.ListDishItem.Count > 1)
                AddDishVm.ListDishItem.RemoveAt(i);

        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;

            DishItem b = rows[0] as DishItem;

            b.DishItemUnitPrice = AddDishVm.PriceDict[b.ItemId];
            b.DishItemTotalPrice = b.DishItemUnitPrice * b.ItemQuantity;
        }

        private void ComboboxFoodType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(AddDishVm.ItemIndex.ToString());



            //string a = AddDishVm.ListDishItem[0].ItemId.ToString();
            //MessageBox.Show(a);
        }
        #region Textbox số lượng
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;
                b.ItemQuantity++;
            }
        } 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;
                if(b.ItemQuantity>1)
                b.ItemQuantity--;
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;

               


                if (e.Key == Key.Up)
                {
                    b.ItemQuantity++;
                }

                if (e.Key == Key.Down &&b.ItemQuantity!=1)
                {
                    b.ItemQuantity--;
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;

                b.DishItemUnitPrice = AddDishVm.PriceDict[b.ItemId];
                b.DishItemTotalPrice = b.DishItemUnitPrice * b.ItemQuantity;
            }
        }
        #endregion

        #region textbox Giá món
        private void MyGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            //textboxDishPrice.Visibility = Visibility.Collapsed;
            //textboxDishPrice2.Visibility = Visibility.Visible;                
        }

        private void MyGrid_MouseEnter(object sender, MouseEventArgs e)
        {

            textboxDishPrice.Visibility = Visibility.Visible;
            textboxDishPrice2.Visibility = Visibility.Collapsed;

        }

        private void MyGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            textboxDishPrice.Visibility = Visibility.Collapsed;
            textboxDishPrice2.Visibility = Visibility.Visible;
        }

        private void TextboxDishPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            double cost = AddDishVm.NewDish.DishCost;
            if(cost%1000!=0)
            {
                AddDish_DishPriceError();
            }
            else
            {
                AddDish_DishPriceOk();
            }
        }
        #endregion
        private void TextboxDishPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            //double value = AddDishVm.NewDish.DishCost;
            //var info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            //string a = value.ToString("#,##0.###");
            //string b = String.Format("{0:#,##0.##}", 12314);

            //double value = AddDishVm.NewDish.DishCost;
            //string a = value.ToString("#,##0.###");
            //a.Replace(".", "k");
            //MessageBox.Show(a);

            //int a = 10000000;
            //String.Format("{0:n0}", a);
            //string b = String.Format("{0:n0}", 9876);
            //b.Replace('.', 'k');

            //string temp = textboxDishPrice.Text;
            //textboxDishPrice.Text = string.Format("{0:n0}", temp);


            
        }

        private void TextboxDishPrice2_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextboxDishPrice2_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void TextboxDishPrice_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

       


        //private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    //MessageBox.Show("User");

        //    //if (!MyIsFocused)
        //    //{
        //    TextBox tb = (TextBox)sender;
        //    tb.Text = string.Empty;
        //    user_name.BorderBrush = System.Windows.Media.Brushes.Black;
        //    user_name.Background = System.Windows.Media.Brushes.WhiteSmoke;
        //    MyIsFocused = true;
        //    UserNameError.Visibility = Visibility.Hidden;
        //    tb.GotFocus -= TextBox_GotFocus;
        //    //}
        //    //else
        //    //{
        //    //    MyIsFocused = false;
        //    //}

        //}



      


        private void TextboxMin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && textboxMin.Text != "59")
            {
                int i = Convert.ToInt32(textboxMin.Text);
                i++;
                textboxMin.Text = i.ToString();
            }

            if (e.Key == Key.Down && textboxMin.Text !="0")
            {
                int i = Convert.ToInt32(textboxMin.Text);
                i--;
                textboxMin.Text = i.ToString();
            }
        }
        private void TextboxDishPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }




        private void TextboxHour_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && textboxHour.Text != "24")
            {
                int i = Convert.ToInt32(textboxHour.Text);
                i++;
                textboxHour.Text = i.ToString();
            }

            if (e.Key == Key.Down && textboxHour.Text != "0")
            {
                int i = Convert.ToInt32(textboxHour.Text);
                i--;
                textboxHour.Text = i.ToString();
            }
        }
        #endregion


       



        private void AddDish_DishPriceError()
        {
            gridDishPriceError.Visibility = Visibility.Visible;
            textboxDishPrice.BorderBrush = System.Windows.Media.Brushes.Red;
            textboxDishPrice2.BorderBrush = System.Windows.Media.Brushes.Red;
        }

       
        private void AddDish_DishPriceOk()
        {
            gridDishPriceError.Visibility = Visibility.Collapsed;
            textboxDishPrice.BorderBrush = System.Windows.Media.Brushes.Black;
            textboxDishPrice2.BorderBrush = System.Windows.Media.Brushes.Black;
        }
    }
}
