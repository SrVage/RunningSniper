using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace Code.Gameplay.Systems
{
    public sealed class InputSystem:IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        public void Run()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 50f);
                if (hit.collider)
                {
                    _world.NewEntity().Get<InputVector>().Value = hit.point;
                }
            }
        }
    }
}