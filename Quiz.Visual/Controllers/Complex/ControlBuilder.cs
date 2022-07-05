using Quiz.Standart.Objects;
using Quiz.Visual.Controllers.Pages;
using System.Windows;

namespace Quiz.Visual.Controllers.Complex;

public static class ControlBuilder
{
    public static UIElement? Craete(TopicDisplay d, QuizComponent c)
    {
        if (c is Topic t)
        {
            return new TopicControl(d, t);
        }

        if (c is Question q)
        {
            return new QuestionControl(d, q);
        }

        return null;
    }
}
