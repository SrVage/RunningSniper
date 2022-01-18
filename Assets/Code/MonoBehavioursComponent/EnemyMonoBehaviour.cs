using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using Physics = Code.Components.Physics;

namespace Code.MonoBehavioursComponent
{
    public class EnemyMonoBehaviour:MonoBehavioursEntity
    {
        [SerializeField] private Animator _animator;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<EnemyTag>();
            entity.Get<AnimatorComponent>().Value = _animator;
            var rigidBodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rigidbody in rigidBodies)
            {
                rigidbody.isKinematic = true;
            }
            entity.Get<Physics>().Value = rigidBodies;
        }
    }
}