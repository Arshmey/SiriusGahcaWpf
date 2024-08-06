using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using SiriusGahca.CaseSerialize;

namespace SiriusGahca.WindowTemplate
{
    internal class WindowMenu : AbstractWindow
	{
		private Grid mainPanel;
		private MainWindow window;
		private CaseDeserialize caseDeserialize;
		private readonly List<CasePeresent> casePeresents = new List<CasePeresent>();
		private int imgCount = 0;
		private double left = 16;
		private double top = 16;
		private const double leftAdding = 196;
		private const double topAdding = 176;

		public WindowMenu(Grid mainPanel, MainWindow window, CaseDeserialize caseDeserialize)
		{
			this.mainPanel = mainPanel;
			this.window = window;
			this.caseDeserialize = caseDeserialize;
		}

		public override void Create()
		{
			foreach (Case _case in caseDeserialize.Case)
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
				casePeresents.Add(casePeresent);

				if (imgCount != 0 && imgCount % 5 == 0)
				{
					left = 16;
					top += topAdding;
					imgCount++;
				}
				else { left += leftAdding; imgCount++; }
			}
		}

		public override void ReturnWindow() 
		{
			foreach (CasePeresent casePeresent in casePeresents)
			{
				mainPanel.Children.Add(casePeresent);
			}
		}
	}
}
