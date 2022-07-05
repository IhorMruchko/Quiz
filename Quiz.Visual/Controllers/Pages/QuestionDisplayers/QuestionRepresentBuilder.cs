using Quiz.Standart.Objects;
using Quiz.Standart.Objects.Questions;
using System;
using System.Collections.Generic;

namespace Quiz.Visual.Controllers.Pages.QuestionDisplayers;

public static class QuestionRepresentBuilder
{
    private static readonly Dictionary<Type, Func<Question, IQuestionRepresenter>> _builder = new()
    {
        [typeof(SelectOneQuestion)] = q => new SelectOneQuestionDisplay() { Question = q},
        [typeof(SelectManyQuestion)] = q => new SelectManyQuestionDisplay() { Question = q},
    };

    public static IQuestionRepresenter? Craete(Question question)
    {
        return _builder.ContainsKey(question.GetType())
            ? _builder[question.GetType()].Invoke(question)
            : null;
    }
}
