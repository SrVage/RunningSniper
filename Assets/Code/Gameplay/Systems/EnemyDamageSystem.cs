using System;
using Code.Components;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;
using Physics = Code.Components.Physics;

namespace Code.MonoBehavioursComponent
{
    public sealed class EnemyDamageSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Physics, AnimatorComponent, EnemyTag, Damage> _enemy=null;
        private readonly BulletCfg _bulletCfg = null;
        public void Run()
        {
            foreach (var edx in _enemy)
            {
                ref var physics = ref _enemy.Get1(edx).Value;
                ref var animator = ref _enemy.Get2(edx).Value;
                ref var entity = ref _enemy.GetEntity(edx);
                animator.enabled = false;
                foreach (var physic in physics)
                {
                    physic.isKinematic = false;
                }

                ref var direction = ref _enemy.Get4(edx).Direction;
                ref var point = ref _enemy.Get4(edx).Point;
                ref var partOfBody = ref _enemy.Get4(edx).PartOfBody;
                partOfBody.AddForceAtPosition(direction*Strength(), point, ForceMode.Impulse);
                entity.Del<Damage>();
            }
        }

        private float Strength()
        {
            switch (_bulletCfg.AttackStrength)
            {
                case AttackStrength.Low:
                    return _bulletCfg.LowAttack;
                case AttackStrength.Middle:
                    return _bulletCfg.MiddleAttack;
                case AttackStrength.High:
                    return _bulletCfg.HighAttack;
            }
            return 0;
        }
    }
}