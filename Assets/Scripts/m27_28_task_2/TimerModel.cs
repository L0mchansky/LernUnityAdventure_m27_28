using System;

namespace m27_28_task_2
{
    public class TimerModel
    {
        public event Action TimerTick;
        public event Action TimerReset;

        private bool _isRunning;
        private float _remainingTime;
        private float _fullTime;

        public TimerModel(float fullTime)
        {
            _fullTime = fullTime;
            _remainingTime = fullTime;
        }

        public bool IsRunning => _isRunning;
        public float RemainingTime => _remainingTime;
        public float FullTime => _fullTime;

        public void Tick(float deltaTime)
        {
            if (_isRunning == false) return;

            _remainingTime = _remainingTime - deltaTime;

            if (_remainingTime < 0)
            {
                _remainingTime = 0;
                Stop();
            }

            TimerTick?.Invoke();
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Reset()
        {
            _isRunning = false;
            _remainingTime = _fullTime;
            TimerReset?.Invoke();
        }
    }
}