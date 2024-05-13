using UnityEngine;

public class MainMenuScirpt : MonoBehaviour
{
    [SerializeField] private GameObject playButton;

    private void Awake()
    {
        PlayButtonEnable();
    }

    private void PlayButtonEnable()
    {
        playButton.SetActive(PlayerPrefs.HasKey("CurrentLevelProgressPP"));
    }

    private void NewGameFunction()
    {
        if (PlayerPrefs.HasKey("CurrentLevelProgressPP")) PlayerPrefs.DeleteKey("CurrentLevelProgressPP");
    }

}
