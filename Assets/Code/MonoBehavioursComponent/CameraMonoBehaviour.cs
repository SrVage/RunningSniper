using Cinemachine;
using Code.Abstractions;
using Leopotam.Ecs;
using UnityEngine;
using Camera = Code.Components.Camera;

namespace Code.MonoBehavioursComponent
{
    public sealed class CameraMonoBehaviour:MonoBehavioursEntity
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachine;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            entity.Get<Camera>().Value = _cinemachine;
            Destroy(this);
        }
    }
}