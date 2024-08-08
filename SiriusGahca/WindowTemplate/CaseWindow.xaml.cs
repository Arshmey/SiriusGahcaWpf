using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SiriusGahca.WindowTemplate
{
	/// <summary>
	/// Interaction logic for CaseWindow.xaml
	/// </summary>
	public partial class CaseWindow : Page
	{

		private string path;
		private Action menu;
		private CancellationTokenSource? cts;

		public ObservableCollection<Person> Persons { get; private set; }

		public CaseWindow(string path, Action menu)
		{
			this.path = path;
			this.menu = menu;

			Persons = new ObservableCollection<Person>();

			InitializeComponent();
		}

		private void InitializedWindow(object sender, EventArgs e)
		{
			foreach (Person person in Person.Deserialize(path))
			{
				Persons.Add(person);
			}
		}

		private async void YouSpinMe(object sender, RoutedEventArgs e)
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
					foreach (Person person in Persons)
					{
						if (numChange >= person.Min && numChange <= person.Max && !cts.IsCancellationRequested)
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
						else if (cts.IsCancellationRequested) { break; }
					}
					spineCount++;
					Thread.Sleep(100);
				}
			}, cts.Token);
			((Button)sender).IsEnabled = true;
		}

		private void CaseChooser(object sender, MouseButtonEventArgs e)
		{
			cts?.Cancel();
			menu.Invoke();
		}
	}
}
