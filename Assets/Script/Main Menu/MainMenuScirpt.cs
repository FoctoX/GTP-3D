using UnityEngine;

public class MainMenuScirpt : MonoBehaviour
{
    [SerializeField] private GameObject playButton;

    private void Start()
    {

    }

    private void PlayButtonEnable()
    {
        playButton.SetActive(PlayerPrefs.HasKey("CurrentLevelProgressPP"));
    }

    public void PlayButtonFunction()
    {

    }

    private void NewGameFunction()
    {
        if (PlayerPrefs.HasKey("CurrentLevelProgressPP")) PlayerPrefs.DeleteKey("CurrentLevelProgressPP");
    }

}
