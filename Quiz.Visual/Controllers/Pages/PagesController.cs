using System.Collections.Generic;
using System.Windows.Controls;

namespace Quiz.Visual.Controllers.Pages;

public class PagesController
{
    private readonly Stack<UserControl> _pages = new ();

    private readonly QuizWindow _windowContext;

    public PagesController(QuizWindow window)
    {
        _windowContext = window;
    }

    public bool IsEmpty => _pages.Count == 1;

    public void NextPage(UserControl nextPage)
    {
        if (_pages.Count > 0)
        {
            (_pages.Peek() as IWindowPage)?.CloseWindow(_windowContext);;
        }

        _pages.Push(nextPage);
        (nextPage as IWindowPage)?.InitWindow(_windowContext);
        _windowContext.WindowContent.Content = nextPage;
    }

    public void PreviousPage()
    {
        if (_pages.Count == 1)
        {
            return;
        }

        (_pages.Pop()as IWindowPage)?.CloseWindow(_windowContext);

        var newCurrentPage = _pages.Peek() as IWindowPage;
        newCurrentPage?.InitWindow(_windowContext);
        _windowContext.WindowContent.Content = newCurrentPage;
    }

}
