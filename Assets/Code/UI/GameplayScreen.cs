using Code.Components;
using Code.MonoBehavioursComponent;
using Code.StatesSwitcher.Events;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class GameplayScreen:UIEntity
    {
        [SerializeField] private Button _reset;
        [SerializeField] private Button _fire;
        private EcsEntity _attack;
        public override void Initial(EcsWorld world)
        {
            base.Initial(world);
            SubscribeButton();
            InitialChild(world);
        }

        private void InitialChild(EcsWorld world)
        {
            _world.NewEntity().Get<FireButtonRef>().Value = _fire;
        }

        private void SubscribeButton()
        {
            _reset.onClick.AddListener(ResetGame);
            _fire.onClick.AddListener(ChangeMode);
        }
        private void ResetGame()
        {
            _reset.onClick.RemoveAllListeners();
            _world.NewEntity().Get<ResetGame>();
        }

        private void ChangeMode()
        {
            if (_attack.IsNull()||!_attack.IsAlive())
            {
                _attack = _world.NewEntity();
                _attack.Get<Attack>();
            }
            else
                _attack.Destroy();
        }
    }
}