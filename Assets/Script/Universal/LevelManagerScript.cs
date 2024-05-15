using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelManagerScript : MonoBehaviour
{
    private int previousStar;
    [HideInInspector] public int levelStars;
    [SerializeField] private Sprite[] starSprite; 
    public int currentPlayedLevel;
    private GameObject[] stars;

    private void Awake()
    {
        stars = transform.Find("Stars").GetComponentsInChildren<GameObject>();
        GameData gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/saved/PlayerProgress.json"));
        previousStar = gameData.levelStars[currentPlayedLevel];
    }

    public void StarIncrease()
    {
        levelStars++;
        for (int i = 0; i < levelStars; i++) 
        {
            Image starImage = stars[i].GetComponent<Image>();
            starImage.sprite = starSprite[1];
        }
    }

    public void Win()
    {
        JSONFormatter.SaveJSON(currentPlayedLevel, levelStars);
    }
}
