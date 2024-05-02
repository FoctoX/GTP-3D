using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionMouseHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite unselect, select;
    private GameObject misc;

    private void Awake()
    {
        misc = gameObject.transform.Find("Misc").gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = select;
        misc.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = unselect;
        misc.SetActive(false);
    }

}
