using System.Windows.Input;

namespace Quiz.Visual.Controllers.Pages;

public interface IWindowPage
{
    public void OnKeyDown(object sender, KeyEventArgs args);

    public void InitWindow(QuizWindow window);

    public void CloseWindow(QuizWindow window);
}
