using QuestionVisualisation.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionVisualisation.Services
{
    public class RandomizerService
    {
        private readonly Random _randomizer = new ();

        public List<Question> LoadedQuesions { get; set; } = new();

        public Question? SelectedQuestion { get; set; }

        public List<Question> AnsweredQuestions { get; set; } = new ();
        public string Result => $"{AnsweredQuestions.Count(x => x.IsCorrectAnswered)}/{AnsweredQuestions.Count}";

        public Question Next()
        {
            if (SelectedQuestion is not null)
            {
                AnsweredQuestions.Add(SelectedQuestion);
                LoadedQuesions.Remove(SelectedQuestion);
            }

            if (LoadedQuesions.Count == 0)
            {
                return SelectedQuestion!;
            }

            SelectedQuestion = LoadedQuesions[_randomizer.Next(LoadedQuesions.Count)];
            return SelectedQuestion;
        }
    }
}
