using System.Collections.Generic;
using System.Linq;

namespace Quiz.Standart.Services
{
    public class ListMover<T>
    {
        private int _currentPosition;
        public ListMover(IEnumerable<T> questions)
        {
            Elements = questions.ToList();
            TotalAmount = Elements.Count;
        }

        public List<T> Elements { get; set; }

        public int TotalAmount { get; }

        public int CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = (value + TotalAmount) % TotalAmount;
        }

        public T Next => Elements[UpdatePosition(1)];

        public T Current => Elements[_currentPosition];

        public T Previous => Elements[UpdatePosition(-1)];

        private int UpdatePosition(int valueChanger)
        {
            CurrentPosition += valueChanger;
            return CurrentPosition;
        }
    }
}