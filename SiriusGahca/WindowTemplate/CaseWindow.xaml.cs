using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SiriusGahca.WindowTemplate
{
    /// <summary>
    /// Interaction logic for CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Page
    {
        private CancellationTokenSource _cts;
        private string _path;

        public ObservableCollection<Person> Persons { get; private set; }

        public event Action? BackButtonPressed;

        public CaseWindow(Case selected)
        {
            _path = selected.Tag;
            _cts = new CancellationTokenSource();
            Persons = new ObservableCollection<Person>();

            InitializeComponent();

            DataContext = this;
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            foreach (Person person in Person.Deserialize(_path))
            {
                Persons.Add(person);
            }
        }

        private void SpinWorker()
        {
            int numChange;
            Random random = new Random();
            for (int spineCount = 0; spineCount < 3500000; spineCount++)
            {
                numChange = random.Next(1, 101);
                foreach (Person person in Persons)
                {
                    if (numChange >= person.Min && numChange <= person.Max)
                    {
                        personImage.Dispatcher.Invoke(() =>
                        {
                            personImage.Source = new BitmapImage(new Uri($"pack://siteoforigin:,,,/{person.IconPerson}"));
                        });
                        personName.Dispatcher.Invoke(() =>
                        {
                            personName.Content = $"Имя: {person.Name}";
                        });
                        break;
                    }
                }
                if (_cts.Token.WaitHandle.WaitOne(100))
                {
                    break;
                }
            }
        }

        private async void YouSpinMe(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button ?? throw new Exception();
            btn.IsEnabled = false;
            await Task.Factory.StartNew(SpinWorker, _cts.Token);
            btn.IsEnabled = true;
        }

        private void OnBackButtonClick(object sender, MouseButtonEventArgs e)
        {
            _cts.Cancel();
            BackButtonPressed?.Invoke();
        }
    }
}
