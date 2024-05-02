using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    private Image[] masterBar, sfxBar, bgmBar;
    [SerializeField] private Sprite unfill, filled;
    private GameObject masterVolume, sfxVolume, bgmVolume;
    public float masterValue, sfxValue, bgmValue, graphicsState;
    private TextMeshProUGUI graphicsText;

    private void Start()
    {
        masterVolume = gameObject.transform.Find("Main Volume").gameObject;
        sfxVolume = gameObject.transform.Find("SFX Volume").gameObject;
        bgmVolume = gameObject.transform.Find("BGM Volume").gameObject;

        masterBar = masterVolume.transform.Find("Setter").transform.Find("Bar").gameObject.GetComponentsInChildren<Image>();
        sfxBar = sfxVolume.transform.Find("Setter").transform.Find("Bar").gameObject.GetComponentsInChildren<Image>();
        bgmBar = bgmVolume.transform.Find("Setter").transform.Find("Bar").gameObject.GetComponentsInChildren<Image>();

        graphicsText = gameObject.transform.Find("Graphics").transform.Find("Setter").transform.Find("Text").GetComponent<TextMeshProUGUI>();

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

        BarChanged(masterBar, masterValue);
        BarChanged(sfxBar, sfxValue);
        BarChanged(bgmBar, bgmValue);

        audioMixer.SetFloat("master", Mathf.Lerp(-80f, 0f, (masterValue / 12f)));
        audioMixer.SetFloat("sfx", Mathf.Lerp(-80f, 0f, (sfxValue / 12f)));
        audioMixer.SetFloat("bgm", Mathf.Lerp(-80f, 0f, (bgmValue / 12f)));
        graphicsState = PlayerPrefs.GetFloat("graphicsState");
        GraphicsState();
    }

    public void VolMasterUp()
    {
        masterValue = Mathf.Clamp(masterValue + 1, 0, masterBar.Length);
        PlayerPrefs.SetFloat("masterValue", masterValue);
        audioMixer.SetFloat("master", ValueToAudioMixer(masterValue));
        for (int i = 0; i < masterBar.Length; i++)
        {
            masterBar[i].sprite = unfill;
        }
        for (int i = 0; i < masterValue; i++)
        {
            masterBar[i].sprite = filled;
        }
    }

    public void VolMasterDown()
    {
        masterValue = Mathf.Clamp(masterValue - 1, 0, masterBar.Length);
        PlayerPrefs.SetFloat("masterValue", masterValue);
        audioMixer.SetFloat("master", ValueToAudioMixer(masterValue));
        for (int i = 0; i < masterBar.Length; i++)
        {
            masterBar[i].sprite = unfill;
        }
        for (int i = 0; i < masterValue; i++)
        {
            masterBar[i].sprite = filled;
        }
    }

    public void VolSFXUp()
    {
        sfxValue = Mathf.Clamp(sfxValue + 1, 0, sfxBar.Length);
        PlayerPrefs.SetFloat("sfxValue", sfxValue);
        audioMixer.SetFloat("sfx", ValueToAudioMixer(sfxValue));
        for (int i = 0; i < sfxBar.Length; i++)
        {
            sfxBar[i].sprite = unfill;
        }
        for (int i = 0; i < sfxValue; i++)
        {
            sfxBar[i].sprite = filled;
        }
    }

    public void VolSFXDown()
    {
        sfxValue = Mathf.Clamp(sfxValue - 1, 0, sfxBar.Length);
        PlayerPrefs.SetFloat("sfxValue", sfxValue);
        audioMixer.SetFloat("sfx", ValueToAudioMixer(sfxValue));
        for (int i = 0; i < sfxBar.Length; i++)
        {
            sfxBar[i].sprite = unfill;
        }
        for (int i = 0; i < sfxValue; i++)
        {
            sfxBar[i].sprite = filled;
        }
    }

    public void VolBGMUp()
    {
        bgmValue = Mathf.Clamp(bgmValue + 1, 0, bgmBar.Length);
        PlayerPrefs.SetFloat("bgmValue", bgmValue);
        audioMixer.SetFloat("bgm", ValueToAudioMixer(bgmValue));
        for (int i = 0; i < bgmBar.Length; i++)
        {
            bgmBar[i].sprite = unfill;
        }
        for (int i = 0; i < bgmValue; i++)
        {
            bgmBar[i].sprite = filled;
        }
    }
    public void VolBGMDown()
    {
        bgmValue = Mathf.Clamp(bgmValue - 1, 0, bgmBar.Length);
        PlayerPrefs.SetFloat("bgmValue", bgmValue);
        audioMixer.SetFloat("bgm", ValueToAudioMixer(bgmValue));
        for (int i = 0; i < bgmBar.Length; i++)
        {
            bgmBar[i].sprite = unfill;
        }
        for (int i = 0; i < bgmValue; i++)
        {
            bgmBar[i].sprite = filled;
        }
    }

    private void BarChanged(Image[] barImg, float value)
    {
        for (int i = 0; i < barImg.Length; i++)
        {
            barImg[i].sprite = unfill;
        }
        for (int i = 0; i < value; i++)
        {
            barImg[i].sprite = filled;
        }
    }

    private float ValueToAudioMixer(float value)
    {
        return Mathf.Lerp(-80f, 0f, (value / 12f));
    }

    public void QualityUp()
    {
        graphicsState++;
        graphicsState = Mathf.Repeat(graphicsState, 3);
        PlayerPrefs.SetFloat("graphicsState", graphicsState);
        GraphicsState();
    }
    public void QualityDown()
    {
        graphicsState--;
        graphicsState = Mathf.Repeat(graphicsState, 3);
        PlayerPrefs.SetFloat("graphicsState", graphicsState);
        GraphicsState();
    }

    private void GraphicsState()
    {
        switch (graphicsState)
        {
            case 0:
                graphicsText.text = "Low";
                QualitySettings.SetQualityLevel(0);
                break;
            case 1:
                graphicsText.text = "Medium";
                QualitySettings.SetQualityLevel(1);
                break;
            case 2:
                graphicsText.text = "High";
                QualitySettings.SetQualityLevel(2);
                break;
        }
        Debug.Log(graphicsState);
    }
}
