using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private int previousStar;
    [HideInInspector] public int levelStars;
    [SerializeField] private Sprite[] starSprite; 
    public static int currentPlayedLevel;
    private Image[] stars;

    private void Awake()
    {
        stars = transform.Find("Canvas").transform.Find("Stars").GetComponentsInChildren<Image>();
        GameData gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/Player.json"));
        previousStar = gameData.levelStars[currentPlayedLevel];
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManagerScript.levelTransition = "Main Menu";
        SceneManager.LoadScene("Loading");
    }

    public void StarIncrease()
    {
        levelStars++;
        for (int i = 0; i < levelStars; i++) 
        {
            Image starImage = stars[i];
            starImage.sprite = starSprite[1];
        }
    }

    public void Win()
    {
        JSONFormatter.SaveJSON(currentPlayedLevel, levelStars);
    }
}
