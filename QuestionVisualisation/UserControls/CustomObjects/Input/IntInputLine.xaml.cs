using QuestionVisualisation.Extensions;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Input
{
    public partial class IntInputLine : UserControl
    {
        private readonly Regex validator = new("[0-9]{2}");

        public IntInputLine()
        {
            InitializeComponent();
        }

        public int MinValue { get; set; } = int.MinValue;

        public int MaxValue { get; set; } = int.MaxValue;


        public int Value
        {
            get => TextContainer.Text.ToInt();
            set => TextContainer.Text = value.ToString();
        }

        private void InputReader_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validator.IsMatch(e.Text) && !(TextContainer.Text + e.Text).ToInt().Between(MinValue, MaxValue);
        }

        private void TextContainer_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TextContainer.SelectAll();
        }

        private void TextContainer_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextContainer.Text.Trim().Equals(string.Empty))
            {
                TextContainer.Text = "0";
            }
        }
    }
}
