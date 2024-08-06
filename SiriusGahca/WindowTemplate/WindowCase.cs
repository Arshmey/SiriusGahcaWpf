using SiriusGahca.PersonSerialize;
using SiriusGahca.UI_Elements;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SiriusGahca.WindowTemplate
{
	internal class WindowCase : AbstractWindow
	{

		private Grid mainPanel;
		private MainWindow window;
		private PersonDeserializer personDeserializer;
		private readonly List<ContentControl> elements = new List<ContentControl>();
		private Spin? spin;
		private double top = 4;
		private const double topAdding = 132;

		public WindowCase(Grid mainPanel, MainWindow window, PersonDeserializer personDeserializer)
		{
			this.mainPanel = mainPanel;
			this.window = window;
			this.personDeserializer = personDeserializer;
		}

		public override void Create()
		{
			Label back = new Label();
			back.Name = "back";
			back.Background = Brushes.Yellow;
			SizeSet(back, 32, 32);
			AlignmentSet(back);
			MarginSet(back, 0, 0);
			back.PreviewMouseUp += window.CaseChooser;
			elements.Add(back);

			spin = new Spin();
			spin.Name = "spin";
			spin.ImagePerson = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "DataSirius", "ico.png"),
				UriKind.Absolute));
			spin.NamePerson = "Имя: Nyan";
			spin.ButtonClick += (sender, RoutedEventArgs) => window.YouSpinMe(sender, spin);
			AlignmentSet(spin);
			MarginSet(spin, window.ActualWidth / 2 - (spin.Width / 2), 128);
			elements.Add(spin);

			SideBar sideBar = new SideBar();
			sideBar.Name = "sideBar";
			SizeSet(sideBar, 378, window.ActualHeight - 38);
			AlignmentSet(sideBar);
			MarginSet(sideBar, window.ActualWidth - 394, 0);
			elements.Add(sideBar);
		}

		public override void ReturnWindow()
		{
			foreach (ContentControl element in elements)
			{
				switch (element)
				{
					case Spin:
						Spin spin = (Spin)element;
						spin.ImagePerson = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "DataSirius",
							"ico.png"), UriKind.Absolute));
						spin.NamePerson = "Имя: Nyan";
						break;
					case SideBar:
						SideBar sideBar = (SideBar)element;
						sideBar.ClearSideBar();
						sideBar.SizeContainer = personDeserializer.Person.Count * 132;
						sideBar.ScrollMaximum = sideBar.SizeContainer - sideBar.Height;

						foreach (Person person in personDeserializer.Person)
						{
							PersonInfo personInfo = new PersonInfo();
							personInfo.ImagePerson = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), person.IconPerson),
								UriKind.Absolute));
							personInfo.NamePerson = person.Name;
							personInfo.RatePerson = $"Rate: x{person.Rate}";
							SizeSet(personInfo, 320, 128);
							AlignmentSet(personInfo);
							MarginSet(personInfo, 3, top);
							sideBar.AddElement(personInfo);

							top += topAdding;
						}
						break;
				}
				mainPanel.Children.Add(element);
			}

			top = 0;
		}

		public async void ResetResolution()
		{
			await Task.Factory.StartNew(() =>
			{
				foreach (ContentControl element in elements)
				{
					switch (element)
					{
						case Spin:
							((Spin)element).Dispatcher.Invoke(() =>
							{
								AlignmentSet((Spin)element);
								MarginSet((Spin)element, window.ActualWidth / 2 - (((Spin)element).Width / 2), 128);
							});
							break;
						case SideBar:
							((SideBar)element).Dispatcher.Invoke(() =>
							{
								SizeSet((SideBar)element, 378, window.ActualHeight - 38);
								AlignmentSet((SideBar)element);
								MarginSet(element, window.ActualWidth - 394, 0);
								((SideBar)element).SizeContainer = personDeserializer.Person.Count * 132;
								((SideBar)element).ScrollMaximum = ((SideBar)element).SizeContainer - ((SideBar)element).Height;
							});
							break;
					}
				}
			});
		}
	}
}
