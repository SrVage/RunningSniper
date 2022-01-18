using Code.Abstractions;
using Code.Components;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using Camera = UnityEngine.Camera;
using Physics = UnityEngine.Physics;

namespace Code.Gameplay.Systems
{
    public sealed class ShotSystem:IEcsRunSystem
    {
        private readonly EcsFilter<InputVectorScreen> _inputVector = null;
        private readonly EcsFilter<RechargeTime> _rechargeTime = null;
        private readonly Camera _camera;
        private readonly EcsWorld _world = null;
        private readonly BulletCfg _bulletCfg = null;

        public ShotSystem(Camera camera)
        {
            _camera = camera;
        }
        
        public void Run()
        {
            if (_inputVector.IsEmpty()||!_rechargeTime.IsEmpty())
                return;
            _world.NewEntity().Get<RechargeTime>().Value = _bulletCfg.RechargeTime;
            _world.NewEntity().Get<Shot>();
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
                    {
                        entity.Get<Damage>().Point = hit.point;
                        entity.Get<Damage>().PartOfBody = hit.rigidbody;
                        entity.Get<Damage>().Direction = ray.direction;
                    } 
                }
            }
        }
    }
}