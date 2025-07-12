using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure.Services
{
    public static class CompositionRoot
    {
        private static readonly Dictionary<Type, object> _container = new();
        
        public static void BuildGlobalScope()
        {
            SceneLoader sceneLoader = new SceneLoader();
            GameStateMachine stateMachine = new GameStateMachine(sceneLoader);
            ColoristService colorist = new ColoristService(stateMachine);
            
            _container.Add(typeof(SceneLoader), sceneLoader);
            _container.Add(typeof(GameStateMachine), stateMachine);
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