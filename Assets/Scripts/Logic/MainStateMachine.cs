using System;
using System.Collections.Generic;

namespace Logic
{
    public class MainStateMachine : IStateMachine
    {
        private Dictionary<Type, IInitExitableState> _states = new Dictionary<Type, IInitExitableState>();
        private IInitExitableState _activeState;

        public MainStateMachine(List<IInitExitableState> states)
        {
            InitStatesDictionary(states);
        }

        private void InitStatesDictionary(List<IInitExitableState> states)
        {
            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
                state.Init(this);
            }
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
    
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IInitExitableState
        {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IInitExitableState =>
            _states[typeof(TState)] as TState;
    }
}