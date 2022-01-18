using System;
using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehavioursComponent
{
    public class TriggerListener:MonoBehaviour
    {
        private EcsWorld _world;
        private EcsEntity _entity;

        public void Initial(EcsWorld world)
        {
            _world = world;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<EntityRef>())
            {
                _entity = _world.NewEntity();
                _entity.Get<PositionForAttack>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_entity.IsNull())
                _entity.Destroy();
        }
    }
}