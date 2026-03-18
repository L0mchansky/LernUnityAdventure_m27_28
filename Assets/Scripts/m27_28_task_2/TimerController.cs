using UnityEngine;

namespace m27_28_task_2
{
    public class TimerController: MonoBehaviour
    {
        private TimerModel _timer;
        public void Initialize(TimerModel timer)
        {
            _timer = timer;
        }

        public void StartTimer() => _timer.Start();
        public void StopTimer() => _timer.Stop();
        public void ResetTimer() => _timer.Reset();
    }
}