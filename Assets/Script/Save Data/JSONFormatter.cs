using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONFormatter : MonoBehaviour
{
    private string path = "/saved/PlayerProgress.json";

    private void Awake()
    {
        
    }

    public void SaveJSON(int currentLevelPlayed, int levelStars)
    {
        GameData gameData = new GameData();
        string json = File.ReadAllText(Application.persistentDataPath + path);
        gameData = JsonUtility.FromJson<GameData>(json);
        if (currentLevelPlayed >= gameData.highestLevel) gameData.highestLevel = currentLevelPlayed + 1;
        gameData.levelStars[currentLevelPlayed] = levelStars;
        json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + path, json);
    }

    public void LoadJSON(int highestLevel, int[] levelStars)
    {
        string json = File.ReadAllText(Application.persistentDataPath + path);
        GameData gameData = JsonUtility.FromJson<GameData>(json);
        highestLevel = gameData.highestLevel;
        levelStars = gameData.levelStars;
    }
}
