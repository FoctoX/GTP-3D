using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    private GameData gameData;
    [HideInInspector] public int levelStars;
    [SerializeField] private Sprite[] starSprite; 
    public int currentPlayedLevel;
    private GameObject[] stars;

    private void Awake()
    {
        stars = transform.Find("Stars").GetComponentsInChildren<GameObject>();
        gameData = transform.Find("Data Manager").GetComponent<GameData>();
        
    }

    public void StarIncrease()
    {

    }

    public void Win()
    {
        gameData.;
        GameData.
    }
}
