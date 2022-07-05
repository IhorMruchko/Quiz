using Quiz.Standart.Objects;

namespace Quiz.Visual.Controllers.Pages.QuestionDisplayers;

public interface IQuestionRepresenter
{
    Question? Question { get; set; }
    
    bool IsAnsweredCorrect { get; }
}
