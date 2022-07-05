using System;
using T = System.Timers.Timer;

namespace Quiz.Standart.Services
{
    public class Timer
    {
        public delegate void TimerTick(object sender, EventArgs args);

        private readonly T _timer = new T() { Interval = Constants.Time.Second.TotalMilliseconds };

        private TimeSpan _duration;

        public Timer()
        {
            _timer.Elapsed += Timer_Tick;
        }

        public TimerTick OnTick { get; set; }

        public TimerTick OnEnd { get; set; }

        public TimeSpan Duration
        {
            set => _duration = value - Constants.Time.Second;
        }

        public TimeSpan CurrentTime { get; private set; }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CurrentTime >= _duration)
            {
                Stop();
                OnEnd?.Invoke(sender, e);
            }
            CurrentTime = CurrentTime.Add(Constants.Time.Second);
            OnTick?.Invoke(sender, e);
        }

    }
}