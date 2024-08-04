using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace SiriusGahca.Forms
{
	internal class WindowMainMenu : AbstractWindow
	{

		private int imgCount;
		private double left;
		private double top;
		private double leftAdding = 196;
		private double topAdding = 176;
		private List<Case> Case { get; set; }
		private XmlSerializer deserialize = new XmlSerializer(typeof(List<Case>));
		private Grid mainPanel;
		private MainWindow window;

		public WindowMainMenu(Grid mainPanel, MainWindow window)
		{
			this.mainPanel = mainPanel;
			this.window = window;
		}

		public override void Create()
		{
			imgCount = 0;
			left = 16;
			top = 16;
			foreach (Case _case in Case)
			{
					CasePeresent casePeresent = new CasePeresent();
					casePeresent.NameCase = _case.Name;
					casePeresent.IconCaseImage = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), _case.IconPerson), 
						UriKind.RelativeOrAbsolute));
					casePeresent.Tag = $"{Path.Combine(Directory.GetCurrentDirectory(), _case.Tag)}";
					AlignmentSet(casePeresent);
					MarginSet(casePeresent, left, top);
					casePeresent.PreviewMouseDown += window.CaseChoose;
					mainPanel.Children.Add(casePeresent);

					if (imgCount != 0 && imgCount % 5 == 0)
					{
						left = 16;
						top += topAdding;
						imgCount++;
					} else { left += leftAdding; imgCount++; }
			}
		}

		public void Deserialize(string path)
		{
			using (FileStream reader = new FileStream(path, FileMode.OpenOrCreate))
			{
				Case = deserialize.Deserialize(reader) as List<Case>;
			}
		}
	}
}
