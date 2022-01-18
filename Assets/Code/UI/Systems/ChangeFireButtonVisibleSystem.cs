using Code.Components;
using Leopotam.Ecs;

namespace Code.UI.Systems
{
    public sealed class ChangeFireButtonVisibleSystem:IEcsRunSystem
    {
        private readonly EcsFilter<FireButtonRef> _button = null;
        private readonly EcsFilter<PositionForAttack> _attack = null;
        public void Run()
        {
            if (_attack.IsEmpty())
            {
                foreach (var bdx in _button)
                {
                    ref var button = ref _button.Get1(bdx).Value;
                    button.interactable = false;
                }
            }
            else
            {
                foreach (var bdx in _button)
                {
                    ref var button = ref _button.Get1(bdx).Value;
                    button.interactable = true;
                } 
            }
        }
    }
}