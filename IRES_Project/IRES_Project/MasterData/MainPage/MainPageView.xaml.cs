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
using System.Windows.Shapes;
using ViewModel.Modules;
using IRES_Project.Views;
using IRES_Project;

namespace IRES_Project.Views.MainPage
{
    /// <summary>
    /// Interaction logic for MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        MainPageViewModel mainPage = null;
        public MainPageView()
        {
            InitializeComponent();

            mainPage = new MainPageViewModel();

            DataContext = mainPage;
        }
    }
}
