using System;
using Cinemachine;
using Code.Abstractions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using Camera = Code.Components.Camera;

namespace Code.MonoBehavioursComponent
{
    public sealed class CameraMonoBehaviour:MonoBehavioursEntity
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachine;
        [SerializeField] private CameraPosition _cameraPosition;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            entity.Get<Camera>().Value = _cinemachine;
            switch (_cameraPosition)
            {
                case CameraPosition.Top:
                    entity.Get<TopTag>();
                    break;
                case CameraPosition.First:
                    entity.Get<FirstTag>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Destroy(this);
        }
    }

    public enum CameraPosition
    {
        Top=0,
        First = 1
    }
}