using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IRES_Globals.GlobalClass
{   
        public class EmptyDoubleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null || (double)value == default(double))
                    return "";

                return value.ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (String.IsNullOrEmpty(value as string))
                    return default(double);

                return double.Parse(value.ToString());
            }
        }
    
}
