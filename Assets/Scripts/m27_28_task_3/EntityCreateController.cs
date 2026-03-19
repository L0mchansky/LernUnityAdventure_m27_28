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

        private List<Func<bool>> CreateConditionsList(params Func<bool>[] conditions)
        {
            return new List<Func<bool>>(conditions);
        }

        public void CreateEntityWithIsDeadCondition()
        {
            Entity entity = CreateEntity();
            var conditions = CreateConditionsList(() => entity.IsDead);
            _destructionService.RegisterEntity(entity, conditions);
        }

        public void CreateEntityWithLifetimeCondition(float lifetime = 5f)
        {
            Entity entity = CreateEntity();
            var conditions = CreateConditionsList(() => Time.time - entity.GetSpawnTime > lifetime);
            _destructionService.RegisterEntity(entity, conditions);
        }

        public void CreateEntityWithMaxCountCondition(int maxEntities = 3)
        {
            Entity entity = CreateEntity();
            var conditions = CreateConditionsList(() => _destructionService.GetCount() > maxEntities);
            _destructionService.RegisterEntity(entity, conditions);
        }

        public void CreateEntityWithMultipleConditions()
        {
            Entity entity = CreateEntity();
            var conditions = _multipleConditions.Build(entity, _destructionService);
            _destructionService.RegisterEntity(entity, conditions);
        }

        private Entity CreateEntity()
        {
            float randomX = UnityEngine.Random.Range(-15, 15);
            float randomZ = UnityEngine.Random.Range(-15, 15);

            Vector3 position = new Vector3(randomX, 0, randomZ);
            Entity entity = Instantiate(_entityPrefab, position, Quaternion.identity);
            entity.Initialize();

            return entity;
        }

        private void Update()
        {
            _destructionService.Update();
        }
    }
}