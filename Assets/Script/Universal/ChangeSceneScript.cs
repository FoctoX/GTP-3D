using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    [SerializeField] private bool isLoadingScreen = false;

    private void Awake()
    {
        if (isLoadingScreen) StartCoroutine("LoadSceneCoroutine");
    }

    [SerializeField] private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("Loading Screen");
        PlayerPrefs.SetString("SceneNamePP", sceneName);
    }

    private IEnumerator LoadSceneCoroutine()
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("CurrentLevelProgressPP"));
        while (loadedScene.isDone)
        {
            yield return null;
        }
    }
}
