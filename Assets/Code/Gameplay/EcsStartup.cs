using Code.Components;
using Code.Configs;
using Code.Gameplay.Systems;
using Code.LevelsLoader;
using Code.MonoBehavioursComponent;
using Code.StatesSwitcher;
using Code.StatesSwitcher.Events;
using Code.StatesSwitcher.States;
using Code.UI.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace Code.Gameplay {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        [SerializeField] private LevelList _levels;
        [SerializeField] private UIScreen _uiScreen;
        [SerializeField] private PlayerCfg _playerCfg;
        [SerializeField] private EnemyCfg _enemyCfg;
        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            ChangeGameState.World = _world;
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new GameInitialSystem())
                .Add (new ChangeStateSystem ())
                .Add(new StateMachine())
                .Add(new LoadLevelSystem())
                .Add(new ChangeScreenSystem())
                .Add(new CreatePlayerSystem())
                .Add(new CreateEnemySystem())
                .Add(new BindCameraSystem())
                .Add(new InputSystem(Camera.main))
                .Add(new PlayerMoveSystem())
                .Add(new PlayerAnimationMoveSystem())
                .Add(new ChangeCameraSystem())
                .Add(new ChangeFireButtonVisibleSystem())
                .Add(new RotateAttackSystem())
                .Add(new AttackSystem(Camera.main))
                .Add(new EnableRagdollSystem())

                // .Add (new TestSystem2 ())
                
                // register one-frame components (order is important), for example:
                .OneFrame<ChangeState> ()
                .OneFrame<LoadLevelSignal> ()
                .OneFrame<TapToStart>()
                .OneFrame<InputVector>()
                .OneFrame<InputVectorScreen>()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (_levels)
                .Inject(_uiScreen)
                .Inject(_playerCfg)
                .Inject(_enemyCfg)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }
        
        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}