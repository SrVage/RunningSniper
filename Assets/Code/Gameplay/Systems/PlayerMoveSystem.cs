using Code.Components;
using Leopotam.Ecs;

namespace Code.Gameplay.Systems
{
    public sealed class PlayerMoveSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Navigation, PlayerTag> _player = null;
        private readonly EcsFilter<InputVector> _input = null;

        public void Run()
        {
            if (_input.IsEmpty() || _player.IsEmpty())
                return;
            foreach (var idx in _input)
            {
                ref var point = ref _input.Get1(idx).Value;
                foreach (var pdx in _player)
                {
                    ref var navigation = ref _player.Get1(pdx).Value;
                    navigation.destination = point;
                }
            }
        }
    }
}