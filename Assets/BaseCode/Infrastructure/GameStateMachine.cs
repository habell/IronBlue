using System;
using System.Collections.Generic;

namespace BaseCode.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
            };
        }

        public void Enter<TState>() where TState : IState => 
            ChangeState<TState>().Enter();

        public void Enter<TState, TData>(TData data) where TState : ILoadedState<TData> =>
            ChangeState<TState>().Enter(data);

        private TState ChangeState<TState>() where TState : IExitableState
        {
            _currentState?.Exit();
            var state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : IExitableState =>
            (TState)_states[typeof(TState)];
    }
}