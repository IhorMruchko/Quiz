using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Quiz.Standart.Services;
using Quiz.Standart;
using Quiz.Visual.Controllers.Pages;
using Quiz.Standart.Objects;

namespace Quiz.Visual;

public partial class QuizWindow
{
    public QuizWindow()
    {
        InitializeComponent();
        Quiz = this;
        OpenedPages = new PagesController(this);
        RootElement = IoService.Read<QuizComponent>(Constants.File.DataFilePath) as Topic ?? new Topic();
        RootElement.Title = "All your topics";
        OpenedPages.NextPage(new TopicDisplay(RootElement));
        TreeViewDisplayer.ItemsSource = new ObservableCollection<QuizComponent>() { RootElement };
        TreeViewDisplayer.SourceUpdated += TreeViewDisplayer_SourceUpdated;
    }

    private void TreeViewDisplayer_SourceUpdated(object? sender, System.Windows.Data.DataTransferEventArgs e)
    {
        MessageBox.Show(sender?.ToString());
    }

    public PagesController OpenedPages { get; set; }

    public static QuizWindow? Quiz { get; set; }

    public Topic RootElement { get; set; }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        IoService.Write(Constants.File.DataFilePath, RootElement);
    }

    private void BackButton_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        OpenedPages.PreviousPage();
    }

    private void SaveButton_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        IoService.Write(Constants.File.DataFilePath, RootElement);
    }

    private void HoverableButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var heightAnimation = new DoubleAnimation()
        {
            From = AddButtonGrid.Height,
            To = Math.Abs(AddButtonGrid.Height - 150),
            Duration = TimeSpan.FromSeconds(0.5)
        };

        AddButtonGrid.BeginAnimation(HeightProperty, heightAnimation);
    }

    private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
    {
        
        if (sender is TreeViewItem tvi && 
            tvi.IsSelected == true && 
            tvi.DataContext is Topic t && 
            t is not null)
        {
            NextPage(new TopicDisplay(t), false);
        }
    }

    public static void NextPage(UserControl questionDisplay, bool getDeeper = true)
    {
        if (getDeeper == false)
        {
            Quiz?.OpenedPages.PreviousPage();
        }

        Quiz?.OpenedPages.NextPage(questionDisplay);
    }
}
