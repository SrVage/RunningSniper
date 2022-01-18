using Code.Abstractions;
using Code.Components;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public sealed class CreatePlayerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<SpawnPoint, PlayerTag> _spawn = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        private readonly PlayerCfg _playerCfg;
        private readonly EcsWorld _world = null;
        public void Run()
        {
            if (_spawn.IsEmpty() || !_player.IsEmpty())
                return;
            foreach (var sdx in _spawn)
            {
                ref var position = ref _spawn.Get1(sdx).Value;
                CreatePlayer(position);
            }
        }

        private void CreatePlayer(Vector3 position)
        {
            GameObject player = GameObject.Instantiate(_playerCfg.Prefab, position, Quaternion.identity);
            EcsEntity playerEntity = _world.NewEntity();
            player.GetComponent<MonoBehavioursEntity>().Initial(playerEntity, _world);
            var childs = player.GetComponentsInChildren<MonoBehavioursEntity>();
            foreach (var child in childs)
            {
                child.Initial(_world.NewEntity(), _world);
            }
            playerEntity.Get<BindCameraTag>();
        }
    }
}