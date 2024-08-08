using System.Globalization;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Data;

namespace SiriusGahca
{
    public class ImageConverter : ImageSourceConverter, IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertFrom(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object? ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null)
            {
                return base.ConvertFrom(context, culture, $"pack://siteoforigin:,,,/{value}");
            }
            return value;
        }
    }
}
