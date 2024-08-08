using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SiriusGahca
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

		public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
			new MVVM(this).Run();
		}

	}

	public class ImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				ImageSourceConverter converter = new ImageSourceConverter();
				return converter.ConvertFrom($"pack://siteoforigin:,,,/{value}");
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}