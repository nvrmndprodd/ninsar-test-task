﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        public event Action<GameStateType> StateChanged;
        
        private readonly Dictionary<Type, IState> _states;
        
        private IState _currentState;
        
        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                { typeof(BootstrapState), new BootstrapState(this, sceneLoader) },
                { typeof(GameLoopState), new GameLoopState(this) },
            };
            
            Debug.Log($"{nameof(GameStateMachine)} created");
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
            
            StateChanged?.Invoke(StateConverter.ToEnum(_currentState));
        }
    }
}