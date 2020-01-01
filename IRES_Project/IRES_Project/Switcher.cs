using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IRES_Project
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl page)
        {
            pageSwitcher.Navigate(page);
        }
    }
}
