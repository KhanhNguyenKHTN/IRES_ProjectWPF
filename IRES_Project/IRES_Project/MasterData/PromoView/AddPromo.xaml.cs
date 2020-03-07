using System;
using System.Collections.Generic;
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

namespace IRES_Project.MasterData.PromoView
{
    /// <summary>
    /// Interaction logic for AddPromo.xaml
    /// </summary>
    public partial class AddPromo : UserControl
    {
        AddPromoViewModel AddProVM = new AddPromoViewModel();
        public AddPromo()
        {
            InitializeComponent();
            this.DataContext = AddProVM;
            ResComb.ItemsSource = AddProVM.ListRes;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool Ok = true;
            if(!CheckPromoDate())
            {
                Ok = false;
            }
            if (!CheckPromoValue())
            {
                Ok = false;
            }
            if (!CheckPromoMaxValue())
            {
                Ok = false;
            }
            if (!CheckPromoCode())
            {
                Ok = false;
            }
            if (!CheckPromoName())
            {
                Ok = false;
            }
            if (Ok )
            {
                if(AddProVM.InsertNewPromo())
                {
                    MessageBox.Show("Thêm khuyến mãi " + AddProVM.NewPromo.PromotionName + " thành công");
                    SetDefault();
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Thêm khuyến mãi không thành công");
                }

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SetDefault();
        }

        private void SetDefault()
        {
            textbox_promo_name.Text = "";
            textbox_promo_name.BorderBrush = System.Windows.Media.Brushes.Black;
            GridPromoNameError.Visibility = Visibility.Collapsed;

            textbox_promo_code.Text = "";
            textbox_promo_code.BorderBrush = System.Windows.Media.Brushes.Black;
            GridPromoCodeError.Visibility = Visibility.Collapsed;

            AddProVM.NewPromo.PromotionStartDate = DateTime.Now;
            DatapickerStart.BorderBrush = System.Windows.Media.Brushes.Black;
            AddProVM.NewPromo.PromotionEndDate = DateTime.Now.AddDays(1);
            DatapickerEnd.BorderBrush = System.Windows.Media.Brushes.Black;

            GridEndDate_c_NowError.Visibility = Visibility.Collapsed;
            GridStartDate_c_NowError.Visibility = Visibility.Collapsed;
            GridStartDate_Bigger_EndError.Visibility = Visibility.Collapsed;

            AddProVM.NewPromo.PromotionApplyType = "ALL";

            AddProVM.NewPromo.PromotionValue = "1000";
            textbox_promo_value.BorderBrush = System.Windows.Media.Brushes.Black;
            GridPromoValueError.Visibility = Visibility.Collapsed;
            GridPromoValueError2.Visibility = Visibility.Collapsed;
            GridPromoValueError3.Visibility = Visibility.Collapsed;

            AddProVM.NewPromo.PromotionUnit = "VNĐ";

            AddProVM.NewPromo.PromotionMaxValue = 500000;
            textbox_promo_max.BorderBrush = System.Windows.Media.Brushes.Black;
            GridPromoMaxValueError.Visibility = Visibility.Collapsed;
            AddProVM.NewPromo.PromotionDes = "Mô tả";
        }

        #region Tên khuyến mãi
        private bool CheckPromoName()
        {
            string promoname = textbox_promo_name.Text;

            if (String.IsNullOrEmpty(promoname) || String.IsNullOrWhiteSpace(promoname))
            {
                GridPromoNameError.Visibility = Visibility.Visible;
                textbox_promo_name.BorderBrush = System.Windows.Media.Brushes.Red;
                return false;
            }
            else
            {
                GridPromoNameError.Visibility = Visibility.Collapsed;
                textbox_promo_name.BorderBrush = System.Windows.Media.Brushes.Black;
                return true;
            }
        }
        private void Textbox_promo_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string promoname = textbox_promo_name.Text;

            if (String.IsNullOrEmpty(promoname)|| String.IsNullOrWhiteSpace(promoname))
            {
                GridPromoNameError.Visibility = Visibility.Visible;
                textbox_promo_name.BorderBrush  = System.Windows.Media.Brushes.Red;
            }
            else
            {
                GridPromoNameError.Visibility = Visibility.Collapsed;
                textbox_promo_name.BorderBrush = System.Windows.Media.Brushes.Black;
            }

        }

        private void Textbox_promo_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
            Regex regex = new Regex(@"^\w+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Textbox_promo_name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (textbox_promo_name.Text == "")
            {
                if(e.Key== Key.Space)
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region Mã khuyến mãi
        private void Textbox_promo_code_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Tab)
                e.Handled = true;
        }
        private bool CheckPromoCode()
        {
            bool res = true;
            string promocode = textbox_promo_code.Text;

            if (String.IsNullOrEmpty(promocode) || String.IsNullOrWhiteSpace(promocode))
            {
                GridPromoCodeError.Visibility = Visibility.Visible;
                textbox_promo_code.BorderBrush = System.Windows.Media.Brushes.Red;
                res = false;
            }
            else
            {
                GridPromoCodeError.Visibility = Visibility.Collapsed;
                textbox_promo_code.BorderBrush = System.Windows.Media.Brushes.Black;
                res= true;
            }
            return res;
        }
        private void Textbox_promo_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            string promocode = textbox_promo_code.Text;

            if (String.IsNullOrEmpty(promocode) || String.IsNullOrWhiteSpace(promocode))
            {
                GridPromoCodeError.Visibility = Visibility.Visible;
                textbox_promo_code.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                GridPromoCodeError.Visibility = Visibility.Collapsed;
                textbox_promo_code.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }
        #endregion

        #region Ngày khuyến mãi
        private void DatapickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckPromoDate();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckPromoDate();
        }
        private bool CheckPromoDate()
        {
            bool result = true;
            DateTime now = DateTime.Now;
          
            if (AddProVM.NewPromo.PromotionStartDate.Date> AddProVM.NewPromo.PromotionEndDate.Date) // Nếu ngày bắt đầu lớn hơn ngày kết thúc
            {
                GridStartDate_Bigger_EndError.Visibility = Visibility.Visible;
                GridStartDate_c_NowError.Visibility = Visibility.Collapsed;
                DatapickerStart.BorderBrush = System.Windows.Media.Brushes.Red;
                result = false;
            }
            else
            {                
                GridStartDate_Bigger_EndError.Visibility = Visibility.Collapsed;
                DatapickerStart.BorderBrush = System.Windows.Media.Brushes.Black;
            }


            if (AddProVM.NewPromo.PromotionStartDate.Date < now.Date)                              // Nếu ngày khuyến mãi trước hôm nay
            {
                if (GridStartDate_Bigger_EndError.Visibility == Visibility.Collapsed)
                {
                    GridStartDate_c_NowError.Visibility = Visibility.Visible;
                    DatapickerStart.BorderBrush = System.Windows.Media.Brushes.Red;
                    result = false;
                }   
            }
            else
            {
                GridStartDate_c_NowError.Visibility = Visibility.Collapsed;
                if(result== true)
                DatapickerStart.BorderBrush = System.Windows.Media.Brushes.Black;
            }


            if ( AddProVM.NewPromo.PromotionEndDate.Date < now.Date)                                // Nếu ngày kết thúc khuyến mãi trước hôm nay
            {
                GridEndDate_c_NowError.Visibility = Visibility.Visible;
                DatapickerEnd.BorderBrush = System.Windows.Media.Brushes.Red;
                result = false;
            }
            else
            {
                GridEndDate_c_NowError.Visibility = Visibility.Collapsed;
                DatapickerEnd.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            return result;
        }
        #endregion

        #region Giá trị khuyến mãi
        private void Textbox_promo_value_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Textbox_promo_value_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPromoValue();
        }
        private bool CheckPromoValue()
        {
            bool result = true;
            int value = -1;
            int.TryParse(textbox_promo_value.Text, out value);
            string unit = AddProVM.NewPromo.PromotionUnit;
            if (unit == "%")
            {
                if (textbox_promo_value.Text.Length >= 3 && value > 100)
                {
                    PromoValueHasError("% > 100");
                    result = false;
                }
                else if (value < 5)
                {
                    PromoValueHasError("% < 5");
                    result = false;
                }
                else
                {
                    PromoValueHasError();
                }
            }
            else
            {

                if (unit == "VNĐ" && value < 1000)
                {
                    PromoValueHasError("VND < 1000");
                    result = false;
                }
                else
                {
                    PromoValueHasError();
                }
            }
            return result;
        }
        private void PromoValueHasError(string error = null)
        {
            switch (error)
            {
                case "VND < 1000":
                    {
                        GridPromoValueError2.Visibility = Visibility.Visible;
                        GridPromoValueError3.Visibility = Visibility.Collapsed;
                        GridPromoValueError.Visibility = Visibility.Collapsed;
                        textbox_promo_value.BorderBrush = System.Windows.Media.Brushes.Red;
                        break;
                    }
                case "% < 5":
                    {
                        GridPromoValueError3.Visibility = Visibility.Visible;
                        GridPromoValueError2.Visibility = Visibility.Collapsed;
                        GridPromoValueError.Visibility = Visibility.Collapsed;
                        textbox_promo_value.BorderBrush = System.Windows.Media.Brushes.Red;
                        break;
                    }
                case "% > 100":
                    {
                        GridPromoValueError.Visibility = Visibility.Visible;
                        GridPromoValueError3.Visibility = Visibility.Collapsed;
                        GridPromoValueError2.Visibility = Visibility.Collapsed;
                        textbox_promo_value.BorderBrush = System.Windows.Media.Brushes.Red;
                        break;
                    }
                default:
                    {
                        GridPromoValueError.Visibility = Visibility.Collapsed;
                        GridPromoValueError3.Visibility = Visibility.Collapsed;
                        GridPromoValueError2.Visibility = Visibility.Collapsed;
                        textbox_promo_value.BorderBrush = System.Windows.Media.Brushes.Black;
                        break;
                    }
            }
        }
        #endregion

        #region Đơn vị khuyến mãi
        private void ComboboxPromoUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AddProVM.NewPromo.PromotionUnit=="%")
            {
                int value = -1;
                int.TryParse(textbox_promo_value.Text, out value);
                textbox_promo_value.MaxLength = 3;
                if (textbox_promo_value.Text.Length > 3 && value > 100)
                {
                    PromoValueHasError("% > 100");
                }
                else
                {
                    if (value < 5)
                    {
                        PromoValueHasError("% < 5");
                    }
                    else
                    {
                        PromoValueHasError();
                    }
                }
            }
            else
            { 
                int value = -1;
                int.TryParse(textbox_promo_value.Text, out value);
                if (AddProVM.NewPromo.PromotionUnit == "VNĐ" && value < 1000)
                {
                    PromoValueHasError("VND < 1000");
                }
                else
                {
                    PromoValueHasError();
                }
                   
                textbox_promo_value.MaxLength = 10;
            }
        }

        #endregion

        #region Giá trị tối đa
        private bool CheckPromoMaxValue()
        {
            bool result = true;
            if (string.IsNullOrEmpty(textbox_promo_max.Text) || string.IsNullOrWhiteSpace(textbox_promo_max.Text))
            {
                textbox_promo_max.Text = "0";
            }
            if (AddProVM.NewPromo.PromotionUnit == "VNĐ")
            {
                int value;
                int.TryParse(textbox_promo_value.Text, out value);
                if (AddProVM.NewPromo.PromotionMaxValue < value)
                {
                    result = false;
                    GridPromoMaxValueError.Visibility = Visibility.Visible;
                    textbox_promo_max.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    GridPromoMaxValueError.Visibility = Visibility.Collapsed;
                    textbox_promo_max.BorderBrush = System.Windows.Media.Brushes.Black;
                }
            }
            return result;
        }
        private void Textbox_promo_max_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Textbox_promo_max_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPromoMaxValue();
        }
         #endregion

       

       
    }
}
