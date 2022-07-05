using Quiz.Standart.Extensions;
using Quiz.Standart;
using Quiz.Standart.Services;
using Quiz.Visual.Controllers.Controls;
using Quiz.Visual.Controllers.Pages.QuestionDisplayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Quiz.Standart.Objects;

namespace Quiz.Visual.Controllers.Pages;

public partial class QuestionDisplay : UserControl, IWindowPage
{
    private readonly List<UIElement> _renderElements;

    private HoverableButton underHover;

    public IQuestionRepresenter? Current
    {
        set
        {
            QuestionDisplayer.Content = value;
            QuestionTitle.Content = value?.Question?.Title;
            CurrentQuestion.CurrentProgressState = QuestionChanger.CurrentPosition + 1;
        }
    }
    public QuestionDisplay(IEnumerable<Question> components, TimeSpan durration, int questionAmount = int.MaxValue)
    {
        InitializeComponent();
        _renderElements = new ()
        {
            new HoverableButton()
            {
                IconSource = WPFConstants.Images.PreviousIcon,
                BackColorHover = WPFConstants.Colors.LightGreen,
                Click = PreviouseQuestionButton,
            },
            new HoverableButton()
            {
                IconSource = WPFConstants.Images.NextIcon,
                BackColorHover = WPFConstants.Colors.LightGreen,
                Click = NextQuestion,
            }
        };
        Timer = new Timer()
        {
            Duration = durration,
            OnEnd = TimeIsOut,
            OnTick = TimeUpdated
        };

        underHover = new HoverableButton()
        {
            IconSource = WPFConstants.Images.FinishIcon,
            Click = TimeIsOut,
            BackColorHover = WPFConstants.Colors.LightGreen,
        };
        Grid.SetColumn(underHover, 2);

        QuestionChanger = new ListMover<IQuestionRepresenter?>(components.Shuffle()
                                                                         .Take(questionAmount)
                                                                         .Select(x => QuestionRepresentBuilder.Craete(x)));
        TimeRemaining.FinalProgressState = durration;
        TimeRemaining.CurrentProgressState = Timer.CurrentTime;
        Current = QuestionChanger.Current;
        CurrentQuestion.FinalProgressState = QuestionChanger.TotalAmount;
        Timer.Start();
    }

    private void TimeIsOut(object? sender, EventArgs args)
    {
        Timer.Stop();
        Dispatcher.Invoke(() =>
        {
            QuestionDisplayer.Content = $"{QuestionChanger.Elements.Count(x => x?.IsAnsweredCorrect ?? false)} / {QuestionChanger.TotalAmount}";
            QuestionTitle.Content = "Time is out";
            _renderElements.ForEach(x => x.Visibility = Visibility.Collapsed);
        });
    }

    private void TimeUpdated(object? sender, EventArgs args)
    {
        TimeRemaining.CurrentProgressState = Timer.CurrentTime;
    }

    public ListMover<IQuestionRepresenter?> QuestionChanger { get; set; }

    public Timer Timer { get; set; }

    private void PreviouseQuestionButton(object sender, MouseButtonEventArgs e)
    {
        Current = QuestionChanger.Previous;
    }

    private void NextQuestion(object sender, MouseButtonEventArgs e)
    {
        Current = QuestionChanger.Next;
    }

    public void CloseWindow(QuizWindow window)
    {
        Timer.Stop();
        window.AddButtonGrid.Visibility = Visibility.Visible;
        window.ButtonContainer.Children.Cast<UIElement>().ToList().ForEach(x => x.Visibility = Visibility.Visible);
        window.SaveButton.Visibility = Visibility.Visible;
        window.ControlsButtonGrid.Children.Remove(underHover);
        _renderElements.ForEach(x => window.ButtonContainer.Children.Remove(x));
    }

    public void InitWindow(QuizWindow window)
    {
        window.AddButtonGrid.Visibility = Visibility.Collapsed;
        window.ButtonContainer.Children.Cast<UIElement>().ToList().ForEach(x => x.Visibility = Visibility.Collapsed);
        window.SaveButton.Visibility = Visibility.Collapsed;
        window.ControlsButtonGrid.Children.Add(underHover);
        _renderElements.ForEach(x => window.ButtonContainer.Children.Add(x));
    }

    public void OnKeyDown(object sender, KeyEventArgs args)
    {
    }
}
