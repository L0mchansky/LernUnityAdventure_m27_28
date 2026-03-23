using System.Collections.Generic;

namespace m27_28_task_3
{
    public class EntityDestructionService
    {
        private List<EntityEntry> _entries = new List<EntityEntry>();

        public int GetEntriesCount => _entries.Count;

        public EntityEntry RegisterEntity(Entity entity)
        {
            EntityEntry entityEntry = new(entity);
            _entries.Add(entityEntry);

            return entityEntry;
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
        }
    }
}