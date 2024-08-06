using SiriusGahca.WindowTemplate;
using SiriusGahca.PersonSerialize;
using SiriusGahca.UI_Elements;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SiriusGahca.CaseSerialize;

namespace SiriusGahca
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly CaseDeserialize caseDeserialize = new CaseDeserialize();
		private readonly PersonDeserializer personDeserializer = new PersonDeserializer();
		private WindowMenu mainMenu;
		private WindowCase windowCase;
		private Random? random;
		private CancellationTokenSource? cts;

		public MainWindow()
		{
			InitializeComponent();

			mainMenu = new WindowMenu(mainSpace, this, caseDeserialize);
			windowCase = new WindowCase(mainSpace, this, personDeserializer);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Icon = new BitmapImage(new Uri(Path.Combine("DataSirius", "ico.png"), UriKind.Relative));
			mainSpace.Background = new ImageBrush(new BitmapImage(new Uri(@"DataSirius/Sirius_tac.png", UriKind.Relative)));
			caseDeserialize.Deserialize(Path.Combine("DataSirius", "Case.xml"));
			mainMenu.Create();
			windowCase.Create();
		}

		public async void YouSpinMe(object sender, Spin spin)
		{
			int numChange;
			int spineCount = 0;
			random = new Random();
			cts = new CancellationTokenSource();
			((Button)sender).IsEnabled = false;
			await Task.Factory.StartNew(() =>
			{
				while (!cts.IsCancellationRequested && spineCount < 35)
				{
					numChange = random.Next(1, 101);
					foreach (Person person in personDeserializer.Person)
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
					}
					Thread.Sleep(100);
					spineCount++;
				}
			}, cts.Token);
			((Button)sender).IsEnabled = true;
		}

		private void ReloadGUI(object sender, SizeChangedEventArgs e)
		{
			windowCase.ResetResolution();
		}

		public void CaseChooser(object sender, MouseButtonEventArgs e)
		{
			if(cts != null) { cts.Cancel(); }
			mainSpace.Children.Clear();
			mainMenu.ReturnWindow();
		}

		public void CaseChoose(object sender, MouseButtonEventArgs e)
		{
			mainSpace.Children.Clear();
			personDeserializer.Deserialize(((CasePeresent)sender).Tag.ToString());
			windowCase.ReturnWindow();
		}

	}
}