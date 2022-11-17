using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace BaseCode.Infrastructure
{
    public class LoadLevelState : ILoadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);
        
        public void Exit()
        {
        }

        private void OnLoaded()
        {
            Instantiate("Prefabs/HUD");
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}