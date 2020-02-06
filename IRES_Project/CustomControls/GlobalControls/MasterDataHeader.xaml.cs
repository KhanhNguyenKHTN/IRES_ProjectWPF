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
using ViewModel.GlobalViewModels;
using ViewModel.Modules;

namespace CustomControls.GlobalControls
{
    /// <summary>
    /// Interaction logic for MasterDataHeader.xaml
    /// </summary>
    
    public partial class MasterDataHeader : UserControl
    {
       
        public MasterDataHeader()
        {
            InitializeComponent();
            
          

        }
        public event RoutedEventHandler SearchClick;
        public event RoutedEventHandler RefreshClick;
        public event RoutedEventHandler TestClick;
        public event RoutedEventHandler ActiveClick;

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchClick?.Invoke(sender, e);

        }
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            TestClick?.Invoke(sender, e);

        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshClick?.Invoke(sender, e);

        }
        private void Active_Click(object sender, RoutedEventArgs e)
        {
           
                ActiveClick?.Invoke(sender, e);

        }

        private void MySearch_KeyUp(object sender, KeyEventArgs e)
        {
            //if(e.Key == Key.Enter)
            //{
            //    ToFireSearchCheckBox.IsChecked = !ToFireSearchCheckBox.IsChecked;
              
            //}
        }
    }
}
