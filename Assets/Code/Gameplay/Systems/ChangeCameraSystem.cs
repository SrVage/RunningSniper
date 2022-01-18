using Code.Components;
using Leopotam.Ecs;

namespace Code.Gameplay.Systems
{
    public class ChangeCameraSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Attack> _attack = null;
        private readonly EcsFilter<Camera> _camera;
        public void Run()
        {
            if (!_attack.IsEmpty())
            {
                foreach (var cdx in _camera)
                {
                    ref var entity = ref _camera.GetEntity(cdx);
                    ref var camera = ref _camera.Get1(cdx).Value;
                    if (entity.Has<TopTag>())
                    {
                        camera.enabled = false;
                    }
                    if (entity.Has<FirstTag>())
                    {
                        camera.enabled = true;
                    }
                }
            }
            else
            {
                foreach (var cdx in _camera)
                {
                    ref var entity = ref _camera.GetEntity(cdx);
                    ref var camera = ref _camera.Get1(cdx).Value;
                    if (entity.Has<TopTag>())
                    {
                        camera.enabled = true;
                    }

                    if (entity.Has<FirstTag>())
                    {
                        camera.enabled = false;
                    }
                }
            }
        }
    }
}