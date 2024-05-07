using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsSettingsScript : MonoBehaviour
{
    private TextMeshProUGUI graphicsText, vsyncText;
    private float graphicsState, vsyncState;
    private float vsyncSwitch;

    private void Awake()
    {
        graphicsText = gameObject.transform.Find("Graphics").transform.Find("Value").GetComponent<TextMeshProUGUI>();
        vsyncText = gameObject.transform.Find("Vsync").transform.Find("Value").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        vsyncSwitch = QualitySettings.vSyncCount;
        if (vsyncSwitch == 1)
        {
            QualitySettings.vSyncCount = 1;
            vsyncText.text = "On";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vsyncText.text = "Off";
        }
        graphicsState = QualitySettings.GetQualityLevel();
        ShowGraphicsValue();
        switch (graphicsState)
        {
            case 0:
                graphicsText.text = "Low";
                break;
            case 1:
                graphicsText.text = "Medium";
                break;
            case 2:
                graphicsText.text = "High";
                break;
        }
    }

    public void SetGraphicsUp()
    {
        graphicsState = Mathf.Repeat(graphicsState + 1, 3);
        QualitySettings.SetQualityLevel((int)graphicsState);
        ShowGraphicsValue();
        Debug.Log(graphicsState);
    }

    public void SetGraphicsDown()
    {
        graphicsState = Mathf.Repeat(graphicsState - 1, 3);
        QualitySettings.SetQualityLevel((int)graphicsState);
        ShowGraphicsValue();
        Debug.Log(graphicsState);
    }

    private void ShowGraphicsValue()
    {
        graphicsState = QualitySettings.GetQualityLevel();
        switch (graphicsState)
        {
            case 0:
                graphicsText.text = "Low";
                break;
            case 1:
                graphicsText.text = "Medium";
                break;
            case 2:
                graphicsText.text = "High";
                break;
        }
    }

    public void VsyncSwitch()
    {
        vsyncSwitch = Mathf.Repeat(vsyncSwitch + 1, 2);
        if (vsyncSwitch == 1)
        {
            QualitySettings.vSyncCount = 1;
            vsyncText.text = "On";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vsyncText.text = "Off";
        }
    }
}
