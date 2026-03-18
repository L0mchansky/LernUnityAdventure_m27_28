using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace m27_28_task_2
{
    public class SliderView : TimerView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _timerText;

        private const float DefaultNormalizeSlider = 1;
        protected override void ViewRender()
        {
            FillTimerText();
            float normalize = Timer.RemainingTime / Timer.FullTime;
            _slider.value = normalize;
        }

        protected override void ViewReset()
        {
            FillTimerText();
            _slider.value = DefaultNormalizeSlider;
        }

        protected override void FillTimerText()
        {
            _timerText.text = $"{Math.Round(Timer.RemainingTime, 1)} / {Timer.FullTime}";
        }
    }
}
