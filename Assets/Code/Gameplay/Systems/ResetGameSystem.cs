using Code.Abstractions;
using Code.Components;
using Code.Gameplay.Extensions;
using Code.StatesSwitcher;
using Code.StatesSwitcher.Events;
using Leopotam.Ecs;

namespace Code.Gameplay.Systems
{
    public class ResetGameSystem:IEcsRunSystem
    {
        private readonly EcsFilter<ResetGame> _resetGame = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        private readonly EcsFilter<GameObjectRef, EnemyTag> _enemy = null;
        private readonly EcsFilter<Camera, FirstTag> _camera = null;
        private readonly EcsFilter<FirePointTag> _firePoint = null;
        private readonly EcsFilter<FireButtonRef> _fireButton = null;
        private readonly EcsFilter<SpawnPoint> _spawn = null;
        private readonly EcsFilter<PositionForAttack> _attackPoint = null;
        private readonly EcsFilter<Attack> _attack = null;
        public void Run()
        {
            if (_resetGame.IsEmpty())
                return;
            foreach (var idx in _camera)
            {
                ref var entity = ref _camera.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _attackPoint)
            {
                ref var entity = ref _attackPoint.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _attack)
            {
                ref var entity = ref _attack.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _spawn)
            {
                ref var entity = ref _spawn.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _fireButton)
            {
                ref var entity = ref _fireButton.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _firePoint)
            {
                ref var entity = ref _firePoint.GetEntity(idx);
                entity.Destroy();
            }
            foreach (var idx in _player)
            {
                ref var entity = ref _player.GetEntity(idx);
                entity.DestroyWithGameObject();
            }
            foreach (var idx in _enemy)
            {
                ref var entity = ref _enemy.GetEntity(idx);
                entity.DestroyWithGameObject();
            }
            foreach (var idx in _resetGame)
            {
                ref var entity = ref _resetGame.GetEntity(idx);
                entity.Destroy();
            }
            ChangeGameState.Change(GameStates.StartState);
        }
    }
}