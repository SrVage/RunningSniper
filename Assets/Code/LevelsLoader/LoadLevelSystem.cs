using Code.Abstractions;
using Code.Configs;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code.LevelsLoader
{
    public sealed class LoadLevelSystem:IEcsRunSystem, IEcsInitSystem
    {
        private readonly LevelList _levels;
        private readonly EcsFilter<LoadLevelSignal> _signal;
        private ChangeLevelService _changeLevelService;
        private AsyncOperationHandle<GameObject> _level;
        private readonly EcsWorld _world=null;

        public void Init()
        {
            _changeLevelService = new ChangeLevelService();
        }

        public async void Run()
        {
            if (_signal.IsEmpty()) return;
            if (_level.IsValid())
            {
                Addressables.ReleaseInstance(_level);
                _changeLevelService.ChangeLevel();
            }
            _level = Addressables.InstantiateAsync(_levels.Levels[_changeLevelService.CurrentLevel%_levels.Levels.Count]);
            await _level.Task;
            InitializeLevelObject(_level.Result);
        }
        
        private void InitializeLevelObject(GameObject level)
        {
            var levelObjects = level.GetComponentsInChildren<MonoBehavioursEntity>();
            foreach (var levelObject in levelObjects)
            {
                levelObject.Initial(_world.NewEntity(), _world);
            }
        }
    }
}