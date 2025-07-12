using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Input;

namespace CodeBase.Infrastructure.Services
{
    public static class CompositionRoot
    {
        private static readonly Dictionary<Type, object> _container = new();
        
        public static void BuildGlobalScope()
        {
            SceneLoader sceneLoader = new SceneLoader();
            InputService inputService = new InputService();
            StaticDataService staticDataService = new StaticDataService();
            GameStateMachine stateMachine = new GameStateMachine(sceneLoader);
            ColoristService coloristService = new ColoristService(stateMachine, staticDataService, inputService);
            
            _container.Add(typeof(SceneLoader), sceneLoader);
            _container.Add(typeof(InputService), inputService);
            _container.Add(typeof(StaticDataService), staticDataService);
            _container.Add(typeof(GameStateMachine), stateMachine);
            _container.Add(typeof(ColoristService), coloristService);
        }

        public static TService Resolve<TService>() where TService : class
        {
            if (_container.TryGetValue(typeof(TService), out object service))
            {
                return (TService)service;
            }
            
            throw new InvalidOperationException($"Service of type {typeof(TService).FullName} is not registered in global scope");
        }
    }
}