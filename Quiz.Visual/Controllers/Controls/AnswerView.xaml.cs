using Quiz.Standart;
using Quiz.Visual.Controllers.Dialogs;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Controls;

public partial class AnswerView : UserControl
{
    public AnswerView(ConfigureQuestionDialog context)
    {
        InitializeComponent();
        QuestionConfigurer = context;
    }

    public ConfigureQuestionDialog QuestionConfigurer { get; set; }

    public bool IsSelected { get; set; }
    private void Label_MouseDown(object sender, MouseButtonEventArgs e)
    {
        IsSelected = !IsSelected;
        IsChecked.IconSource = IsSelected
            ? WPFConstants.Images.CheckedIcon
            : WPFConstants.Images.UncheckedIcon;            
    }

    private void HoverableButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        QuestionConfigurer.AnswerContainer.Children.Remove(this);
    }
}
