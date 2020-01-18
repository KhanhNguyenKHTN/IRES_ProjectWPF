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

namespace IRES_Project.MasterData.MainPage
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        MainPageViewModel mainPageVM = new MainPageViewModel();
        int ActiveBtn = 1;
        int CurPageIndex = 1;
        int PrePageIndex = 1;
        int no_View, ViewIndex;     
        int count;
        int from;
        int no_ListEm;
        int no_Page;
        ObservableCollection<Employee> listEm;

        private int numberOfRecPerPage = 3;
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        public MainPage()
        {
            InitializeComponent();
            this.DataContext = mainPageVM;
            listEm = mainPageVM.ListEmployee;
            dataGrid.ItemsSource = listEm.Take(numberOfRecPerPage);
            no_ListEm = listEm.Count();
            no_Page = no_ListEm / numberOfRecPerPage;
            #region Paging

            btnNext.IsEnabled = true;
            btnNext.Opacity = 1;
            if (listEm.Count <= numberOfRecPerPage)
            {
                btnLast.IsEnabled = false;
            }
            else
            {
                btnLast.IsEnabled = true;
                btnLast.Opacity = 1;

            }
            btnPrev.IsEnabled = false;
            btnFirst.IsEnabled = false;
            count = listEm.Take(numberOfRecPerPage).Count();
            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
            //btnFirst.IsEnabled = false;
            //cbNumberOfRecords.Items.Add("10");
            //cbNumberOfRecords.Items.Add("20");
            //cbNumberOfRecords.Items.Add("30");
            //cbNumberOfRecords.Items.Add("50");
            //cbNumberOfRecords.Items.Add("100");
            //cbNumberOfRecords.SelectedItem = 10;
            #endregion
            #region Config button
           
          
            #endregion
        }



        private void IsActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Seach_Emp(object sender, RoutedEventArgs e)
        {
           
            
            listEm = mainPageVM.searchEmployee();
            dataGrid.ItemsSource = listEm;
            Navigate((int)PagingMode.First);
            count = listEm.Take(numberOfRecPerPage).Count();
            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
            lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;


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
                    if (listEm.Count >= (CurPageIndex * numberOfRecPerPage)) //còn at least 0 item để next
                    {

                        if (listEm.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() != 0) // còn item để lấy
                        {
                            dataGrid.ItemsSource = null;
                            dataGrid.ItemsSource = listEm.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            PrePageIndex = CurPageIndex;
                            btnDeFocus();
                            CurPageIndex++;
                            count = Math.Min((CurPageIndex) * (numberOfRecPerPage), listEm.Count());
                            updtActBtn();
                            btnFocus();
                           

                            if (listEm.Skip(CurPageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0) // hết item để lấy
                            {
                                btnNext.IsEnabled = false;
                                btnNext.Opacity = 0.75;
                                btnLast.IsEnabled = false;
                                btnLast.Opacity = 0.75;
                            }
                        }
                        from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                        lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
                    }
                    break;
                case (int)PagingMode.Previous:
                    
                    btnNext.IsEnabled = true;
                    btnNext.Opacity = 1;
                    btnLast.IsEnabled = true;
                    btnLast.Opacity = 1;
                    btnDeFocus();
                    if (CurPageIndex > 1)
                    {
                        PrePageIndex = CurPageIndex;
                        CurPageIndex -= 1;
                        dataGrid.ItemsSource = null;
                        if (CurPageIndex == 1)
                        {
                            btnPrev.IsEnabled = false;
                            btnPrev.Opacity = 0.75;
                            btnFirst.IsEnabled = false;
                            btnFirst.Opacity = 0.75;
                            dataGrid.ItemsSource = listEm.Take(numberOfRecPerPage);
                            count = listEm.Take(numberOfRecPerPage).Count();
                            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                            lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
                        }
                        else
                        {
                            dataGrid.ItemsSource = listEm.Skip((CurPageIndex - 1) * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = CurPageIndex * numberOfRecPerPage;
                            from = (CurPageIndex - 1) * numberOfRecPerPage + 1;
                            lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;
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
                    PrePageIndex = CurPageIndex;
                    CurPageIndex = 2;
                    switch (PrePageIndex % 5)
                    {
                        case 1:
                            {
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
                                btn3.Opacity = 0.75;
                                btn3.BorderThickness = new Thickness(0.0);
                                break;
                            }
                        case 4:
                            {
                                btn4.Opacity = 0.75;
                                btn4.BorderThickness = new Thickness(0.0);
                                break;
                            }
                        case 0:
                            {
                                btn5.Opacity = 0.75;
                                btn5.BorderThickness = new Thickness(0.0);
                                break;
                            }
                    }
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    PrePageIndex = CurPageIndex;
                    switch (PrePageIndex % 5)
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
                                btn3.Opacity = 0.75;
                                btn3.BorderThickness = new Thickness(0.0);
                                break;
                            }
                        case 4:
                            {
                                btn4.Opacity = 0.75;
                                btn4.BorderThickness = new Thickness(0.0);
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                    }
                    CurPageIndex = (listEm.Count / numberOfRecPerPage) - 1;
                    Navigate((int)PagingMode.Next);
                    break;
                    #region pagecount
                    //case (int)PagingMode.PageCountChange:
                    //    CurPageIndex = 1;
                    //    numberOfRecPerPage = Convert.ToInt32(cbNumberOfRecords.SelectedItem);
                    //    dataGrid.ItemsSource = null;
                    //    dataGrid.ItemsSource = listEm.Take(numberOfRecPerPage);
                    //    count = (listEm.Take(numberOfRecPerPage)).Count();
                    //    from = (CurPageIndex - 1) * numberOfRecPerPage + 1;

                    //    lblpageInformation.Content = from + "-" + count + " of " + listEm.Count;

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

        //private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Navigate((int)PagingMode.PageCountChange);
        //}
        #endregion


        #region Navigate number 1 2 3 4 5
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveBtn != 1)
            {
                PrePageIndex = CurPageIndex;
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
                    case 0:
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
                PrePageIndex = CurPageIndex;
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
                    case 0:
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

            if (ActiveBtn!= 3)
            {
                PrePageIndex = CurPageIndex;
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
                    case 0:
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
                PrePageIndex = CurPageIndex;
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
                    case 0:
                        {
                            Navigate((int)PagingMode.Previous);
                            break;
                        }
                }
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveBtn != 0)
            {
                PrePageIndex = CurPageIndex;
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
        public void viewNext()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = listEm.Skip(ViewIndex * numberOfRecPerPage * 5).Take(numberOfRecPerPage);

            

            ViewIndex++;

            if ( no_ListEm < ViewIndex*5*numberOfRecPerPage)
            {

            }

             PrePageIndex = CurPageIndex;
            CurPageIndex++;





        }


        public void btnUpdate()
        {
            if(GetNo_Page()==0)
            {
                btn1.Visibility = Visibility.Collapsed;
                btn2.Visibility = Visibility.Collapsed;
                btn3.Visibility = Visibility.Collapsed;
                btn4.Visibility = Visibility.Collapsed;
                btn5.Visibility = Visibility.Collapsed;
            }
            else
            {
                switch (GetNo_Page() % 5)
                {
                    case 1:
                        {
                            btn2.Visibility = Visibility.Collapsed;
                            btn3.Visibility = Visibility.Collapsed;
                            btn4.Visibility = Visibility.Collapsed;
                            btn5.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 2:
                        {
                            btn3.Visibility = Visibility.Collapsed;
                            btn4.Visibility = Visibility.Collapsed;
                            btn5.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 3:
                        {
                            btn4.Visibility = Visibility.Collapsed;
                            btn5.Visibility = Visibility.Collapsed;
                            btn5.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 4:
                        {
                            btn5.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
        }

        public int GetNo_Page()
        {
            int res;
            int TotalRec = listEm.Skip((ViewIndex-1)*5*numberOfRecPerPage).Count();
            if (TotalRec == 0)
            {
                return 0;
            }
            res = TotalRec / numberOfRecPerPage;
            if (listEm.Count() % numberOfRecPerPage != 0)
            {
                res++;
            }
            return res;
        }




























    }
}
