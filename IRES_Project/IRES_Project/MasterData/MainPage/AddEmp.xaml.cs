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
    /// Interaction logic for AddEmp.xaml
    /// </summary>
    public partial class AddEmp : UserControl
    {
        
        public AddEmp()
        {
            InitializeComponent();
            AddEmpViewModel AddEmpVM = new AddEmpViewModel();
            this.DataContext = AddEmpVM;
            ResComb.ItemsSource = AddEmpVM.ListRes;

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}       
