using System;
using System.Collections;
using UnityEngine;

namespace m27_28_task_2
{
    public class TimerModel
    {
        public event Action Ticked;
        public event Action Reset;

        private bool _isRunning;
        private float _remainingTime;
        private float _fullTime;

        private Coroutine _runCoroutine;
        private MonoBehaviour _runner;

        public TimerModel(float fullTime, MonoBehaviour runner)
        {
            _fullTime = fullTime;
            _remainingTime = fullTime;
            _runner = runner;
        }

        public bool IsRunning => _isRunning;
        public float RemainingTime => _remainingTime;
        public float FullTime => _fullTime;

        public void Tick(float deltaTime)
        {
            if (_isRunning == false) return;

            _remainingTime = _remainingTime - deltaTime;

            if (_remainingTime <= 0)
            {
                _remainingTime = 0;
                Stop();
            }

            Ticked?.Invoke();
        }

        public void Start()
        {
            _isRunning = true;
            _runCoroutine = _runner.StartCoroutine(Run());
        }

        public void Stop()
        {
            _isRunning = false;
            _runner.StopCoroutine(_runCoroutine);
        }

        public void Restart()
        {
            _isRunning = false;
            _runner.StopCoroutine(_runCoroutine);
            _remainingTime = _fullTime;
            Reset?.Invoke();
        }

        public IEnumerator Run()
        {
            while (true)
            {
                Tick(Time.deltaTime);
                yield return null;
            }
        }
    }
}