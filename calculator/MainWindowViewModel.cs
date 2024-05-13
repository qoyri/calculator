using System.ComponentModel;
using System.Windows.Input;

namespace calculator;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private double _currentNumber = 0;
    private string _currentOp = "";
    private string _displayNumber = "0";
    private bool _calculationCompleted;

    public string DisplayNumber
    {
        get { return _displayNumber; }
        set
        {
            _displayNumber = value;
            OnPropertyChanged();
        }
    }

    public ICommand ButtonCommand => new RelayCommand(ButtonClick);
    public ICommand CloseCommand => new RelayCommand(CloseApplication);
    public ICommand MinimizeCommand => new RelayCommand(MinimizeApplication);

    private static void MinimizeApplication(object obj)
    {
        System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }

    private void CloseApplication(object obj)
    {
        System.Windows.Application.Current.Shutdown();
    }

    private void ButtonClick(object param)
    {
        var input = (string)param;

        switch (input)
        {
            case "CLR":
                DisplayNumber = "0";
                _currentNumber = 0;
                _currentOp = "";
                break;

            case "+":
            case "-":
            case "*":
            case "/":
                _currentOp = input;
                _currentNumber = double.Parse(DisplayNumber);
                DisplayNumber = "0";
                break;

            case "=":
                PerformCalculation(double.Parse(DisplayNumber));
                _currentOp = "";
                break;

            default:
                if (_calculationCompleted)
                {
                    DisplayNumber = input;
                    _calculationCompleted = false;
                }
                else
                {
                    DisplayNumber = DisplayNumber == "0" ? input : DisplayNumber + input;
                }

                break;
        }
    }

    private void PerformCalculation(double nextNumber)
    {
        switch (_currentOp)
        {
            case "+":
                DisplayNumber = (_currentNumber + nextNumber).ToString();
                break;
            case "-":
                DisplayNumber = (_currentNumber - nextNumber).ToString();
                break;
            case "*":
                DisplayNumber = (_currentNumber * nextNumber).ToString();
                break;
            case "/":
                DisplayNumber = nextNumber != 0 ? (_currentNumber / nextNumber).ToString() : "Err";
                break;
        }

        _calculationCompleted = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}