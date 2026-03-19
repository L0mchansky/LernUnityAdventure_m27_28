using System;
using System.Collections.Generic;

namespace m27_28_task_3
{
    public class EntityEntry
    {
        private Entity _entity;
        private List<Func<bool>> _destroyConditions;

        public EntityEntry(Entity entity, List<Func<bool>> destroyConditions)
        {
            _entity = entity;
            _destroyConditions = destroyConditions;
        }

        public Entity GetEntity => _entity;

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