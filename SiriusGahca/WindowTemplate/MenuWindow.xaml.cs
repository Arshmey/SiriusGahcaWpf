using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SiriusGahca.WindowTemplate
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Page
    {

		private Action _case;
		public ObservableCollection<Case> Cases { get; private set; }
		public string? DataPerson { get; private set; }

		public MenuWindow(Action _case)
        {
			this._case = _case;

			Cases = new ObservableCollection<Case>();

			InitializeComponent();
		}

		private void Page_Initialized(object sender, EventArgs e)
		{
			foreach (Case _case in Case.Deserialize(Path.Combine("DataSirius", "Case.xml")))
			{
				Cases.Add(_case);
			}
		}

		private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			StackPanel stackPanel = sender as StackPanel ?? throw new Exception();
			DataPerson = stackPanel.Tag.ToString();
			_case.Invoke();
		}
	}
}
