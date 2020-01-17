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
        public event RoutedEventHandler CustomClick;
        public event RoutedEventHandler RefreshClick;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomClick?.Invoke(sender, e);

        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshClick?.Invoke(sender, e);

        }
    }
}
