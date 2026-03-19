using UnityEngine;

namespace m27_28_task_3
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private bool _isDead;
        private float _spawnTime;

        public void Initialize()
        {
            _spawnTime = Time.time;
        }

        public bool IsDead => _isDead;

        public void SetIsDead(bool value)
        {
            _isDead = value;
        }

        public float GetSpawnTime => _spawnTime;

        public void Die()
        {
            Destroy(gameObject);
            Debug.Log($"Entity уничтожен {Time.time}");
        }
    }
}