using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModel.GlobalViewModels;


namespace ViewModel.Modules
{

    public class MainPageViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public MainPageViewModel()
        {
            //LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    Isloaded = true;
            //    loginPage loginWindow = new loginPage();
            //    loginWindow.ShowDialog();
            //}
            //  );
        }
    }
}
