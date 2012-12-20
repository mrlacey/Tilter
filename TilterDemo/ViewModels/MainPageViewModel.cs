namespace TilterDemo.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            this.Command = new DelegateCommand(this.CommandExecuted);
        }

        public ICommand Command { get; set; }

        public string SomeValue { get; set; }

        private void CommandExecuted(object obj)
        {
            MessageBox.Show("Command was executed", obj.ToString(), MessageBoxButton.OK);
        }
    }

    public class DelegateCommand : ICommand
    {
        readonly Func<object, bool> canExecute;

        readonly Action<object> executeAction;

        bool canExecuteCache;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> executeAction)
        {
            this.executeAction = executeAction;
            this.canExecute = delegate { return true; };
        }

        public bool CanExecute(object parameter)
        {
            bool temp = canExecute(parameter);

            if (canExecuteCache != temp)
            {
                canExecuteCache = temp;

                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }

            return canExecuteCache;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}