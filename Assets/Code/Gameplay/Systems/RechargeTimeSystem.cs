using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public sealed class RechargeTimeSystem:IEcsRunSystem
    {
        private readonly EcsFilter<RechargeTime> _rechargeTime = null;
        public void Run()
        {
            foreach (var rdx in _rechargeTime)
            {
                ref var time = ref _rechargeTime.Get1(rdx).Value;
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    ref var entity = ref _rechargeTime.GetEntity(rdx);
                    entity.Destroy();
                }
            }
        }
    }
}