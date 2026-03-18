using System.Collections.Generic;
using UnityEngine;

namespace m27_28_task_2
{
    public class Game: MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;

        [SerializeField] private List<Heart> _hearts = new List<Heart>();
        [SerializeField] private HeartView _hearthView;
        [SerializeField] private SliderView _sliderView;

        [SerializeField] private TimerController _hearthController;
        [SerializeField] private TimerController _sliderController;

        [SerializeField] private float _fullTimeToTimer;

        private List<TimerModel> _timerModels = new List<TimerModel>();

        private void Awake()
        {
            if (_canvas != null) _canvas.SetActive(true);
        }

        private void Start()
        {
            CreateTimer(new TimerModel(_fullTimeToTimer), _sliderView, _sliderController);
            CreateTimer(new TimerModel(_fullTimeToTimer), _hearthView, _hearthController);
        }

        private void Update()
        {
            if (_timerModels.Count > 0)
            {
                foreach (var timer in _timerModels)
                {
                    timer.Tick(Time.deltaTime);
                }
            }
        }

        private void CreateTimer(TimerModel model, TimerView view, TimerController controller)
        {
            controller.Initialize(model);
            _timerModels.Add(model);

            if (view != null)
            {
                view.Initialize(model);

                if (view is HeartView heartView)
                {
                    heartView.SetHearts(_hearts);
                }
            }
        }
    }
}