using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using Camera = UnityEngine.Camera;
using Physics = UnityEngine.Physics;
using PlayState = Code.StatesSwitcher.States.PlayState;

namespace Code.Gameplay.Systems
{
    public sealed class InputSystem:IEcsRunSystem
    {
        private readonly Camera _camera;
        private readonly EcsFilter<PlayState> _playState = null;
        private readonly EcsFilter<Attack> _attack = null;
        private readonly EcsWorld _world = null;

        public InputSystem(Camera camera)
        {
            _camera = camera;
        }
        public void Run()
        {
            if (_playState.IsEmpty())
                return;
            if (Input.GetMouseButton(0))
            {
                if (!_attack.IsEmpty())
                {
                    _world.NewEntity().Get<InputVectorScreen>().Value = Input.mousePosition;
                    return;
                }
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 50f))
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                        return;
                    if (hit.collider)
                    {
                        _world.NewEntity().Get<InputVector>().Value = hit.point;
                    }
                }
            }
        }
    }
}