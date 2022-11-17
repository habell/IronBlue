using BaseCode.Services.Input;

namespace BaseCode.Infrastructure
{
    internal class Game
    {
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}