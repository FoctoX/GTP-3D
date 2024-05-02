using UnityEngine;

public class initializationScript : SettingsScript
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("masterValue") || PlayerPrefs.HasKey("sfxValue") || PlayerPrefs.HasKey("bgmValue") || PlayerPrefs.HasKey("graphicsState"))
        {
            masterValue = PlayerPrefs.GetFloat("masterValue");
            sfxValue = PlayerPrefs.GetFloat("sfxValue");
            bgmValue = PlayerPrefs.GetFloat("bgmValue");
            graphicsState = PlayerPrefs.GetFloat("graphicsState");
        }
        else
        {
            PlayerPrefs.SetFloat("masterValue", 6);
            PlayerPrefs.SetFloat("sfxValue", 6);
            PlayerPrefs.SetFloat("bgmValue", 6);
            PlayerPrefs.SetFloat("graphicsState", 1);
            masterValue = PlayerPrefs.GetFloat("masterValue");
            sfxValue = PlayerPrefs.GetFloat("sfxValue");
            bgmValue = PlayerPrefs.GetFloat("bgmValue");
            graphicsState = PlayerPrefs.GetFloat("graphicsState");
        }

        audioMixer.SetFloat("master", Mathf.Lerp(-80f, 0f, (masterValue / 12f)));
        audioMixer.SetFloat("sfx", Mathf.Lerp(-80f, 0f, (sfxValue / 12f)));
        audioMixer.SetFloat("bgm", Mathf.Lerp(-80f, 0f, (bgmValue / 12f)));
        graphicsState = PlayerPrefs.GetFloat("graphicsState");
    }
}
