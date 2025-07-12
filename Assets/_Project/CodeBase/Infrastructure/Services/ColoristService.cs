using System;
using CodeBase.Features.ColoristFeature;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Input;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class ColoristService
    {
        private readonly GameStateMachine _stateMachine;
        private readonly InputService _inputService;
        
        private readonly ColoristModel _model;
        private readonly Colorist _colorist;

        public ColoristService(GameStateMachine stateMachine, StaticDataService staticDataService, InputService inputService)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;

            _model = new ColoristModel(staticDataService);
            _colorist = new Colorist(_model);

            _stateMachine.StateChanged += OnGameStateChanged;
            
            Debug.Log($"{nameof(ColoristService)} created");
        }

        // for debug purposes
        public void ResetColors()
        {
            _model.colorsPicker.ResetPosition();
            _colorist.ColorCubes();
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

        private async void ListenGameServices()
        {
            _inputService.MovePerformed += OnMovePerformed;
            await _model.LoadConfigs();
            
            _colorist.SpawnCubes();
            _colorist.ColorCubes();
        }

        private void Clear()
        {
            _inputService.MovePerformed -= OnMovePerformed;
            _model.UnloadConfigs();
            _colorist.DestroyCubes();
        }

        private void OnMovePerformed(Vector2 input)
        {
            _colorist.MoveColors(input);
            _colorist.ColorCubes();
        }
    }
}