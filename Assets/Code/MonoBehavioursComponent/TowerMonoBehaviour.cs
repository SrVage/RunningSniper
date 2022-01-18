using Code.Abstractions;
using Leopotam.Ecs;

namespace Code.MonoBehavioursComponent
{
    public class TowerMonoBehaviour:MonoBehavioursEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            entity.Destroy();
            GetComponentInChildren<TriggerListener>().Initial(world);
            Destroy(this);
        }
    }
}