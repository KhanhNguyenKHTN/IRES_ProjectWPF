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
        bool IsDishItemOK, IsDishPriceOK, IsDishCookTimeOK = false;
        bool IsDishNameOk = true;

        public AddDish()
        {
            InitializeComponent();
            this.DataContext = AddDishVm;
            ResComb.ItemsSource = AddDishVm.ListRes;
          
        }
        #region chua làm
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddDish_CheckDishNameError();
            if(!Check_Dish_ItemList())
            {
                MessageBox.Show("Nguyên liệu phải có trọng lượng lớn hơn 0 và nhỏ hơn 10");
            }
            AddDish_CheckCookTime();
            if(IsDishItemOK && IsDishPriceOK && IsDishCookTimeOK && IsDishNameOk)
            {
                AddDishVm.NewDishInsert(textboxHour.Text, textboxMin.Text);
                
            }
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
        #region Danh sách nguyên liệu
        #region Chức năng search trên combobox
        //private void ComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;

        //    cmb.IsDropDownOpen = true;

        //    if (!string.IsNullOrEmpty(cmb.Text))
        //    {
        //        string fullText = cmb.Text.Insert(GetChildOfType<TextBox>(cmb).CaretIndex, e.Text);
        //        // cmb.ItemsSource = AddDishVm.ItemDict.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        //        cmb.ItemsSource = AddDishVm.ItemDict.Where(s => s.Value.ToUpper().Contains(fullText.ToUpper()));

        //    }
        //    else if (!string.IsNullOrEmpty(e.Text))
        //    {
        //        cmb.ItemsSource = AddDishVm.ItemDict.Where(s => s.Value.ToUpper().Contains(e.Text.ToUpper()));
        //    }
        //    else
        //    {
        //        cmb.ItemsSource = AddDishVm.ItemDict;
        //    }
        //}
        //private void ComboBox_PreviewKeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Back || e.Key == Key.Delete)
        //    {
        //        ComboBox cmb = (ComboBox)sender;

        //        cmb.IsDropDownOpen = true;

        //        if (!string.IsNullOrEmpty(cmb.Text))
        //        {
        //            cmb.ItemsSource = AddDishVm.ItemDict.Where(s => s.Value.ToUpper().Contains(cmb.Text.ToUpper()));
        //        }
        //        else
        //        {
        //            cmb.ItemsSource = AddDishVm.ItemDict;
        //        }
        //    }
        //}
        //private void ComboBox_Pasting(object sender, DataObjectPastingEventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;

        //    cmb.IsDropDownOpen = true;

        //    string pastedText = (string)e.DataObject.GetData(typeof(string));
        //    string fullText = cmb.Text.Insert(GetChildOfType<TextBox>(cmb).CaretIndex, pastedText);

        //    if (!string.IsNullOrEmpty(fullText))
        //    {
        //        cmb.ItemsSource = AddDishVm.ItemDict.Where(s => s.Value.ToUpper().Contains(fullText.ToUpper()));
        //    }
        //    else
        //    {
        //        cmb.ItemsSource = AddDishVm.ItemDict; 
        //    }
        //}
        //public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj == null) return null;

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //    {
        //        var child = VisualTreeHelper.GetChild(depObj, i);

        //        var result = (child as T) ?? GetChildOfType<T>(child);
        //        if (result != null) return result;
        //    }
        //    return null;
        //}
        #endregion


        private bool Check_Dish_ItemList()
        {
            foreach (DishItem a in AddDishVm.ListDishItem)
            {
                if (a.IsQuantityZero == true)
                {
                    IsDishItemOK = false;
                    return false;
                }
            }
            IsDishItemOK = true;
            return true;
        }
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
            b.DishItemTotalPrice = b.DishItemUnitPrice * (double)b.ItemQuantity;
        }

        private void ComboboxFoodType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(AddDishVm.ItemIndex.ToString());



            //string a = AddDishVm.ListDishItem[0].ItemId.ToString();
            //MessageBox.Show(a);
        }
        #endregion
        #region Textbox số lượng
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;
                if (b.ItemQuantity < 10)
                    b.ItemQuantity+=0.1m;
            }
        } 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;
                if(b.ItemQuantity>0)
                b.ItemQuantity-=0.1m;
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
                    if(b.ItemQuantity <10)
                        b.ItemQuantity += 0.1m;
                }

                if (e.Key == Key.Down &&b.ItemQuantity >0)
                {
                    if(b.ItemQuantity > 0)
                        b.ItemQuantity -= 0.1m;
                }
            }
        }
        private void TextboxQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox mytxtbox = sender as TextBox;
            if(mytxtbox.Text =="")
            {
                mytxtbox.Text = "0.0";
            }
            IList rows = DataGridItem.SelectedItems;
            if (rows.Count != 0)
            {
                DishItem b = rows[0] as DishItem;
                
                if (b.ItemQuantity == 0 || b.ItemQuantity>=10)
                {
                    b.IsQuantityZero = true;
                }
                else
                    b.IsQuantityZero = false;
                b.DishItemUnitPrice = AddDishVm.PriceDict[b.ItemId];
                b.DishItemTotalPrice = b.DishItemUnitPrice * (double)b.ItemQuantity;
            }
        }
        #endregion

        #region textbox Giá món
        private void TextboxDishPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
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
             AddDish_DishPriceError("Lẻ");
            }
            else
            {
                if(cost==0||cost < AddDish_GetTotalItemPrice())
                { 
                    AddDish_DishPriceError("0");
                }
                else
                    AddDish_DishPriceOk();
            }
        }
        private void AddDish_DishPriceError(string error)
        {
            IsDishPriceOK = false;
            if (error == "Lẻ")
            {
                gridDishPriceError.Visibility = Visibility.Visible;
                gridDishPriceZero.Visibility = Visibility.Collapsed;
                textboxDishPrice.BorderBrush = System.Windows.Media.Brushes.Red;
                textboxDishPrice2.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            if (error == "0" )
            {
                gridDishPriceZero.Visibility = Visibility.Visible;
                gridDishPriceError.Visibility = Visibility.Collapsed;
                textboxDishPrice.BorderBrush = System.Windows.Media.Brushes.Red;
                textboxDishPrice2.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }
        private void AddDish_DishPriceOk()
        {
            IsDishPriceOK = true;
            gridDishPriceError.Visibility = Visibility.Collapsed;
            gridDishPriceZero.Visibility = Visibility.Collapsed;
            textboxDishPrice.BorderBrush = System.Windows.Media.Brushes.Black;
            textboxDishPrice2.BorderBrush = System.Windows.Media.Brushes.Black;
        }
        private int AddDish_GetTotalItemPrice()
        {
            double result = 0;
            foreach( DishItem dishItem in AddDishVm.ListDishItem)
            {
                result += dishItem.DishItemTotalPrice;
            }
            return (int)result ;
        }
        #endregion





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






      


        #region Thời gian nấu
        private void AddDish_CheckCookTime()
        {
            IsDishCookTimeOK = true;
            int min;
            int hour;
            int.TryParse(textboxMin.Text, out min);
            int.TryParse(textboxHour.Text, out hour);
            if (hour<0 || hour>23)
            {
                IsDishCookTimeOK = false;
            }
            if(hour==0 && min==0 || min<0 || min >=60)
            {
                IsDishCookTimeOK = false;
            }
        }
        private void TextboxHour_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int hour;
            if (e.Key == Key.Up && textboxHour.Text != "23")
            {
                int.TryParse(textboxHour.Text, out hour);
                hour++;
                textboxHour.Text = hour.ToString();
            }

            if (e.Key == Key.Down && textboxHour.Text != "0" && textboxHour.Text != "")
            {
                int.TryParse(textboxHour.Text, out hour);
                hour--;
                textboxHour.Text = hour.ToString();
            }
        }
        private void TextboxMin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int min;
                int hour;
                int.TryParse(textboxMin.Text, out min);
                int.TryParse(textboxHour.Text, out hour);
                if (e.Key == Key.Up && min != 59)
                {                
                    min++;
                    textboxMin.Text = min.ToString();
                }
                if (hour != 0)
                {
                    if (e.Key == Key.Down && min > 0)
                    {
                        min--;
                        textboxMin.Text = min.ToString();
                    }
                }
                if (hour == 0)
                {
                    if (e.Key == Key.Down && min > 1)
                    {
                        min--;
                        textboxMin.Text = min.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextboxMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int min;
                int hour;
                int.TryParse(textboxMin.Text, out min);
                int.TryParse(textboxHour.Text, out hour);
                if (textboxMin.Text == "")
                {
                    stackpanelMinError0_59.Visibility = Visibility.Collapsed;
                    stackpanelMinError1_59.Visibility = Visibility.Collapsed;
                    stackpanelMinErrorEmpty.Visibility = Visibility.Visible;
                    textboxMin.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (textboxMin.Text != "")
                {
                    stackpanelMinErrorEmpty.Visibility = Visibility.Collapsed;
                    textboxMin.BorderBrush = System.Windows.Media.Brushes.Black;
                   
                    if (hour == 0)
                    {
                        if (min > 59)
                        {
                            stackpanelMinError1_59.Visibility = Visibility.Visible;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Red;
                        }
                        else if (min == 0)
                        {
                            stackpanelMinError1_59.Visibility = Visibility.Visible;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Red;
                        }
                        else
                        {
                            stackpanelMinError1_59.Visibility = Visibility.Collapsed;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Black;
                        }
                    }
                    else
                    {
                        if (min > 59)
                        {
                            stackpanelMinError0_59.Visibility = Visibility.Visible;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Red;
                        }

                        else
                        {
                            stackpanelMinError0_59.Visibility = Visibility.Collapsed;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Black;
                        }
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TextboxHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textboxHour.Text == "")
            {
                stackpanelHourErrorEmpty.Visibility = Visibility.Visible;
                textboxHour.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                stackpanelHourErrorEmpty.Visibility = Visibility.Collapsed;
                textboxHour.BorderBrush = System.Windows.Media.Brushes.Black;
                int hour = Convert.ToInt32(textboxHour.Text);
                if (hour > 23)
                {
                    stackpanelHourError.Visibility = Visibility.Visible;
                    textboxHour.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {

                    if (textboxMin.Text == "0" || textboxMin.Text == "00")
                    {
                        if (hour != 0)
                        {
                            {
                                stackpanelMinError1_59.Visibility = Visibility.Collapsed;
                                textboxMin.BorderBrush = System.Windows.Media.Brushes.Black;
                            }
                        }
                        else
                        {
                            stackpanelMinError1_59.Visibility = Visibility.Visible;
                            textboxMin.BorderBrush = System.Windows.Media.Brushes.Red;
                        }

                        stackpanelHourError.Visibility = Visibility.Collapsed;
                        textboxHour.BorderBrush = System.Windows.Media.Brushes.Black;
                    }
                }
            }
        }
        private void TextboxMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            //if(textboxMin.CaretIndex==1)
            //e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
            //else if(textboxMin.CaretIndex == 0)
            //{
            //    e.Handled = !IsValid(e.Text+ ((TextBox)sender).Text);
            //}
        }

        public  bool IsValid(string str)
        {
            int i;
            if(textboxHour.Text =="")
            {
                textboxHour.Text = "0";
            }
            int hour = Convert.ToInt32(textboxHour.Text);
            if (hour != 0)
            {
                return int.TryParse(str, out i) && i >= 0 && i <= 59;
            }
            else if (hour == 0 )
            {
                if (textboxMin.Text == "")
                {
                    return int.TryParse(str, out i) && i >= 0 && i <= 59;
                }
                else if(textboxMin.Text == "0")
                {
                    return int.TryParse(str, out i) && i >= 1 && i <= 59;
                }
                else
                {
                    return int.TryParse(str, out i) && i >= 0 && i <= 59;
                }
                    
            }
            else
                return false;
        }
       
        private void TextboxHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           

            //if( textboxHour.CaretIndex ==1)
            //  e.Handled = !IsValidForHour(((TextBox)sender).Text + e.Text);
            //else if(textboxHour.CaretIndex == 0)
            //  {
            //      e.Handled = !IsValidForHour(e.Text + ((TextBox)sender).Text);
            //  }

        }
        #endregion



        #region Tên món
        private void AddDish_CheckDishNameError()
        {
            if (textboxDishName.Text == "")
            {
                IsDishNameOk = false;
                textboxDishName.BorderBrush = System.Windows.Media.Brushes.Red;
                gridNameError.Visibility = Visibility.Visible;

            }
            else
            {
                IsDishNameOk = true;
                textboxDishName.BorderBrush = System.Windows.Media.Brushes.Black;
                gridNameError.Visibility = Visibility.Collapsed;
            }
        }
        
        private void TextboxDishName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textboxDishName.Text=="")
            {
                textboxDishName.BorderBrush = System.Windows.Media.Brushes.Red;
                gridNameError.Visibility = Visibility.Visible;

            }
            else
            {
                textboxDishName.BorderBrush = System.Windows.Media.Brushes.Black;
                gridNameError.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
     
       

       
    }
}
