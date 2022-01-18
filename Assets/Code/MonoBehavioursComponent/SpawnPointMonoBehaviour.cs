using System;
using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehavioursComponent
{
    public sealed class SpawnPointMonoBehaviour:MonoBehavioursEntity
    {
        [SerializeField] private Fraction _fraction;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            //base.Initial(entity, world);
            switch (_fraction)
            {
                case Fraction.Player:
                    entity.Get<PlayerTag>();
                    break;
                case Fraction.Enemy:
                    entity.Get<EnemyTag>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            entity.Get<SpawnPoint>().Value = transform.position;
            Destroy(gameObject);
        }
    }
}