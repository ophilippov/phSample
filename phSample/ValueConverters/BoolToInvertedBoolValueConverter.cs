using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace phSample
{
    /// <summary>
    /// A converter that takes a bool value and returns its inverted value
    /// </summary>
    public class BoolToInvertedBoolValueConverter : BaseValueConverter<BoolToInvertedBoolValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
