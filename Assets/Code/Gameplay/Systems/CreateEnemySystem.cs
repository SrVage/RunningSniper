using Code.Abstractions;
using Code.Components;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public sealed class CreateEnemySystem:IEcsRunSystem
    {
        private readonly EcsFilter<SpawnPoint, EnemyTag> _spawn = null;
        private readonly EcsFilter<GameObjectRef, EnemyTag> _enemy = null;
        private readonly EnemyCfg _enemyCfg;
        private readonly EcsWorld _world = null;
        public void Run()
        {
            if (_spawn.IsEmpty() || !_enemy.IsEmpty())
                return;
            foreach (var sdx in _spawn)
            {
                ref var position = ref _spawn.Get1(sdx).Value;
                CreateEnemy(position);
                break;
            }
        }

        private void CreateEnemy(Vector3 position)
        {
            GameObject enemy = GameObject.Instantiate(_enemyCfg.Prefab, position, Quaternion.identity);
            EcsEntity entity = _world.NewEntity();
            enemy.GetComponent<MonoBehavioursEntity>().Initial(entity, _world);
        }
    }
}