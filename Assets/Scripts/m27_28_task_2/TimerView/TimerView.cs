using UnityEngine;

namespace m27_28_task_2
{
    public abstract class TimerView: MonoBehaviour
    {
        private TimerModel _timer;
        protected TimerModel Timer => _timer;

        private void Start()
        {
            FillTimerText();
        }

        public void Initialize(TimerModel timer)
        {
            _timer = timer;

            _timer.Ticked += OnTicked;
            _timer.Reset += OnReset;
        }

        private void OnDestroy()
        {
            _timer.Ticked -= OnTicked;
            _timer.Reset -= OnReset;
        }

        private void OnTicked()
        {
            ViewRender();
        }

        private void OnReset()
        {
            ViewReset();
        }

        protected abstract void FillTimerText();
        protected abstract void ViewRender();
        protected abstract void ViewReset();
    }
}