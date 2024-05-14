using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour 
{
    [System.Serializable]
    public class LevelProgress
    {
        public static string path = Application.persistentDataPath + "/PlayerProgress.json";
        public int highestLevel;
        public int[] levelsStar;
    }

    public void SaveData()
    {
        LevelProgress levelProgress = new LevelProgress();
        string json = JsonUtility.ToJson(levelProgress);
        File.WriteAllText(LevelProgress.path, json);
    }

    public void LoadData()
    {
        LevelProgress levelProgress = new LevelProgress();
        string json = File.ReadAllText(LevelProgress.path);
        levelProgress = JsonUtility.FromJson<LevelProgress>(json);
    }

    public void DeleteData()
    {
        LevelProgress levelProgress = new LevelProgress();
        File.Delete(LevelProgress.path);
    }
}
