using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SiriusGahca
{
    public class RelayCommand : ICommand
    {
        readonly Action<Case?> _execute;

        public RelayCommand(Action<Case?> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameters)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object? parameters)
        {
            _execute(parameters as Case);
        }
    }
}
