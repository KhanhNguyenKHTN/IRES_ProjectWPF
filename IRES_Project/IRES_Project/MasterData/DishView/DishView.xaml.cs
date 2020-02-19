using Model.Models;
using System;
using System.Collections;
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

namespace IRES_Project.MasterData.DishView
{
    /// <summary>
    /// Interaction logic for DishView.xaml
    /// </summary>
    public partial class DishView : UserControl
    {
        //int pageIndex = 1;
        private int numberOfRecPerPage = 10;
        DishViewModel dishVM = new DishViewModel();
        int ActiveBtn = 1;
        int CurPageIndex = 1;
        int no_View, ViewIndex = 1;
        int count;
        int from;
        int no_Page;
        string SelectedCol;
        bool FirstRun = true;
        List<DishModel> ListDish { get; set; }

        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        public DishView()
        {

            InitializeComponent();
            this.DataContext = dishVM;

            dishVM.ListDishes = new List<DishModel>(dishVM.ListDishesRoot.Take(numberOfRecPerPage));
            //dataGrid.ItemsSource=dishVM.ListDishes.Take(numberOfRecPerPage);
            No_View_Updt();
            #region Config paging btn 2 trường hợp, 1 là khi khởi tạo, 1 là khi itemsource thay đổi
            if (no_Page > 1)
            {
                btnNext.IsEnabled = true;
                btnNext.Opacity = 1;
            }
            else
            {
                btnNext.IsEnabled = false;
                btnNext.Opacity = 0.75;
            }

            if (dishVM.ListDishesRoot.Count <= numberOfRecPerPage)
            {
                btnLast.IsEnabled = false;
                btnLast.Opacity = 0.75;
            }
            else
            {
                btnLast.IsEnabled = true;
                btnLast.Opacity = 1;
            }
            btnPrev.IsEnabled = false;
            btnFirst.IsEnabled = false;
            updtLabel();

            //cbNumberOfRecords.Items.Add("10");
            //cbNumberOfRecords.Items.Add("20");
            //cbNumberOfRecords.Items.Add("30");
            //cbNumberOfRecords.Items.Add("50");
            //cbNumberOfRecords.Items.Add("100");
            //cbNumberOfRecords.SelectedItem = 10;
            #endregion

            #region Config button
            btnUpdate();

            #endregion
        }

        private void Navigate(int mode)
        {

            switch (mode)
            {
                case (int)PagingMode.Next:

                    btnPrev.IsEnabled = true;
                    btnPrev.Opacity = 1;
                    btnFirst.IsEnabled = true;
                    btnFirst.Opacity = 1;
                    if (dishVM.ListDishesRoot.Count >= (CurPageIndex * numberOfRecPerPage)) //còn at least 0 item để next
                    {

                        if (dishVM.ListDishesRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() != 0) // còn item để lấy
                        {
                            dishVM.ListDishes = new List<DishModel>(dishVM.ListDishesRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage));
                            if (ActiveBtn == 5 && ViewIndex != no_View)     //nút 5th
                            {

                                ViewIndex++;
                            }
                            btnUpdate();
                            btnDeFocus();
                            CurPageIndex++;
                            count = Math.Min((CurPageIndex) * (numberOfRecPerPage), dishVM.ListDishesRoot.Count());
                            updtActBtn();
                            btnFocus();

                            if (dishVM.ListDishesRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0) // hết item để lấy
                            {
                                btnNext.IsEnabled = false;
                                btnNext.Opacity = 0.75;
                                btnLast.IsEnabled = false;
                                btnLast.Opacity = 0.75;
                            }
                        }
                        from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                        lblpageInformation.Content = from + "-" + count + " of " + dishVM.ListDishesRoot.Count;
                    }
                    break;
                case (int)PagingMode.Previous:
                    if (no_Page > 1)
                    {
                        btnNext.IsEnabled = true;
                        btnNext.Opacity = 1;
                        btnLast.IsEnabled = true;
                        btnLast.Opacity = 1;
                    }
                    btnDeFocus();
                    if (CurPageIndex > 1)
                    {
                        if (ViewIndex > 1 && ActiveBtn == 1)
                        {
                            ViewIndex--;
                        }
                        btnUpdate();     // phụ thuộc vào ViewIndex
                        CurPageIndex -= 1;
                        if (CurPageIndex == 1)
                        {
                            btnPrev.IsEnabled = false;
                            btnPrev.Opacity = 0.75;
                            btnFirst.IsEnabled = false;
                            btnFirst.Opacity = 0.75;
                            dishVM.ListDishes = new List<DishModel>(dishVM.ListDishesRoot.Take(numberOfRecPerPage));
                            updtLabel();
                        }
                        else
                        {
                            dishVM.ListDishes = new List<DishModel>(dishVM.ListDishesRoot.Skip((CurPageIndex - 1) * numberOfRecPerPage).Take(numberOfRecPerPage));
                            count = CurPageIndex * numberOfRecPerPage;
                            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                            lblpageInformation.Content = from + "-" + count + " of " + dishVM.ListDishesRoot.Count;
                        }
                        updtActBtn();
                        btnFocus();
                    }
                    else
                    {
                        btnPrev.IsEnabled = false;
                        btnPrev.Opacity = 0.75;
                        btnFirst.IsEnabled = false;
                        btnFirst.Opacity = 0.75;
                    }
                    break;

                case (int)PagingMode.First:
                    if (no_Page == 1)
                    {
                        btnNext.IsEnabled = false;
                        btnNext.Opacity = 0.75;
                        btnLast.IsEnabled = false;
                        btnLast.Opacity = 0.75;
                        btnPrev.IsEnabled = false;
                        btnPrev.Opacity = 0.75;
                        btnFirst.IsEnabled = false;
                        btnFirst.Opacity = 0.75;
                    }
                    ViewIndex = 1;
                    CurPageIndex = 2;
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    ViewIndex = no_View;
                    CurPageIndex = (dishVM.ListDishesRoot.Count / numberOfRecPerPage);
                    if (dishVM.ListDishesRoot.Count % numberOfRecPerPage == 0)
                    {
                        CurPageIndex--;
                    }
                    Navigate((int)PagingMode.Next);
                    break;
                    #region test pagecount
                    //case (int)PagingMode.PageCountChange:
                    //    CurPageIndex = 1;
                    //    numberOfRecPerPage = Convert.ToInt32(cbNumberOfRecords.SelectedItem);
                    //    dataGrid.ItemsSource = null;
                    //    dataGrid.ItemsSource = dishVM.ListDishes.Take(numberOfRecPerPage);
                    //    count = (dishVM.ListDishes.Take(numberOfRecPerPage)).Count();
                    //    from = (CurPageIndex - 1) * numberOfRecPerPage + 1;

                    //    lblpageInformation.Content = from + "-" + count + " of " + dishVM.ListDishes.Count;

                    //    btnNext.IsEnabled = true;
                    //    btnLast.IsEnabled = true;
                    //    btnPrev.IsEnabled = true;
                    //    btnFirst.IsEnabled = true;
                    //    break;
                    #endregion
            }
        }

        #region Navigate button >> <<
        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.First);
        }
        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Previous);
        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Next);

        }
        private void btnLast_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate((int)PagingMode.PageCountChange);
        }
        #endregion

        #region Navigate number 1 2 3 4 5
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveBtn != 1)
            {

                switch (ActiveBtn)
                {
                    case 2:
                        {
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 3:
                        {
                            CurPageIndex -= 1;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 4:
                        {
                            CurPageIndex -= 2;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 5:
                        {
                            CurPageIndex -= 3;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                }


            }

        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveBtn != 2)
            {

                switch (ActiveBtn)
                {
                    case 1:
                        {

                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 3:
                        {


                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 4:
                        {
                            CurPageIndex -= 1;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 5:
                        {
                            CurPageIndex -= 2;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                }


            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveBtn != 3)
            {

                switch (ActiveBtn)
                {
                    case 1:
                        {
                            CurPageIndex += 1;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 2:
                        {
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 4:
                        {
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                    case 5:
                        {
                            CurPageIndex -= 1;
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                }

            }

        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveBtn != 4)
            {
                switch (ActiveBtn)
                {
                    case 1:
                        {
                            CurPageIndex += 2;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 2:
                        {
                            CurPageIndex += 1;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 3:
                        {
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 5:
                        {
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                }
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveBtn != 5)
            {

                switch (ActiveBtn)
                {
                    case 1:
                        {
                            CurPageIndex += 3;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 2:
                        {
                            CurPageIndex += 2;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 3:
                        {
                            CurPageIndex += 1;
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                    case 4:
                        {
                            Navigate((int)PagingMode.Next);
                            break;
                        }
                }


            }
        }
        #endregion

        #region Btn config
        public void btnDeFocus()
        {
            switch (ActiveBtn)
            {
                case 1:
                    {
                        btn1.Opacity = 0.75;
                        btn1.BorderThickness = new Thickness(0.0);
                        break;
                    }
                case 2:
                    {
                        btn2.Opacity = 0.75;
                        btn2.BorderThickness = new Thickness(0.0);
                        break;
                    }
                case 3:
                    {

                        btn3.BorderThickness = new Thickness(0.0);
                        btn3.Opacity = 0.75;
                        break;
                    }
                case 4:
                    {
                        btn4.Opacity = 0.75;
                        btn4.BorderThickness = new Thickness(0.0);
                        break;
                    }
                case 5:
                    {
                        btn5.Opacity = 0.75;
                        btn5.BorderThickness = new Thickness(0.0);
                        break;
                    }
            }
        }
        public void updtActBtn()
        {
            if (CurPageIndex % 5 == 0)
            {
                ActiveBtn = 5;
            }
            else
            {
                ActiveBtn = CurPageIndex % 5;
            }
        }
        public void btnFocus()
        {
            switch (ActiveBtn)
            {
                case 1:
                    {
                        btn1.Opacity = 1;
                        btn1.BorderBrush = Brushes.Black;
                        btn1.BorderThickness = new Thickness(1.0);
                        break;
                    }
                case 2:
                    {
                        btn2.Opacity = 1;
                        btn2.BorderBrush = Brushes.Black;
                        btn2.BorderThickness = new Thickness(1.0);
                        break;
                    }
                case 3:
                    {

                        btn3.Opacity = 1;
                        btn3.BorderBrush = Brushes.Black;
                        btn3.BorderThickness = new Thickness(1.0);
                        break;
                    }
                case 4:
                    {
                        btn4.Opacity = 1;
                        btn4.BorderBrush = Brushes.Black;
                        btn4.BorderThickness = new Thickness(1.0);
                        break;
                    }
                case 5:
                    {
                        btn5.Opacity = 1;
                        btn5.BorderBrush = Brushes.Black;
                        btn5.BorderThickness = new Thickness(1.0);
                        break;
                    }
            }
        }
        public void btnUpdate()
        {
            if (GetNo_Page() == 0)
            {
                btn1.Visibility = Visibility.Hidden;
                btn2.Visibility = Visibility.Hidden;
                btn3.Visibility = Visibility.Hidden;
                btn4.Visibility = Visibility.Hidden;
                btn5.Visibility = Visibility.Hidden;
            }
            else
            {
                if ((ViewIndex == 1 && no_View == 1) || ViewIndex == no_View)

                {
                    switch (GetNo_Page() % 5)
                    {
                        case 1:
                            {
                                btn1.Content = (ViewIndex - 1) * 5 + 1;
                                btn1.Visibility = Visibility.Visible;
                                btn2.Visibility = Visibility.Hidden;
                                btn3.Visibility = Visibility.Hidden;
                                btn4.Visibility = Visibility.Hidden;
                                btn5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 2:
                            {
                                btn1.Content = (ViewIndex - 1) * 5 + 1;
                                btn2.Content = (ViewIndex - 1) * 5 + 2;

                                btn1.Visibility = Visibility.Visible;
                                btn2.Visibility = Visibility.Visible;
                                btn3.Visibility = Visibility.Hidden;
                                btn4.Visibility = Visibility.Hidden;
                                btn5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 3:
                            {
                                btn1.Content = (ViewIndex - 1) * 5 + 1;
                                btn2.Content = (ViewIndex - 1) * 5 + 2;
                                btn3.Content = (ViewIndex - 1) * 5 + 3;
                                btn1.Visibility = Visibility.Visible;
                                btn2.Visibility = Visibility.Visible;
                                btn3.Visibility = Visibility.Visible;
                                btn4.Visibility = Visibility.Hidden;
                                btn5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 4:
                            {
                                btn1.Content = (ViewIndex - 1) * 5 + 1;
                                btn2.Content = (ViewIndex - 1) * 5 + 2;
                                btn3.Content = (ViewIndex - 1) * 5 + 3;
                                btn4.Content = (ViewIndex - 1) * 5 + 4;
                                btn1.Visibility = Visibility.Visible;
                                btn2.Visibility = Visibility.Visible;
                                btn3.Visibility = Visibility.Visible;
                                btn4.Visibility = Visibility.Visible;
                                btn5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 0:
                            {
                                btn1.Content = (ViewIndex - 1) * 5 + 1;
                                btn2.Content = (ViewIndex - 1) * 5 + 2;
                                btn3.Content = (ViewIndex - 1) * 5 + 3;
                                btn4.Content = (ViewIndex - 1) * 5 + 4;
                                btn5.Content = (ViewIndex - 1) * 5 + 5;
                                btn1.Visibility = Visibility.Visible;
                                btn2.Visibility = Visibility.Visible;
                                btn3.Visibility = Visibility.Visible;
                                btn4.Visibility = Visibility.Visible;
                                btn5.Visibility = Visibility.Visible;
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("btnUpdate Exception");
                                break;
                            }
                    }
                }
                else
                {
                    btn1.Content = (ViewIndex - 1) * 5 + 1;
                    btn2.Content = (ViewIndex - 1) * 5 + 2;
                    btn3.Content = (ViewIndex - 1) * 5 + 3;
                    btn4.Content = (ViewIndex - 1) * 5 + 4;
                    btn5.Content = (ViewIndex - 1) * 5 + 5;

                    btn1.Visibility = Visibility.Visible;
                    btn2.Visibility = Visibility.Visible;
                    btn3.Visibility = Visibility.Visible;
                    btn4.Visibility = Visibility.Visible;
                    btn5.Visibility = Visibility.Visible;
                }
            }
        }
        public void No_View_Updt()
        {
            no_Page = dishVM.ListDishesRoot.Count / numberOfRecPerPage;
            if (dishVM.ListDishesRoot.Count % numberOfRecPerPage != 0)
            {
                no_Page++;
            }
            no_View = no_Page / 5;
            if (no_Page % 5 != 0)
            {
                no_View++;
            }
        }

        public int GetNo_Page()
        {
            int res;
            int TotalRec = dishVM.ListDishesRoot.Skip((ViewIndex - 1) * 5 * numberOfRecPerPage).Count();
            if (TotalRec == 0)
            {
                return 0;
            }
            res = TotalRec / numberOfRecPerPage;
            if (dishVM.ListDishesRoot.Count() % numberOfRecPerPage != 0)
            {
                res++;
            }
            return res;
        }
        #endregion

        #region Có bug
        private void MyCheck_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) //Check xem dưới VM có gọi gì ko, nếu có reset itemsource
        {
            //if (!FirstRun)
            //{
            //    if (dishVM.IsChecked)
            //    {
            //        ListDish = dishVM.searchEmployee(); //If == 0 tra ve list rong va thong bao
            //    }
            //    else
            //    {
            //        ListDish = dishVM.searchDeletedEmployee();
            //    }
            //    if (ListDish.Count != 0)
            //    {
            //        dishVM.ListDishes = ListDish;
            //        dishVM.ListDishesRoot = ListDish;
            //        No_View_Updt();
            //        if (no_Page >= 1)
            //        {
            //            Navigate((int)PagingMode.First);
            //        }
            //        else
            //        {
            //            dishVM.ListDishes.Clear();
            //        }
            //        updtLabel();
            //    }
            //    else
            //    {
            //        dishVM.ListDishesRoot.Clear();
            //        No_View_Updt();
            //        Navigate((int)PagingMode.First);
            //        updtLabel();
            //    }
            //}
            //else
            //    FirstRun = false;
        }
        private void Refresh_Data(object sender, RoutedEventArgs e)
        {
            //if (dishVM.IsChecked)
            //{
            //    dishVM.ListDishesRoot = dishVM.getDataEmployee();

            //}
            //else
            //{
            //    dishVM.ListDishesRoot = dishVM.getDeletedEmployee();
            //}

            //No_View_Updt();
            //Navigate((int)PagingMode.First);
            //updtLabel();
        }
        private void Search_Emp(object sender, RoutedEventArgs e)
        {
            if (dishVM.IsChecked)
            {
                ListDish = dishVM.searchDish(); //If == 0 tra ve list rong va thong bao
            }
            else
            {
                ListDish = dishVM.searchDeletedDish();
            }
            if (ListDish.Count != 0)
            {
                dishVM.ListDishes = ListDish;
                dishVM.ListDishesRoot = ListDish;
                No_View_Updt();
                if (no_Page >= 1)
                {
                    Navigate((int)PagingMode.First);
                }
                else
                {
                    dishVM.ListDishes.Clear();
                }
                updtLabel();
            }
            else
            {
                dishVM.ListDishesRoot.Clear();
                No_View_Updt();
                Navigate((int)PagingMode.First);
                updtLabel();
            }


        }
        private void Edit_Click(object sender, RoutedEventArgs e) // Chuyen sang page edit
        {
            //EditEmpUC.Visibility = Visibility.Visible;
            //IList rows = dataGrid.SelectedItems;
            //Employee a = rows[0] as Employee;
            //EditEmpUC.TakeEmp(a);
        }
        public void RemoveItem(List<DishModel> collection, Employee instance)
        {
            //collection.Remove(collection.Where(i => i.EmployeeCode == instance.EmployeeCode).Single());
        }


        private void MasterHeader_ActiveClick(object sender, RoutedEventArgs e)
        {
            //if (dishVM.IsChecked == true)
            //{
            //    if (dishVM.IsSearching == true)
            //    {
            //        //MessageBox.Show("Đang trong tìm kiếm");
            //        ListDish = dishVM.searchEmployee();
            //        if (ListDish.Count != 0)
            //        {
            //            dishVM.ListDishesRoot = ListDish;
            //        }
            //    }
            //    else
            //    {
            //        dishVM.ListDishesRoot = dishVM.getDataEmployee();
            //    }
            //}
            //else
            //{
            //    if (dishVM.IsSearching == true)
            //    {
            //        // MessageBox.Show("Đang trong tìm kiếm");
            //        ListDish = dishVM.searchDeletedEmployee();
            //        if (ListDish.Count != 0)
            //        {
            //            dishVM.ListDishesRoot = ListDish;
            //        }
            //        else
            //        {
            //            dishVM.ListDishesRoot.Clear();
            //            No_View_Updt();
            //            Navigate((int)PagingMode.First);
            //            updtLabel();
            //        }
            //    }
            //    else
            //    {
            //        dishVM.ListDishesRoot = dishVM.getDeletedEmployee();
            //    }
            //}
            //No_View_Updt();
            //if (no_Page >= 1)
            //{
            //    Navigate((int)PagingMode.First);
            //}
            //else
            //{
            //    dishVM.ListDishes.Clear();
            //}
            //updtLabel();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
        //    IList rows = dataGrid.SelectedItems;
        //    Employee a = rows[0] as Employee;
        //    if (a.RoleId == 7)
        //    {
        //        MessageBox.Show("Không thể xóa Admin");
        //    }
        //    else
        //    {
        //        if (a.Active == false)
        //        {
        //            if (MessageBox.Show("Bỏ xóa nhân viên này?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.No)
        //            {
        //                //do no stuff

        //            }
        //            else
        //            {
        //                //do yes stuff
        //                dishVM.ActiveEmployee(a.EmployeeCode, a);
        //                //dishVM.ListDishesRoot = dishVM.ListDishes;
        //                No_View_Updt();
        //                Navigate((int)PagingMode.First);
        //                updtLabel();
        //            }
        //        }

        //        else
        //        {
        //            if (MessageBox.Show("Xóa nhân viên này?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.No)
        //            {
        //                //do no stuff

        //            }
        //            else
        //            {
        //                //do yes stuff
        //                dishVM.DeleteEmployee(a.EmployeeCode, a);
        //                //dishVM.ListDishesRoot = dishVM.ListDishes;
        //                No_View_Updt();
        //                Navigate((int)PagingMode.First);
        //                updtLabel();
        //            }
        //        }
        //    }
        }

        private void MasterHeader_AddClick(object sender, RoutedEventArgs e)
        {
           //AddEmpUC.Visibility = Visibility.Visible;
        }
        private void AddEmpUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (ListEmpUC.Visibility == Visibility.Visible)
            //{
            //    ListEmpUC.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    if (dishVM.IsChecked)
            //    {
            //        dishVM.ListDishesRoot = dishVM.getDataEmployee();

            //    }
            //    else
            //    {
            //        dishVM.ListDishesRoot = dishVM.getDeletedEmployee();
            //    }

            //    No_View_Updt();
            //    Navigate((int)PagingMode.First);
            //    updtLabel();
            //    ListEmpUC.Visibility = Visibility.Visible;
            //}
        }
        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var dataGridCellTarget = (DataGridCell)sender;
            //int columnIndex = dataGrid.CurrentColumn.DisplayIndex;
            //Employee a = dataGridCellTarget.DataContext as Employee;
            //EmpDetailUC.TakeEmp(a);
            //EmpDetailUC.Visibility = Visibility.Visible;
        }

        #endregion








        private void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            switch (ActiveBtn)
            {
                case 1:
                    {
                        btn1.Focus();
                        break;
                    }
                case 2:
                    {
                        btn2.Focus();
                        break;
                    }
                case 3:
                    {
                        btn3.Focus();
                        break;
                    }
                case 4:
                    {
                        btn4.Focus();
                        break;
                    }
                case 5:
                    {
                        btn5.Focus();
                        break;
                    }
            }

        }
      
     
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
     
        private void EmpDetailUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ListEmpUC.Visibility == Visibility.Visible)
            {
                ListEmpUC.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListEmpUC.Visibility = Visibility.Visible;
            }
        }
        private void EditEmpUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ListEmpUC.Visibility == Visibility.Visible)
            {
                ListEmpUC.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListEmpUC.Visibility = Visibility.Visible;
            }
        }
      
        private void CellSetColor(object sender, MouseEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            var a = cell.Background;
            int index = cell.Column.DisplayIndex;
            if (index == 0)
            {

                var dataGridCellTarget = (DataGridCell)sender;

                var bc = new BrushConverter();
                //dataGridCellTarget.Background = (Brush)bc.ConvertFrom("#FCA08C");
                dataGridCellTarget.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }
        private void CellRemoveColor(object sender, MouseEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            int index = cell.Column.DisplayIndex;
            if (index == 0)
            {
                var dataGridCellTarget = (DataGridCell)sender;

                var bc = new BrushConverter();
                //dataGridCellTarget.Background = new SolidColorBrush(Colors.WhiteSmoke);
                //dataGridCellTarget.Background = (Brush)bc.ConvertFrom("#00FFFFFF");
                dataGridCellTarget.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void updtLabel()
        {
            count = dishVM.ListDishesRoot.Take(numberOfRecPerPage).Count();
            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            if (count == 0)
                from = 0;
            lblpageInformation.Content = from + "-" + count + " of " + dishVM.ListDishesRoot.Count;
        }
    }
}
