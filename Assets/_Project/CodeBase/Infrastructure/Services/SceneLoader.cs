using System.Threading.Tasks;
using CodeBase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services
{
    public class SceneLoader
    {
        public SceneLoader()
        {
            Debug.Log($"{nameof(SceneLoader)} created");
        }
        
        public async Task LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            await SceneManager.LoadSceneAsync(sceneName, loadSceneMode).AsTask();
        }
        
        public async Task LoadSceneAsync(int index, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            await SceneManager.LoadSceneAsync(index, loadSceneMode).AsTask();
        }

        public async Task UnloadSceneAsync(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName).AsTask();
        }

        public async Task UnloadSceneAsync(int index)
        {
            await SceneManager.UnloadSceneAsync(index).AsTask();
        }
    }
}