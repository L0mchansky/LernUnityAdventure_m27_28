using System;
using System.Collections.Generic;
using UnityEngine;

namespace m27_28_task_3
{
    public class EntityCreateController : MonoBehaviour
    {
        [SerializeField] private Entity _entityPrefab;
        [SerializeField] private MultipleConditions _multipleConditions;

        private EntityDestructionService _destructionService;

        private void Awake()
        {
            _destructionService = new EntityDestructionService();
        }

        private void Update()
        {
            _destructionService.Update();
        }

        public void CreateEntityWithIsDeadCondition()
        {
            EntityEntry entityEntry = CreateEntityEntry();
            entityEntry.AddDestroyCondition(() => entityEntry.GetEntity.IsDead);
        }

        public void CreateEntityWithLifetimeCondition(float lifetime = 5f)
        {
            EntityEntry entityEntry = CreateEntityEntry();

            float spawnTime = Time.time;

            entityEntry.AddDestroyCondition(() => Time.time - spawnTime > lifetime);
        }

        public void CreateEntityWithMaxCountCondition(int maxEntities = 3)
        {
            EntityEntry entityEntry = CreateEntityEntry();

            float entityCount = _destructionService.GetCount();

            entityEntry.AddDestroyCondition(() => entityCount > maxEntities);
        }

        public void CreateEntityWithMultipleConditions()
        {
            EntityEntry entityEntry = CreateEntityEntry();

            float entityCount = _destructionService.GetCount();

            _multipleConditions.Build(entityEntry, entityCount);
        }

        private Entity CreateEntity()
        {
            float randomX = UnityEngine.Random.Range(-15, 15);
            float randomZ = UnityEngine.Random.Range(-15, 15);

            Vector3 position = new Vector3(randomX, 0, randomZ);
            Entity entity = Instantiate(_entityPrefab, position, Quaternion.identity);

            return entity;
        }

        private EntityEntry CreateEntityEntry()
        {
            Entity entity = CreateEntity();
            EntityEntry entityEntry = _destructionService.RegisterEntity(entity);
            return entityEntry;
        }
    }
}