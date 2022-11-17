using UnityEngine;

namespace BaseCode.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            if(_game != null) return;
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
