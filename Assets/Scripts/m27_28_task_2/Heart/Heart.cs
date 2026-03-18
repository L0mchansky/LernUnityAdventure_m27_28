using UnityEngine;
using UnityEngine.UI;

namespace m27_28_task_2
{
    public class Heart: MonoBehaviour
    {
        [SerializeField] Image _emptyHearth;

        private bool _isFull;

        private const int ValueFullTransparency = 0;
        private const int ValueDontTransparency = 255;

        public bool IsFull => _isFull;

        public void SetEmptyHearth()
        {
            _emptyHearth.color = new Color(_emptyHearth.color.r, _emptyHearth.color.g, _emptyHearth.color.b, ValueDontTransparency);
            _isFull = false;
        }

        public void SetFullHearth()
        {
            _emptyHearth.color = new Color(_emptyHearth.color.r, _emptyHearth.color.g, _emptyHearth.color.b, ValueFullTransparency);
            _isFull = true;
        }
    }
}
