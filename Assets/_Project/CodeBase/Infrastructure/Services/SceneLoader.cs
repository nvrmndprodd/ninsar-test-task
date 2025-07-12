using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services
{
    public class SceneLoader
    {
        public void LoadSceneSynchronously(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        public void UnloadSceneSynchronously(string sceneName)
        {
            SceneManager.UnloadScene(sceneName);
        }
    }
}