using System;
using System.Collections.Generic;

namespace m27_28_task_3
{
    public class EntityEntry
    {
        private Entity _entity;
        private List<Func<bool>> _destroyConditions;

        public EntityEntry(Entity entity)
        {
            _entity = entity;
            _destroyConditions = new List<Func<bool>>();
        }

        public Entity GetEntity => _entity;

        public void AddDestroyCondition(List<Func<bool>> conditions)
        {
            _destroyConditions.AddRange(conditions);
        }

        public void AddDestroyCondition(Func<bool> condition)
        {
            _destroyConditions.Add(condition);
        }

        public bool ShouldDestroy()
        {
            foreach (var condition in _destroyConditions)
            {
                if (condition()) return true;
            }
            return false;
        }
    }
}