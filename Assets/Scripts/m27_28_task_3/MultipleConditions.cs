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

        public List<Func<bool>> Build(Entity entity, EntityDestructionService service)
        {
            List<Func<bool>> conditions = new List<Func<bool>>();

            if (_useIsDeadCondition)
            {
                conditions.Add(() => entity.IsDead);
            }

            if (_useLifetimeCondition)
            {
                conditions.Add(() => Time.time - entity.GetSpawnTime > _lifetime);
            }

            if (_useMaxCountCondition)
            {
                conditions.Add(() => service.GetCount() > _maxCount);
            }

            return conditions;
        }
    }
}