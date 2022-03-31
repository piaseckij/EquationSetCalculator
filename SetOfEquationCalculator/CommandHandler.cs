using System;
using System.Windows.Input;

namespace SetOfEquationCalculator;

public class CommandHandler : ICommand
{
    private readonly Action _action;
    private Func<bool> _canExecute;


    public CommandHandler(Action action, Func<bool> canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }


    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }


    bool ICommand.CanExecute(object? parameter)
    {
        return true;
    }


    public void Execute(object parameter)
    {
        _action();
    }
}