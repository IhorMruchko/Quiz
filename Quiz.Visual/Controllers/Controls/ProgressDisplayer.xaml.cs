using System.Windows.Controls;

namespace Quiz.Visual.Controllers.Controls;

public partial class ProgressDisplayer : UserControl
{
    public delegate object UpdateProgress(object? updatableObject);

    public delegate bool IsUpdatable(object? current, object? final);

    private object? _currentProgressState;

    private object? _finalProgressState;
    
    public ProgressDisplayer()
    {
        InitializeComponent();
    }

    public UpdateProgress? ProgressUpdates { get; set; }

    public IsUpdatable? IsProgressUpdatable { get; set; }

    public object? CurrentProgressState 
    { 
        get => _currentProgressState; 
        set
        {
            _currentProgressState = value;
            Dispatcher.Invoke(() => DataInformation.Content = string.Format(Format, value, _finalProgressState));
        }
    }

    public object? FinalProgressState
    {
        get => _finalProgressState;
        set
        {
            _finalProgressState = value;
            Dispatcher.Invoke(() => DataInformation.Content = string.Format(Format, _currentProgressState, value));
        }
    }


    public string Format { get; set; } = "{0}/{1}";

    public void Update()
    {
        if ((IsProgressUpdatable?.Invoke(_currentProgressState, _finalProgressState) ?? false))
        {
            CurrentProgressState = ProgressUpdates?.Invoke(CurrentProgressState);
        }
    }
}
