using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private void LoadSceneLoading(string sceneName)
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(sceneName);
    }
}
