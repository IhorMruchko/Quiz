using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Controls;

public class TextValidator : TextBox
{
    public delegate bool TextInputValudator(TextValidator sender, TextCompositionEventArgs args);

    public event TextInputValudator? TextValidation;

    private Regex? charFormatValidator;

    public TextValidator()
    {
        PreviewTextInput += InputReader_PreviewTextInput;
        GotFocus += TextValidator_GotFocus;
        LostFocus += TextValidator_LostFocus;
    }

    public string DefaultValue { get; set; } = "";
    
    public string AcceptableCharFormat
    {
        set => charFormatValidator = new Regex(value);
    }       

    private void TextValidator_LostFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        if (Text.Trim().Equals(string.Empty))
        {
            Text = DefaultValue;
        }
    }

    private void TextValidator_GotFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        SelectAll();
    }

    private void InputReader_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !((charFormatValidator?.IsMatch(e.Text) ?? true) && (TextValidation?.Invoke(this, e) ?? true));
    }
}
