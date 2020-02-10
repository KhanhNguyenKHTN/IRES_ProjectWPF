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
using ViewModel.Modules;
using Model.Models;
using System.Collections.ObjectModel;
using System.Collections;
using System.Data;
using ViewModel.MasterData;

namespace IRES_Project.MasterData.MainPage
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        //int pageIndex = 1;
        private int numberOfRecPerPage = 5;
        MainPageViewModel mainPageVM = new MainPageViewModel();
        AddEmpViewModel AddEmp = new AddEmpViewModel();
        int ActiveBtn = 1;
        int CurPageIndex = 1;
        int no_View, ViewIndex = 1;
        int count;
        int from;
        int no_Page;
        string SelectedCol;
        bool FirstRun = true;
        ObservableCollection<Employee> ListEm { get; set; }

        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        public MainPage()
        {
            
            InitializeComponent();
            this.DataContext = mainPageVM;

            mainPageVM.ListEmployee = new ObservableCollection<Employee>(mainPageVM.ListEmployeeRoot.Take(numberOfRecPerPage));
            //dataGrid.ItemsSource=mainPageVM.ListEmployee.Take(numberOfRecPerPage);
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

            if (mainPageVM.ListEmployeeRoot.Count <= numberOfRecPerPage)
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
                    if (mainPageVM.ListEmployeeRoot.Count >= (CurPageIndex * numberOfRecPerPage)) //còn at least 0 item để next
                    {

                        if (mainPageVM.ListEmployeeRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() != 0) // còn item để lấy
                        {
                            mainPageVM.ListEmployee = new ObservableCollection<Employee>(mainPageVM.ListEmployeeRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage));
                            if (ActiveBtn == 5 && ViewIndex != no_View)     //nút 5th
                            {

                                ViewIndex++;
                            }
                            btnUpdate();
                            btnDeFocus();
                            CurPageIndex++;
                            count = Math.Min((CurPageIndex) * (numberOfRecPerPage), mainPageVM.ListEmployeeRoot.Count());
                            updtActBtn();
                            btnFocus();

                            if (mainPageVM.ListEmployeeRoot.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0) // hết item để lấy
                            {
                                btnNext.IsEnabled = false;
                                btnNext.Opacity = 0.75;
                                btnLast.IsEnabled = false;
                                btnLast.Opacity = 0.75;
                            }
                        }
                        from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                        lblpageInformation.Content = from + "-" + count + " of " + mainPageVM.ListEmployeeRoot.Count;
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
                            mainPageVM.ListEmployee = new ObservableCollection<Employee>(mainPageVM.ListEmployeeRoot.Take(numberOfRecPerPage));
                            updtLabel();
                        }
                        else
                        {
                            mainPageVM.ListEmployee = new ObservableCollection<Employee>(mainPageVM.ListEmployeeRoot.Skip((CurPageIndex - 1) * numberOfRecPerPage).Take(numberOfRecPerPage));
                            count = CurPageIndex * numberOfRecPerPage;
                            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                            lblpageInformation.Content = from + "-" + count + " of " + mainPageVM.ListEmployeeRoot.Count;
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
                    CurPageIndex = (mainPageVM.ListEmployeeRoot.Count / numberOfRecPerPage);
                    if (mainPageVM.ListEmployeeRoot.Count % numberOfRecPerPage == 0)
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
                    //    dataGrid.ItemsSource = mainPageVM.ListEmployee.Take(numberOfRecPerPage);
                    //    count = (mainPageVM.ListEmployee.Take(numberOfRecPerPage)).Count();
                    //    from = (CurPageIndex - 1) * numberOfRecPerPage + 1;

                    //    lblpageInformation.Content = from + "-" + count + " of " + mainPageVM.ListEmployee.Count;

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
            no_Page = mainPageVM.ListEmployeeRoot.Count / numberOfRecPerPage;
            if (mainPageVM.ListEmployeeRoot.Count % numberOfRecPerPage != 0)
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
            int TotalRec = mainPageVM.ListEmployeeRoot.Skip((ViewIndex - 1) * 5 * numberOfRecPerPage).Count();
            if (TotalRec == 0)
            {
                return 0;
            }
            res = TotalRec / numberOfRecPerPage;
            if (mainPageVM.ListEmployeeRoot.Count() % numberOfRecPerPage != 0)
            {
                res++;
            }
            return res;
        }
        #endregion

        private void MyCheck_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) //Check xem dưới VM có gọi gì ko, nếu có reset itemsource
        {
            if (!FirstRun)
            {                                                                                        
                if (mainPageVM.IsChecked)
                {
                    ListEm = mainPageVM.searchEmployee(); //If == 0 tra ve list rong va thong bao
                }
                else
                {
                    ListEm = mainPageVM.searchDeletedEmployee();
                }
                if (ListEm.Count != 0)
                {
                    mainPageVM.ListEmployee = ListEm;
                    mainPageVM.ListEmployeeRoot = ListEm;
                    No_View_Updt();
                    if (no_Page >= 1)
                    {
                        Navigate((int)PagingMode.First);
                    }
                    else
                    {
                        mainPageVM.ListEmployee.Clear();
                    }
                    updtLabel();
                }
                else
                {
                    mainPageVM.ListEmployeeRoot.Clear();
                    No_View_Updt();
                    Navigate((int)PagingMode.First);
                    updtLabel();
                }






            }
            else
                FirstRun = false;
        }

        //private void Test_Cmd(object sender, RoutedEventArgs e)
        //{
        //    dataGrid.ItemsSource = null;

        //    ListEm = mainPageVM.ListEmployee;
        //    dataGrid.ItemsSource = ListEm;
        //}
        private void Refresh_Data(object sender, RoutedEventArgs e)
        {
            if (mainPageVM.IsChecked)
            {
                mainPageVM.ListEmployeeRoot = mainPageVM.getDataEmployee();

            }
            else
            {
                mainPageVM.ListEmployeeRoot = mainPageVM.getDeletedEmployee();
            }

            No_View_Updt();
            Navigate((int)PagingMode.First);
            updtLabel();
        }
        private void Search_Emp(object sender, RoutedEventArgs e)
        {

            if (mainPageVM.IsChecked)
            {
                ListEm = mainPageVM.searchEmployee(); //If == 0 tra ve list rong va thong bao
             }
            else
            {
                ListEm = mainPageVM.searchDeletedEmployee();
            }
            if (ListEm.Count != 0)
            {
                mainPageVM.ListEmployee = ListEm;
                mainPageVM.ListEmployeeRoot = ListEm;
                No_View_Updt();
                if (no_Page >= 1)
                {
                    Navigate((int)PagingMode.First);
                }
                else
                {
                    mainPageVM.ListEmployee.Clear();
                }
                updtLabel();
            }
            else
            {
                mainPageVM.ListEmployeeRoot.Clear();
                No_View_Updt();
                Navigate((int)PagingMode.First);
                updtLabel();
            }

            #region test luong tìm kiếm Khong co ket qua => quay về mặc định
            //else //Khong co ket qua => ko lam gi het
            //{
            //    listEm = mainPageVM.ListEmployee; // Load lai list default, command dòng này để giữ lại list hiện tại
            //    Navigate((int)PagingMode.First);
            //    count = listEm.Take(numberOfRecPerPage).Count();
            //    from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            //    lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
            //}
            #endregion

            #region test dùng trực tiếp VM
            //mainPageVM.ListEmployee = mainPageVM.searchEmployee(); //If == 0 tra ve list rong va thong bao
            //if (mainPageVM.ListEmployee.Count != 0)
            //{
            //    listEm = mainPageVM.ListEmployee;
            //    dataGrid.ItemsSource = listEm;
            //    Navigate((int)PagingMode.First);
            //    count = listEm.Take(numberOfRecPerPage).Count();
            //    from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            //    lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
            //}
            //else //Khong co ket qua => ko lam gi het
            //{
            //    //listEm = mainPageVM.ListEmployee; // Load lai list default, command dòng này để giữ lại list hiện tại
            //    //Navigate((int)PagingMode.First);
            //    //count = listEm.Take(numberOfRecPerPage).Count();
            //    //from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            //    //lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
            //}
            #endregion


        }

        private void Edit_Click(object sender, RoutedEventArgs e) // Chuyen sang page edit
        {
            //var currentRowIndex = dataGrid.Items.IndexOf(dataGrid.CurrentItem);
            //var x = dataGrid.SelectedCells;
            //var y = dataGrid.CurrentItem;

            EditEmpUC.Visibility = Visibility.Visible;
            IList rows = dataGrid.SelectedItems;
            Employee a = rows[0] as Employee;

            EditEmpUC.TakeEmp(a);

            


            //DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;
            //int index = dataGrid.CurrentCell.Column.DisplayIndex;
            //string cellValue = dataRow.Row.ItemArray[index].ToString();

            //var columnName = ((Binding)((DataGridBoundColumn)dataGrid.CurrentCell.Column).Binding).Path.Path;
            //var cellValue2 = dataRow.Row[columnName];

        }
        public void RemoveItem(ObservableCollection<Employee> collection, Employee instance)
        {
            collection.Remove(collection.Where(i => i.EmployeeCode == instance.EmployeeCode).Single());
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            IList rows = dataGrid.SelectedItems;
            Employee a = rows[0] as Employee;
            if (a.RoleId == 7)
            {
                MessageBox.Show("Không thể xóa Admin");
            }
            else
            {
                if (a.Active == false)
                {
                    if (MessageBox.Show("Bỏ xóa nhân viên này?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        //do no stuff

                    }
                    else
                    {
                        //do yes stuff
                        mainPageVM.ActiveEmployee(a.EmployeeCode, a);
                        //mainPageVM.ListEmployeeRoot = mainPageVM.ListEmployee;
                        No_View_Updt();
                        Navigate((int)PagingMode.First);
                        updtLabel();
                    }
                }

                else
                {
                    if (MessageBox.Show("Xóa nhân viên này?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        //do no stuff

                    }
                    else
                    {
                        //do yes stuff
                        mainPageVM.DeleteEmployee(a.EmployeeCode, a);
                        //mainPageVM.ListEmployeeRoot = mainPageVM.ListEmployee;
                        No_View_Updt();
                        Navigate((int)PagingMode.First);
                        updtLabel();
                    }
                }
            }
        }
        private void MasterHeader_ActiveClick(object sender, RoutedEventArgs e)
        {
            if (mainPageVM.IsChecked == true)
            {
                if (mainPageVM.IsSearching == true)
                {
                    //MessageBox.Show("Đang trong tìm kiếm");
                    ListEm = mainPageVM.searchEmployee();
                    if (ListEm.Count != 0)
                    {
                        mainPageVM.ListEmployeeRoot = ListEm;
                    }
                }
                else
                {
                    mainPageVM.ListEmployeeRoot = mainPageVM.getDataEmployee();
                }
            }
            else
            {
                if (mainPageVM.IsSearching == true)
                {
                   // MessageBox.Show("Đang trong tìm kiếm");
                    ListEm = mainPageVM.searchDeletedEmployee();
                    if (ListEm.Count != 0)
                    {
                        mainPageVM.ListEmployeeRoot = ListEm;
                    }
                    else
                    {
                        mainPageVM.ListEmployeeRoot.Clear();
                        No_View_Updt();
                        Navigate((int)PagingMode.First);
                        updtLabel();
                    }
                }
                else
                {
                    mainPageVM.ListEmployeeRoot = mainPageVM.getDeletedEmployee();
                }
            }
            No_View_Updt();
            if (no_Page >= 1)
            {
                Navigate((int)PagingMode.First);
            }
            else
            {
                mainPageVM.ListEmployee.Clear();
            }
            updtLabel();
        }
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


        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            CellValidate(sender, e);
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (this.dataGrid.SelectedItem != null)
            {
                (sender as DataGrid).RowEditEnding -= DataGrid_RowEditEnding;
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).Items.Refresh();
                (sender as DataGrid).RowEditEnding += DataGrid_RowEditEnding;
            }
            else return;
            IList Row = dataGrid.SelectedItems;
            Employee x = Row[0] as Employee;
            switch (SelectedCol)
            {
                case "PhoneNb":
                    {
                        mainPageVM.UpdatePhoneNb(x.PhoneNb, x.EmployeeCode);
                        break;
                    }
                case "Role":
                    {
                        mainPageVM.UpdateLocalEmpRoleId(x.Role, x.EmployeeCode); // Update local RoleId, local Role đã updated
                        mainPageVM.UpdateRole(x.RoleId, x.EmployeeCode); // Update db RoleId
                        break;
                    }
                case "EmployeeCode":
                    {
                        break;
                    }
                case "EmployeeName":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void CellValidate(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction == DataGridEditAction.Commit)
            {

                var column = e.Column as DataGridBoundColumn;
                DataGridComboBoxColumn clm = e.Column as DataGridComboBoxColumn;
                if (column==null)
                {
                    var bindingPath = (clm.SelectedItemBinding as Binding).Path.Path;
                    // rowIndex has the row index
                    // bindingPath has the column's binding
                    // el.Text has the new, user-entered value
                    SelectedCol = bindingPath;
                    switch (bindingPath)
                    {
                        case "PhoneNb":
                            {
                                int rowIndex = e.Row.GetIndex();
                                var el = e.EditingElement as TextBox;
                                if (!IsDigitsOnly(el.Text))
                                {
                                    MessageBox.Show("Số điện thoại không được chứa chữ cái");
                                    e.Cancel = true;
                                    (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                                }
                                break;
                            }
                        case "Role":
                            {
                                break;
                            }
                        case "EmployeeCode":
                            {
                                break;
                            }
                        case "EmployeeName":
                            {
                                break;
                            }
                    }

                }
                if (column != null)
                {

                    var bindingPath = (column.Binding as Binding).Path.Path;
                    // rowIndex has the row index
                    // bindingPath has the column's binding
                    // el.Text has the new, user-entered value
                    SelectedCol = bindingPath;
                    switch (bindingPath)
                    {
                        case "PhoneNb":
                            {
                                int rowIndex = e.Row.GetIndex();
                                var el = e.EditingElement as TextBox;
                                if (!IsDigitsOnly(el.Text))
                                {
                                    MessageBox.Show("Số điện thoại không được chứa chữ cái");
                                    e.Cancel = true;
                                    (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                                }
                                break;
                            }
                        case "Role":
                            {
                                break;
                            }
                        case "EmployeeCode":
                            {
                                break;
                            }
                        case "EmployeeName":
                            {
                                break;
                            }
                    }
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
       

        private void MasterHeader_AddClick(object sender, RoutedEventArgs e)
        {
            //Window window = new Window
            //{
            //    Title = "Thêm nhân viên",
            //    Content = new AddEmp()
            //};

            //window.ShowDialog();
           
            AddEmpUC.Visibility = Visibility.Visible;
        }

        private void AddEmpUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(ListEmpUC.Visibility == Visibility.Visible)
            {
                ListEmpUC.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (mainPageVM.IsChecked)
                {
                    mainPageVM.ListEmployeeRoot = mainPageVM.getDataEmployee();

                }
                else
                {
                    mainPageVM.ListEmployeeRoot = mainPageVM.getDeletedEmployee();
                }

                No_View_Updt();
                Navigate((int)PagingMode.First);
                updtLabel();
                ListEmpUC.Visibility = Visibility.Visible;
            }
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

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGridCellTarget = (DataGridCell)sender;

            Employee a = dataGridCellTarget.DataContext as Employee;
            //IList a = dataGridCellTarget.BindingGroup.Items[0];



        }

        private void updtLabel()
        {
            count = mainPageVM.ListEmployeeRoot.Take(numberOfRecPerPage).Count();
            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            if (count == 0)
                from = 0;
            lblpageInformation.Content = from + "-" + count + " of " + mainPageVM.ListEmployeeRoot.Count;
        }
    }
}
