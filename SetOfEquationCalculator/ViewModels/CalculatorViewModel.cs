using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using SetOfEquationCalculator.Models;

namespace SetOfEquationCalculator.ViewModels;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private ICommand _clickCommand;
    private float _w;
    private float _wx;
    private float _wy;

    private float _x;


    private float _y;

    public CalculatorViewModel()
    {
        Equation1 = new Equation();
        Equation2 = new Equation();
    }

    public float X
    {
        get => _x;
        set
        {
            _x = value;
            OnPropertyChanged();
        }
    }

    public float Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged();
        }
    }


    public Equation Equation1 { get; set; }
    public Equation Equation2 { get; set; }

    public ICommand ClickCommand
    {
        get { return _clickCommand ?? (_clickCommand = new CommandHandler(() => Count(), () => true)); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;


    private void Count()
    {
        _w = Equation1.A * Equation2.B - Equation1.B * Equation2.A;
        _wy = Equation1.C * Equation2.B - Equation1.B * Equation2.C;
        _wx = Equation1.A * Equation2.C - Equation1.C * Equation2.A;

        if (_w == 0 && _wx == 0 && _wy == 0)
        {
            MessageBox.Show("Układ Nieoznaczony");
            return;
        }

        if (_w == 0 && _wx != 0 && _wy != 0)
        {
            MessageBox.Show("Układ Sprzeczny");
            return;
        }

        X = _wx / _w;
        Y = _wy / _w;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}