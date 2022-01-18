using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using Camera = UnityEngine.Camera;
using Physics = UnityEngine.Physics;

namespace Code.Gameplay.Systems
{
    public sealed class AttackSystem:IEcsRunSystem
    {
        private readonly EcsFilter<InputVectorScreen> _inputVector = null;
        private readonly Camera _camera;
        private readonly EcsWorld _world = null;

        public AttackSystem(Camera camera)
        {
            _camera = camera;
        }
        
        public void Run()
        {
            if (_inputVector.IsEmpty())
                return;
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                if (hit.collider.GetComponentInParent<EntityRef>())
                {
                    var entity = hit.collider.GetComponentInParent<EntityRef>().Entity;
                    if (entity.Has<EnemyTag>())
                        entity.Get<Damage>();
                }
            }
        }
    }
}