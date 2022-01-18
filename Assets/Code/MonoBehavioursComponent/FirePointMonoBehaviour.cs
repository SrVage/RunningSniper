using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;

namespace Code.MonoBehavioursComponent
{
    public sealed class FirePointMonoBehaviour:MonoBehavioursEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<FirePointTag>();
        }
    }
}