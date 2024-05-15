using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class SceneManagerScript
{
    public static int currentLevelPlayed;
    public static string levelTransition;
    public static int levelProgress = 1;

    public void EnterNextLevel()
    {
        levelTransition = "level" + (currentLevelPlayed + 1).ToString();
        SceneManager.LoadScene("loading");
    }

    public void EnterPreviousLevel()
    {
        levelTransition = "level" + (currentLevelPlayed - 1).ToString();
        SceneManager.LoadScene("loading");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
