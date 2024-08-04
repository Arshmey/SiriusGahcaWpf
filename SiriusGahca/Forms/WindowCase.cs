using SiriusGahca.LogicPerson;
using SiriusGahca.UI_Elements;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SiriusGahca.Forms
{
	internal class WindowCase : AbstractWindow
	{

		private Grid mainPanel;
		private MainWindow window;
		private PersonDeserializer personDeserializer;
		private Spin spin;
		private double top;
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
			back.Background = Brushes.Yellow;
			SizeSet(back, 32, 32);
			AlignmentSet(back);
			MarginSet(back, 0, 0);
			back.PreviewMouseUp += window.CaseChooser;
			mainPanel.Children.Add(back);

			spin = new Spin();
			spin.ImagePerson = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "DataSirius", "ico.png"),
				UriKind.Absolute));
			spin.NamePerson = "Имя: Nyan";
			spin.ButtonClick += (sender, RoutedEventArgs) => window.YouSpinMe(sender, spin);
			AlignmentSet(spin);
			MarginSet(spin, window.ActualWidth / 2 - (spin.Width / 2), 128);
			mainPanel.Children.Add(spin);

			SideBar sideBar = new SideBar();
			SizeSet(sideBar, 378, window.ActualHeight - 38);
			AlignmentSet(sideBar);
			MarginSet(sideBar, window.ActualWidth - 394, 0);
			sideBar.SizeContainer = personDeserializer.Person.Count * 132;
			sideBar.ScrollMaximum = sideBar.SizeContainer - sideBar.Height;
			mainPanel.Children.Add(sideBar);

			top = 4;
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
		}
	}
}
