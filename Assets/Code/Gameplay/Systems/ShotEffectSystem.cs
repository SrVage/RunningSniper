using Code.Abstractions;
using Code.Components;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public sealed class ShotEffectSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Shot> _shot = null;
        private readonly EcsFilter<GameObjectRef, FirePointTag> _firePoint = null;
        private readonly BulletCfg _bulletCfg = null;
        public void Run()
        {
            if (_shot.IsEmpty())
                return;
            foreach (var fdx in _firePoint)
            {
                ref var point = ref _firePoint.Get1(fdx).Transform;
                GameObject.Instantiate(_bulletCfg.Explosion, point.position, point.rotation);
            }
        }
    }
}