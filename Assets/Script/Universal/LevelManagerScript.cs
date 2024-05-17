using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using HutongGames.PlayMaker;

public class LevelManagerScript : MonoBehaviour
{
    private int previousStar;
    [HideInInspector] public int levelStars;
    [SerializeField] private Sprite[] starSprite; 
    public static int currentPlayedLevel;
    private Image[] stars;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;

    private void Awake()
    {
        stars = transform.Find("Canvas").transform.Find("Stars").GetComponentsInChildren<Image>();
        GameData gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/Player.json"));
        previousStar = gameData.levelStars[currentPlayedLevel];
    }

    private void Update()
    {
        healthSlider.value = FsmVariables.GlobalVariables.GetFsmFloat("Health").Value / FsmVariables.GlobalVariables.GetFsmFloat("Max Health").Value;
        staminaSlider.value = FsmVariables.GlobalVariables.GetFsmFloat("Stamina").Value / FsmVariables.GlobalVariables.GetFsmFloat("Max Stamina").Value;
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
