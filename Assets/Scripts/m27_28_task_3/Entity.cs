using UnityEngine;

namespace m27_28_task_3
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private bool _isDead;

        public bool IsDead => _isDead;

        public void SetIsDead(bool value)
        {
            _isDead = value;
        }

        public void Die()
        {
            Destroy(gameObject);
            Debug.Log($"Entity уничтожен {Time.time}");
        }
    }
}