using System.Windows;
using SiriusGahca.WindowTemplate;

namespace SiriusGahca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuWindow _menu;

        public MainWindow()
        {
            InitializeComponent();

            _menu = new MenuWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _menu.CaseSelected += OnCaseSelected;
            Content = _menu;
        }

        private void OnCaseSelected(Case selected)
        {
            CaseWindow caseWindow = new CaseWindow(selected);
            caseWindow.BackButtonPressed += OnBackButtonPressed;
            Content = caseWindow;
        }

        private void OnBackButtonPressed()
        {
            Content = _menu;
        }
    }
}