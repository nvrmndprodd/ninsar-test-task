using System;

namespace CodeBase.Infrastructure.StateMachine
{
    public enum GameStateType
    {
        Bootstrap = 0,
        GameLoop = 1,
        
        Undefined = 99,
    }
    
    public static class StateConverter
    {
        public static GameStateType ToEnum(IState state)
        {
            return state switch
            {
                BootstrapState => GameStateType.Bootstrap,
                GameLoopState => GameStateType.GameLoop,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state.GetType().Name,
                    $"Unknown state: {state.GetType().Name} for enum")
            };
        }
    }
}