using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public sealed class RotateAttackSystem:IEcsRunSystem
    {
        private const float Angle = 5f;
        private readonly EcsFilter<InputVectorScreen> _input = null;
        private readonly EcsFilter<Attack> _attack = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        private readonly float _screenWidth;

        public RotateAttackSystem()
        {
            _screenWidth = Screen.width;
        }
        public void Run()
        {
            if (_attack.IsEmpty())
                return;
            foreach (var idx in _input)
            {
                ref var vector = ref _input.Get1(idx);
                foreach (var pdx in _player)
                {
                    ref var playerTransform = ref _player.Get1(pdx).Transform;
                    if (vector.Value.x > (_screenWidth / 2)+(_screenWidth / 6))
                    {
                        var x = (vector.Value.x - (_screenWidth / 2))* Angle/(_screenWidth / 2);
                        playerTransform.Rotate(0, x, 0);
                    }                    
                    if (vector.Value.x < (_screenWidth / 2)-(_screenWidth / 6))
                    {
                        var x = ((_screenWidth / 2)-vector.Value.x) * Angle/(_screenWidth / 2);
                        playerTransform.Rotate(0, -x, 0);
                    }
                }

            }
        }
    }
}