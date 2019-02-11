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
    /// A converter that takes an int value and returns a <see cref="Thickness"/>
    /// </summary>
    public class IntToThicknessValueConverter : BaseValueConverter<IntToThicknessValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness((int)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
