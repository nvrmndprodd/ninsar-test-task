using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Start()
        {
            CompositionRoot.BuildGlobalScope();
            
            CompositionRoot.Resolve<GameStateMachine>().Enter<BootstrapState>();
        }
    }
}
