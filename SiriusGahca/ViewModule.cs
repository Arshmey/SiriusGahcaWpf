using SiriusGahca.WindowTemplate;
using System.Windows.Controls;

namespace SiriusGahca
{
    class MVVM
    {

        private MainWindow mainWindow;
        private MenuWindow menuWindow;

        public MVVM(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Run()
        {
			menuWindow = new MenuWindow(LoadCase);
			SetData(menuWindow);
		}

        private void LoadMenu()
        {
			menuWindow = new MenuWindow(LoadCase);
			SetData(menuWindow);
		}

        private void LoadCase()
        {
            if (string.IsNullOrEmpty(menuWindow.DataPerson)) { return; }
			CaseWindow caseWindow = new CaseWindow(menuWindow.DataPerson, LoadMenu);
            SetData(caseWindow);
		}

        private void SetData(Page page)
        {
			mainWindow.Content = page.Content;
			mainWindow.DataContext = page;
		}

    }
}
