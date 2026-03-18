using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace m27_28_task_2
{
    public class HeartView : TimerView
    {
        [SerializeField] private TMP_Text _timerText;

        private List<Heart> _hearts;

        public void SetHearts(List<Heart> hearts)
        {
            _hearts = hearts;
        }

        protected override void ViewRender()
        {
            if (_hearts == null || _hearts.Count == 0) return;

            float normalized = Timer.RemainingTime / Timer.FullTime;
            int fullHeartsCount = Mathf.CeilToInt(normalized * _hearts.Count);

            fullHeartsCount = Mathf.Clamp(fullHeartsCount, 0, _hearts.Count);

            for (int i = 0; i < _hearts.Count; i++)
            {
                if (i < fullHeartsCount)
                {
                    _hearts[i].SetFullHearth();
                }
                else
                {
                    _hearts[i].SetEmptyHearth();
                }
            }

            FillTimerText();
        }

        protected override void ViewReset()
        {
            if (_hearts == null) return;

            foreach (var heart in _hearts)
            {
                heart.SetFullHearth();
            }

            FillTimerText();
        }

        protected override void FillTimerText()
        {
            _timerText.text = $"{Math.Round(Timer.RemainingTime, 1)} / {Timer.FullTime}";
        }
    }
}
