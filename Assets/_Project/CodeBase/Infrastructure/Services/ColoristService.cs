using System;
using CodeBase.Infrastructure.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class ColoristService
    {
        private readonly GameStateMachine _stateMachine;

        public ColoristService(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            _stateMachine.StateChanged += OnGameStateChanged;
            
            Debug.Log($"{nameof(ColoristService)} created");
        }

        private void OnGameStateChanged(GameStateType state)
        {
            switch (state)
            {
                case GameStateType.Bootstrap:
                    Clear();
                    break;
                case GameStateType.GameLoop:
                    ListenGameServices();
                    break;
                case GameStateType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void ListenGameServices()
        {
            
        }

        private void Clear()
        {
            
        }
    }
}