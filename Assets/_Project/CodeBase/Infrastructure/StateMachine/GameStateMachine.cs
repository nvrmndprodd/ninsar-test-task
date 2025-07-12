using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        public GameStateMachine(SceneLoader sceneLoader)
        {
        }

        public void Enter<TState>() where TState : IState
        {
            
        }
    }
}