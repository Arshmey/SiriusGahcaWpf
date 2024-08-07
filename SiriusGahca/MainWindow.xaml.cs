using SiriusGahca.WindowTemplate;
using SiriusGahca.UI_Elements;
using System.IO;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SiriusGahca
{
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Case> Cases { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Cases = new ObservableCollection<Case>();

            windowCase = new WindowCase(mainSpace, this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Case c in Case.Deserialize(Path.Combine("DataSirius", "Case.xml")))
            {
                Cases.Add(c);
            }
            //windowCase.Create();
        }

        public void CaseChoose(object sender, MouseButtonEventArgs e)
        {
            string? tag = "";
            if (!string.IsNullOrEmpty(tag))
            {
                mainSpace.Children.Clear();
                //persons = Person.Deserialize(tag);
                windowCase.ReturnWindow();
            }
        }




        public ObservableCollection<Person> Persons { get; private set; }
        private CancellationTokenSource? cts;
        public void CaseChooser(object sender, MouseButtonEventArgs e)
        {
            cts?.Cancel();
            mainSpace.Children.Clear();
        }
        public async void YouSpinMe(object sender, Spin spin)
        {
            int numChange;
            int spineCount = 0;
            Random random = new Random();
            cts = new CancellationTokenSource();
            ((Button)sender).IsEnabled = false;
            await Task.Factory.StartNew(() =>
            {
                while (!cts.IsCancellationRequested && spineCount < 35)
                {
                    numChange = random.Next(1, 101);
                    foreach (Person person in persons)
                    {
                        if (numChange >= person.Min && numChange <= person.Max && !cts.IsCancellationRequested)
                        {
                            spin.Dispatcher.Invoke(() =>
                            {
                                spin.ImagePerson = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), person.IconPerson),
                                    UriKind.Absolute));
                                spin.NamePerson = $"Имя: {person.Name}";
                            });
                            break;
                        }
                        else if (cts.IsCancellationRequested) { break; }
                    }
                    spineCount++;
                    Thread.Sleep(100);
                }
            }, cts.Token);
            ((Button)sender).IsEnabled = true;
        }



        private readonly WindowCase windowCase;
        private void ReloadGUI(object sender, SizeChangedEventArgs e)
        {
            windowCase.ResetResolution();
        }
    }
}