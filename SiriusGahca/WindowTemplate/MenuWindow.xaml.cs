using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace SiriusGahca.WindowTemplate
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Page
    {
        private RelayCommand? _relayCommand;

        public ObservableCollection<Case> Cases { get; private set; }

        public ICommand CaseSelectedCommand
        {
            get
            {
                if (_relayCommand == null)
                {
                    _relayCommand = new RelayCommand(OnCaseSelected);
                }
                return _relayCommand;
            }
        }

        public event Action<Case>? CaseSelected;

        public MenuWindow()
        {
            Cases = new ObservableCollection<Case>();

            InitializeComponent();

            DataContext = this;
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            foreach (Case c in Case.Deserialize(Path.Combine("DataSirius", "Case.xml")))
            {
                Cases.Add(c);
            }
        }

        private void OnCaseSelected(Case? selected)
        {
            if (selected != null)
            {
                CaseSelected?.Invoke(selected);
            }
        }
    }
}
