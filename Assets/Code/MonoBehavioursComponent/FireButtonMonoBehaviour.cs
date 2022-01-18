using Code.Components;
using Leopotam.Ecs;
using UnityEngine.UI;

namespace Code.MonoBehavioursComponent
{
    public class FireButtonMonoBehaviour:UIEntity
    {
        public override void Initial(EcsWorld world)
        {
            Destroy(this);
            ref var button = ref _world.NewEntity().Get<FireButtonRef>().Value;
            button = GetComponent<Button>();
        }
    }
}