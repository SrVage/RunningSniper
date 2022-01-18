using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    public class PlayerAnimationMoveSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Navigation, AnimatorComponent, PlayerTag> _player = null;
        private readonly int RunAnimation = Animator.StringToHash("Run");
        public void Run()
        {
            foreach (var pdx in _player)
            {
                ref var animator = ref _player.Get2(pdx).Value;
                ref var navigation = ref _player.Get1(pdx).Value;
                if (navigation.remainingDistance>0.1f)
                {
                    if (!animator.GetBool(RunAnimation))
                    {
                        animator.SetBool(RunAnimation, true);
                    }
                }
                else
                {
                    if (animator.GetBool(RunAnimation))
                    {
                        animator.SetBool(RunAnimation, false);
                    }
                }
            }
        }
    }
}