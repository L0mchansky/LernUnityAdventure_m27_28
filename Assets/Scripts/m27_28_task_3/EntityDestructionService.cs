using System;
using System.Collections.Generic;
using UnityEngine;

namespace m27_28_task_3
{
    public class EntityDestructionService
    {
        private List<EntityEntry> _entries = new List<EntityEntry>();

        public void RegisterEntity(Entity entity, List<Func<bool>> destroyConditions)
        {
            _entries.Add(new EntityEntry(entity, destroyConditions));
        }

        public void Update()
        {
            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                if (_entries[i].ShouldDestroy())
                {
                    _entries[i].GetEntity.Die();
                    _entries.RemoveAt(i);
                }
            }

            Debug.Log($"Entities зарегистрированно: {_entries.Count}");
        }

        public int GetCount() => _entries.Count;
    }
}