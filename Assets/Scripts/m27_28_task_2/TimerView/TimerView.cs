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

            _timer.TimerTick += OnTimerTick;
            _timer.TimerReset += OnTimerReset;
        }

        private void OnDestroy()
        {
            _timer.TimerTick -= OnTimerTick;
        }

        private void OnTimerTick()
        {
            ViewRender();
        }

        private void OnTimerReset()
        {
            ViewReset();
        }

        protected abstract void FillTimerText();
        protected abstract void ViewRender();
        protected abstract void ViewReset();
    }
}