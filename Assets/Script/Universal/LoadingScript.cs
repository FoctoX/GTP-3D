using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("LoadingCoroutine");
    }

    private IEnumerator LoadingCoroutine()
    {
        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(SceneManagerScript.levelTransition);
        yield return null;
    }
}
