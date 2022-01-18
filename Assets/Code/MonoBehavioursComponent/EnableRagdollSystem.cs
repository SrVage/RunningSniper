using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using Physics = Code.Components.Physics;

namespace Code.MonoBehavioursComponent
{
    public sealed class EnableRagdollSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Physics, AnimatorComponent, EnemyTag, Damage> _enemy=null;
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
                entity.Del<Damage>();
            }
        }
    }
}