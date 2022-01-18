using Code.StatesSwitcher;
using Code.StatesSwitcher.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems

{
    public sealed class ChangeStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TapToStart> _startLevelSignal;
        private readonly EcsWorld _world;

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                ChangeGameState.Change(GameStates.LoseState);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeGameState.Change(GameStates.WinState);
            }
            if (!_startLevelSignal.IsEmpty())
                ChangeGameState.Change(GameStates.PlayState);
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeGameState.Change(GameStates.StartState);
            }
            
        }
    }
}