using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Code.MonoBehavioursComponent
{
    public sealed class PlayerMonoBehaviour:MonoBehavioursEntity
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<PlayerTag>();
            entity.Get<AnimatorComponent>().Value = _animator;
            entity.Get<Navigation>().Value = _agent;
        }
    }
}