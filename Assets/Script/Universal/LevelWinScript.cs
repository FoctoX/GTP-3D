using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinScript : MonoBehaviour
{
    public static int levelProgress;
    public static int currentLevel;
    public static string sceneName;

    public void PlayerWonTheLevel()
    {
        if (levelProgress <= currentLevel)
        {
            levelProgress = levelProgress + 1;
        }
        else
        {
            return;
        }
    }

    public void NextLevel()
    {
        
    }

    private string LevelName(int index)
    {
        sceneName = "Level" + index;
        return sceneName;
    }
}
