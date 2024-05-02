using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject button;
    private GameObject gem;
    private TextMeshProUGUI text;

    private void Awake()
    {
        gem = gameObject.transform.Find("Gem").gameObject;
        text = gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gem.SetActive(true);
        text.color = new Color32(255, 134, 22, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gem.SetActive(false);
        text.color = new Color32(255, 255, 255, 255);
    }
}
