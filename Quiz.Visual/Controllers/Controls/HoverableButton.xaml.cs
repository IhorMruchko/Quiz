using System.Windows.Input;
using System.Windows.Media;
using Quiz.Standart;
using Quiz.Standart.Extensions;

namespace Quiz.Visual.Controllers.Controls;

public partial class HoverableButton
{
    public delegate void MouseButtonEvent(object? sender, MouseButtonEventArgs args);
    
    public HoverableButton()
    {
        InitializeComponent();
    }

    public ImageSource IconSource
    {
        set => ImageContainer.Source = value;
    }

    public MouseButtonEventHandler Click 
    { 
        set => MouseDown += value; 
    }

    public Brush BackColor { get; set; } = WPFConstants.Colors.Transparent;

    public Brush ForeColor { get; set; } = WPFConstants.Colors.Black;

    public Brush ForeColorHover { get; set; } = WPFConstants.Colors.Black;

    public Brush BackColorHover { get; set; } = WPFConstants.Colors.Transparent;


    private void PicturePlaceholder_OnMouseEnter(object sender, MouseEventArgs e)
    {
        PicturePlaceholder.ChangeColors(BackColorHover, ForeColorHover);
    }


    private void PicturePlaceholder_OnMouseLeave(object sender, MouseEventArgs e)
    {
        PicturePlaceholder.ChangeColors(BackColor, ForeColor);
    }
}
