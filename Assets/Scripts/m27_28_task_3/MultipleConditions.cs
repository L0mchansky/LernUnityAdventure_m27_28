using System;
using System.Collections.Generic;
using UnityEngine;

namespace m27_28_task_3
{
    public class MultipleConditions : MonoBehaviour
    {
        [SerializeField] private bool _useIsDeadCondition;
        [SerializeField] private bool _useLifetimeCondition;
        [SerializeField] private float _lifetime = 5f;

        [SerializeField] private bool _useMaxCountCondition;
        [SerializeField] private int _maxCount = 3;

        public void Build(EntityEntry entityEntry, float entityCount)
        {
            List<Func<bool>> conditions = new List<Func<bool>>();
            Entity entity = entityEntry.GetEntity;

            if (_useIsDeadCondition)
            {
                conditions.Add(() => entity.IsDead);
            }

            if (_useLifetimeCondition)
            {
                float spawnTime = Time.time;
                conditions.Add(() => Time.time - spawnTime > _lifetime);
            }

            if (_useMaxCountCondition)
            {
                conditions.Add(() => entityCount > _maxCount);
            }

            entityEntry.AddDestroyCondition(conditions);
        }
    }
}